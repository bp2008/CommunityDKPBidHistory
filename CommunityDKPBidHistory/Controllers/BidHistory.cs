using BPUtil;
using BPUtil.MVC;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CommunityDKPBidHistory.Controllers
{
	public class BidHistory : Controller
	{
		public ActionResult Index()
		{
			string dkpLua = DKPHistory.GetLuaFileContents();
			if (dkpLua == null)
				return new ErrorResult("The server is currently initializing.");

			ViewDataContainer viewData = new ViewDataContainer();

			viewData.Set("GuildName", DKPHistory.settings.guildName);
			viewData.Set("Loot", GetLootJson(dkpLua));
			viewData.Set("Players", GetPlayerJson(dkpLua));

			if (Debugger.IsAttached)
				viewData.Set("VueScriptName", "vue.js");
			else
				viewData.Set("VueScriptName", "vue.min.js");

			string rootDir = Globals.ApplicationDirectoryBase;
			if (Debugger.IsAttached)
				rootDir += "../../";

			return new ViewResult(rootDir + "Index.html", viewData);
		}

		private static Regex rxFindLootItem = new Regex("{([^}]+)}", RegexOptions.Compiled | RegexOptions.Singleline);
		private static Regex rxFindLootDetail = new Regex("\\[\"([^\"]+)\"\\] = ([^\\r\\n]+)", RegexOptions.Compiled | RegexOptions.Singleline);
		private static Regex rxParseLootValue = new Regex("\\|([^|]+)\\|Hitem:(\\d+):[^|]+\\|h\\[([^\\]]+)\\]\\|", RegexOptions.Compiled);

		private string GetLootJson(string lua)
		{
			return ParseLua<LootItem>(lua, "CommDKP_Loot", (item, key, value) =>
			{
				if (key.Equals("date", StringComparison.OrdinalIgnoreCase) && long.TryParse(value, out long n1))
					item.date = n1;
				else if (key.Equals("cost", StringComparison.OrdinalIgnoreCase) && long.TryParse(value, out long n2))
					item.cost = (int)n2;
				else if (key.Equals("player", StringComparison.OrdinalIgnoreCase))
					item.player = value;
				else if (key.Equals("zone", StringComparison.OrdinalIgnoreCase))
					item.zone = value;
				else if (key.Equals("boss", StringComparison.OrdinalIgnoreCase))
					item.boss = value;
				else if (key.Equals("loot", StringComparison.OrdinalIgnoreCase))
				{
					Match lootParsed = rxParseLootValue.Match(value);
					if (lootParsed.Success)
					{
						string color = lootParsed.Groups[1].Value;
						if (color.Length > 6)
							color = color.Substring(color.Length - 6);
						item.color = color;
						item.itemid = int.Parse(lootParsed.Groups[2].Value);
						item.name = lootParsed.Groups[3].Value;
					}
				}
			},
			(a, b) =>
			{
				return b.date.CompareTo(a.date);
			});
		}
		private static HashSet<string> wowClasses = new HashSet<string>(new string[] {
			"warrior","druid","paladin"
			,"priest","warlock","mage"
			,"hunter","rogue","shaman"
			,"deathknight","monk","demonhunter"
		});
		private string GetPlayerJson(string lua)
		{
			return ParseLua<Player>(lua, "CommDKP_DKPTable", (item, key, value) =>
			{
				if (key.Equals("player", StringComparison.OrdinalIgnoreCase))
					item.name = value;
				else if (key.Equals("class", StringComparison.OrdinalIgnoreCase))
				{
					value = value.ToLower();
					if (wowClasses.Contains(value))
						item.wowclass = value.ToLower();
					else
						item.wowclass = "unrecognized";
				}
			});
		}
		private string ParseLua<T>(string lua, string luaObjectName, Action<T, string, string> SetValue, Comparison<T> SortFn = null) where T : new()
		{
			string searchFor = luaObjectName + " = {";
			int startIdx = lua.IndexOf(searchFor);
			if (startIdx > -1)
			{
				startIdx += searchFor.Length;
				int endIdx = lua.IndexOf("\r\n}", startIdx);
				string lootSection = lua.Substring(startIdx, endIdx - startIdx);
				if (endIdx > -1)
				{
					List<T> items = new List<T>();
					Match m = rxFindLootItem.Match(lootSection);
					while (m.Success)
					{
						T item = new T();

						bool itemOk = false;
						Match mDetail = rxFindLootDetail.Match(m.Value);
						while (mDetail.Success)
						{
							itemOk = true;

							string key = mDetail.Groups[1].Value;
							string value = mDetail.Groups[2].Value;
							if (value.EndsWith(","))
								value = value.Substring(0, value.Length - 1);
							if (value.StartsWith("\"") && value.EndsWith("\""))
								value = Regex.Unescape(value.Substring(1, value.Length - 2));
							SetValue(item, key, value);
							mDetail = mDetail.NextMatch();
						}
						if (itemOk)
							items.Add(item);
						m = m.NextMatch();
					}

					if (SortFn != null)
						items.Sort(SortFn);

					return JsonConvert.SerializeObject(items);
				}
			}
			return "[]";
		}
	}

	public class LootItem
	{
		public int itemid; // wow classic item ID
		public string name = "";
		public string player = "";
		public string zone;
		public long date; // Unix epoch time in seconds
		public int cost;
		public string boss = "";
		public string color = "dddddd"; // hex color of item name
	}
	public class Player
	{
		public string name;
		public string wowclass;
	}
}

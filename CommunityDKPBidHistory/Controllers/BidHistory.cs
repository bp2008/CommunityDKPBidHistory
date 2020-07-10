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
			if (DKPHistory.history == null)
				return new ErrorResult("The server failed to initialize.");

			ViewDataContainer viewData = new ViewDataContainer();

			viewData.Set("GuildName", DKPHistory.settings.guildName);

			IEnumerable<LootItem> items = DKPHistory.history.lootItems.Values
				.OrderByDescending(item => item.date)
				.ThenBy(item => item.name);
			viewData.Set("Loot", JsonConvert.SerializeObject(items));

			IEnumerable<Player> players = DKPHistory.history.playerClasses.Select(kvp => new Player() { name = kvp.Key, wowclass = kvp.Value });
			viewData.Set("Players", JsonConvert.SerializeObject(players));

			if (Debugger.IsAttached)
				viewData.Set("VueScriptName", "vue.js");
			else
				viewData.Set("VueScriptName", "vue.min.js");

			string rootDir = Globals.ApplicationDirectoryBase;
			if (Debugger.IsAttached)
				rootDir += "../../";

			return new ViewResult(rootDir + "Index.html", viewData);
		}
	}
}

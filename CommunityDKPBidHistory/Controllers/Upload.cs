using BPUtil;
using BPUtil.MVC;
using CommunityDKPBidHistory.Data;
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
	public class Upload : Controller
	{
		public ActionResult Index()
		{
			if (!DKPHistory.settings.receiveUploads)
				return PlainText("0: This server is not configured to receive uploads.");
			string authStr = Context.httpProcessor.GetHeaderValue("X-Dkp-Auth");
			if (DKPHistory.VerifyAuthString(authStr))
			{
				try
				{
					string lua = ByteUtil.Utf8NoBOM.GetString(Context.httpProcessor.PostBodyStream.ToArray());
					DKPHistory.history.AddFromLuaString(lua);
					lock (DKPHistory.LuaFileLock)
						File.WriteAllText(Globals.WritableDirectoryBase + "History.json", JsonConvert.SerializeObject(DKPHistory.history, Formatting.Indented), ByteUtil.Utf8NoBOM);
					return PlainText("1");
				}
				catch (Exception ex)
				{
					Logger.Debug(ex);
					return PlainText("0: An error occurred and was logged on the server at " + DateTime.UtcNow.ToString());
				}
			}
			else
				return PlainText("0: Authentication Failed");
		}
	}
}

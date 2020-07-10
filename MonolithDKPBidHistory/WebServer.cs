using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BPUtil;
using BPUtil.MVC;
using BPUtil.SimpleHttp;

namespace CommunityDKPBidHistory
{
	public class WebServer : HttpServer
	{
		private MVCMain mvc;
		public WebServer(int port) : base(port)
		{
			mvc = new MVCMain(Assembly.GetExecutingAssembly(), typeof(Controllers.BidHistory).Namespace);
		}

		public override void handleGETRequest(HttpProcessor p)
		{
			if (p.requestedPage == "vue.min.js" || p.requestedPage == "vue.js")
			{
				byte[] fileData = File.ReadAllBytes(Globals.ApplicationDirectoryBase + p.requestedPage);
				p.writeSuccess("text/javascript; charset=UTF-8");
				p.outputStream.Flush();
				p.tcpStream.Write(fileData, 0, fileData.Length);
			}
			else
			{
				string requestedPage = p.requestedPage;
				if (requestedPage == "")
					requestedPage = "BidHistory";
				mvc.ProcessRequest(p, requestedPage);
			}
		}

		public override void handlePOSTRequest(HttpProcessor p, StreamReader inputData)
		{
			string requestedPage = p.requestedPage;
			if (requestedPage == "")
				requestedPage = "BidHistory";
			mvc.ProcessRequest(p, requestedPage);
		}

		protected override void stopServer()
		{
		}
	}
}

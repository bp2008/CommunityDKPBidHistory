using BPUtil;
using BPUtil.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CommunityDKPBidHistory
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			System.Reflection.Assembly assembly = System.Reflection.Assembly.GetEntryAssembly();
			Globals.Initialize(assembly.Location, "");

			WindowsServiceInitOptions o = new WindowsServiceInitOptions();
			o.ServiceManagerButtons_UpdateSettingsFile = false;
			o.ServiceManagerButtons = new ButtonDefinition[] {
				new ButtonDefinition("Configure", btnConfigure_Click)
			};
			AppInit.WindowsService<DKPHistory>(o);
		}
		private static Configuration cfgDiag = null;
		private static void btnConfigure_Click(object sender, EventArgs e)
		{
			if (cfgDiag != null)
			{
				cfgDiag.BringToFront();
				return;
			}
			cfgDiag = new Configuration();
			cfgDiag.FormClosed += CfgDiag_FormClosed;
			cfgDiag.ShowDialog();
		}

		private static void CfgDiag_FormClosed(object sender, FormClosedEventArgs e)
		{
			cfgDiag = null;
		}
	}
}

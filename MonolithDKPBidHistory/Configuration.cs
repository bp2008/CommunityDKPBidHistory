using BPUtil;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonolithDKPBidHistory
{
	public partial class Configuration : Form
	{
		bool okToClose = false;
		public Configuration()
		{
			InitializeComponent();
			txtGuildName.Text = DKPHistory.settings.guildName;
			cbEnableWebServer.Checked = DKPHistory.settings.enableWebServer;
			nudHttpPort.Value = DKPHistory.settings.httpPort;
			txtLuaPath.Text = DKPHistory.settings.luaFilePath;
			nudRemoteUploadInterval.Value = DKPHistory.settings.remoteUploadIntervalMinutes;
			txtRemoteUploadUrl.Text = DKPHistory.settings.remoteUploadUrl;
			txtServerPassword.Text = DKPHistory.settings.serverPassword;
			cbAcceptUploads.Checked = DKPHistory.settings.receiveUploads;
			nudLocalBackupInterval.Value = DKPHistory.settings.localBackupIntervalMinutes;
			txtLocalBackupFolder.Text = DKPHistory.settings.localBackupPath;
		}

		private void btnBrowseLocalLua_Click(object sender, EventArgs e)
		{
			DialogResult dr = openFileDialog_LuaFile.ShowDialog();
			if (dr == DialogResult.OK)
				txtLuaPath.Text = openFileDialog_LuaFile.FileName;
		}

		private void btnBrowseLocalBackupFolder_Click(object sender, EventArgs e)
		{
			DialogResult dr = folderBrowserDialog_LocalBackups.ShowDialog();
			if (dr == DialogResult.OK)
				txtLocalBackupFolder.Text = folderBrowserDialog_LocalBackups.SelectedPath;
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			Save();
			okToClose = true;
			this.Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			okToClose = true;
			this.Close();
		}
		private void Save()
		{
			DKPHistory.settings.guildName = txtGuildName.Text;
			DKPHistory.settings.enableWebServer = cbEnableWebServer.Checked;
			DKPHistory.settings.httpPort = (int)nudHttpPort.Value;
			DKPHistory.settings.luaFilePath = txtLuaPath.Text;
			DKPHistory.settings.remoteUploadIntervalMinutes = (int)nudRemoteUploadInterval.Value;
			DKPHistory.settings.remoteUploadUrl = txtRemoteUploadUrl.Text;
			DKPHistory.settings.serverPassword = txtServerPassword.Text;
			DKPHistory.settings.receiveUploads = cbAcceptUploads.Checked;
			DKPHistory.settings.localBackupIntervalMinutes = (int)nudLocalBackupInterval.Value;
			DKPHistory.settings.localBackupPath = txtLocalBackupFolder.Text;
			DKPHistory.settings.Save();
		}

		private void Configuration_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (!okToClose)
			{
				okToClose = true;
				DialogResult dr = MessageBox.Show("Do you want to save the configuration?", "Save?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (dr == DialogResult.Yes)
				{
					Save();
				}
			}
		}

		private void btnServerPasswordGenerate_Click(object sender, EventArgs e)
		{
			txtServerPassword.Text = StringUtil.GetRandomAlphaNumericString(20);
		}
	}
}

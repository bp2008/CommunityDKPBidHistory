namespace CommunityDKPBidHistory
{
	partial class Configuration
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.cbEnableWebServer = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.nudHttpPort = new System.Windows.Forms.NumericUpDown();
			this.txtLuaPath = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.btnBrowseLocalLua = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.nudRemoteUploadInterval = new System.Windows.Forms.NumericUpDown();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.txtRemoteUploadUrl = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.txtServerPassword = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.nudLocalBackupInterval = new System.Windows.Forms.NumericUpDown();
			this.btnBrowseLocalBackupFolder = new System.Windows.Forms.Button();
			this.label11 = new System.Windows.Forms.Label();
			this.txtLocalBackupFolder = new System.Windows.Forms.TextBox();
			this.openFileDialog_LuaFile = new System.Windows.Forms.OpenFileDialog();
			this.folderBrowserDialog_LocalBackups = new System.Windows.Forms.FolderBrowserDialog();
			this.btnOk = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnServerPasswordGenerate = new System.Windows.Forms.Button();
			this.label12 = new System.Windows.Forms.Label();
			this.txtGuildName = new System.Windows.Forms.TextBox();
			this.cbAcceptUploads = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.nudHttpPort)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudRemoteUploadInterval)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudLocalBackupInterval)).BeginInit();
			this.SuspendLayout();
			// 
			// cbEnableWebServer
			// 
			this.cbEnableWebServer.AutoSize = true;
			this.cbEnableWebServer.Location = new System.Drawing.Point(12, 12);
			this.cbEnableWebServer.Name = "cbEnableWebServer";
			this.cbEnableWebServer.Size = new System.Drawing.Size(119, 17);
			this.cbEnableWebServer.TabIndex = 0;
			this.cbEnableWebServer.Text = "Enable Web Server";
			this.cbEnableWebServer.UseVisualStyleBackColor = true;
			this.cbEnableWebServer.CheckedChanged += new System.EventHandler(this.cbEnableWebServer_CheckedChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(167, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 13);
			this.label1.TabIndex = 1;
			this.label1.Tag = "requiresWebServer";
			this.label1.Text = "HTTP on port";
			// 
			// nudHttpPort
			// 
			this.nudHttpPort.Location = new System.Drawing.Point(245, 9);
			this.nudHttpPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
			this.nudHttpPort.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.nudHttpPort.Name = "nudHttpPort";
			this.nudHttpPort.Size = new System.Drawing.Size(62, 20);
			this.nudHttpPort.TabIndex = 1;
			this.nudHttpPort.Tag = "requiresWebServer";
			this.nudHttpPort.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// txtLuaPath
			// 
			this.txtLuaPath.Location = new System.Drawing.Point(12, 89);
			this.txtLuaPath.Name = "txtLuaPath";
			this.txtLuaPath.Size = new System.Drawing.Size(348, 20);
			this.txtLuaPath.TabIndex = 3;
			this.txtLuaPath.Tag = "";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 70);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(134, 13);
			this.label2.TabIndex = 4;
			this.label2.Tag = "";
			this.label2.Text = "Path to CommunityDKP.lua";
			// 
			// btnBrowseLocalLua
			// 
			this.btnBrowseLocalLua.Location = new System.Drawing.Point(366, 87);
			this.btnBrowseLocalLua.Name = "btnBrowseLocalLua";
			this.btnBrowseLocalLua.Size = new System.Drawing.Size(75, 23);
			this.btnBrowseLocalLua.TabIndex = 5;
			this.btnBrowseLocalLua.Tag = "";
			this.btnBrowseLocalLua.Text = "Browse";
			this.btnBrowseLocalLua.UseVisualStyleBackColor = true;
			this.btnBrowseLocalLua.Click += new System.EventHandler(this.btnBrowseLocalLua_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 136);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(258, 13);
			this.label3.TabIndex = 6;
			this.label3.Tag = "requiresNoWebServer";
			this.label3.Text = "-- Upload CommunityDKP.lua to another web server --";
			// 
			// nudRemoteUploadInterval
			// 
			this.nudRemoteUploadInterval.Location = new System.Drawing.Point(101, 157);
			this.nudRemoteUploadInterval.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
			this.nudRemoteUploadInterval.Name = "nudRemoteUploadInterval";
			this.nudRemoteUploadInterval.Size = new System.Drawing.Size(71, 20);
			this.nudRemoteUploadInterval.TabIndex = 7;
			this.nudRemoteUploadInterval.Tag = "requiresNoWebServer";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 159);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(82, 13);
			this.label4.TabIndex = 8;
			this.label4.Tag = "requiresNoWebServer";
			this.label4.Text = "Upload Interval:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(178, 159);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(112, 13);
			this.label5.TabIndex = 9;
			this.label5.Tag = "requiresNoWebServer";
			this.label5.Text = "(minutes). 0 to disable.";
			// 
			// txtRemoteUploadUrl
			// 
			this.txtRemoteUploadUrl.Location = new System.Drawing.Point(101, 183);
			this.txtRemoteUploadUrl.Name = "txtRemoteUploadUrl";
			this.txtRemoteUploadUrl.Size = new System.Drawing.Size(340, 20);
			this.txtRemoteUploadUrl.TabIndex = 10;
			this.txtRemoteUploadUrl.Tag = "requiresNoWebServer";
			this.txtRemoteUploadUrl.Text = "http://example.com/Upload";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(12, 186);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(69, 13);
			this.label6.TabIndex = 11;
			this.label6.Tag = "requiresNoWebServer";
			this.label6.Text = "Upload URL:";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(12, 212);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(90, 13);
			this.label7.TabIndex = 13;
			this.label7.Text = "Server Password:";
			// 
			// txtServerPassword
			// 
			this.txtServerPassword.Location = new System.Drawing.Point(108, 209);
			this.txtServerPassword.Name = "txtServerPassword";
			this.txtServerPassword.Size = new System.Drawing.Size(252, 20);
			this.txtServerPassword.TabIndex = 12;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(12, 282);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(200, 13);
			this.label8.TabIndex = 14;
			this.label8.Tag = "requiresNoWebServer";
			this.label8.Text = "-- Local backups of CommunityDKP.lua --";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(178, 303);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(112, 13);
			this.label9.TabIndex = 17;
			this.label9.Tag = "requiresNoWebServer";
			this.label9.Text = "(minutes). 0 to disable.";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(12, 303);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(85, 13);
			this.label10.TabIndex = 16;
			this.label10.Tag = "requiresNoWebServer";
			this.label10.Text = "Backup Interval:";
			// 
			// nudLocalBackupInterval
			// 
			this.nudLocalBackupInterval.Location = new System.Drawing.Point(101, 301);
			this.nudLocalBackupInterval.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
			this.nudLocalBackupInterval.Name = "nudLocalBackupInterval";
			this.nudLocalBackupInterval.Size = new System.Drawing.Size(71, 20);
			this.nudLocalBackupInterval.TabIndex = 15;
			this.nudLocalBackupInterval.Tag = "requiresNoWebServer";
			// 
			// btnBrowseLocalBackupFolder
			// 
			this.btnBrowseLocalBackupFolder.Location = new System.Drawing.Point(366, 343);
			this.btnBrowseLocalBackupFolder.Name = "btnBrowseLocalBackupFolder";
			this.btnBrowseLocalBackupFolder.Size = new System.Drawing.Size(75, 23);
			this.btnBrowseLocalBackupFolder.TabIndex = 20;
			this.btnBrowseLocalBackupFolder.Tag = "requiresNoWebServer";
			this.btnBrowseLocalBackupFolder.Text = "Browse";
			this.btnBrowseLocalBackupFolder.UseVisualStyleBackColor = true;
			this.btnBrowseLocalBackupFolder.Click += new System.EventHandler(this.btnBrowseLocalBackupFolder_Click);
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(12, 325);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(135, 13);
			this.label11.TabIndex = 19;
			this.label11.Tag = "requiresNoWebServer";
			this.label11.Text = "Folder to place backups in:";
			// 
			// txtLocalBackupFolder
			// 
			this.txtLocalBackupFolder.Location = new System.Drawing.Point(12, 345);
			this.txtLocalBackupFolder.Name = "txtLocalBackupFolder";
			this.txtLocalBackupFolder.Size = new System.Drawing.Size(348, 20);
			this.txtLocalBackupFolder.TabIndex = 18;
			this.txtLocalBackupFolder.Tag = "requiresNoWebServer";
			// 
			// openFileDialog_LuaFile
			// 
			this.openFileDialog_LuaFile.DefaultExt = "lua";
			this.openFileDialog_LuaFile.FileName = "CommunityDKP.lua";
			this.openFileDialog_LuaFile.Filter = "Lua files|*.lua";
			// 
			// btnOk
			// 
			this.btnOk.Location = new System.Drawing.Point(148, 371);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(75, 23);
			this.btnOk.TabIndex = 21;
			this.btnOk.Text = "OK";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(229, 371);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 22;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnServerPasswordGenerate
			// 
			this.btnServerPasswordGenerate.Location = new System.Drawing.Point(366, 207);
			this.btnServerPasswordGenerate.Name = "btnServerPasswordGenerate";
			this.btnServerPasswordGenerate.Size = new System.Drawing.Size(75, 23);
			this.btnServerPasswordGenerate.TabIndex = 13;
			this.btnServerPasswordGenerate.Text = "Generate";
			this.btnServerPasswordGenerate.UseVisualStyleBackColor = true;
			this.btnServerPasswordGenerate.Click += new System.EventHandler(this.btnServerPasswordGenerate_Click);
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(12, 38);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(65, 13);
			this.label12.TabIndex = 24;
			this.label12.Tag = "requiresWebServer";
			this.label12.Text = "Guild Name:";
			// 
			// txtGuildName
			// 
			this.txtGuildName.Location = new System.Drawing.Point(83, 35);
			this.txtGuildName.Name = "txtGuildName";
			this.txtGuildName.Size = new System.Drawing.Size(358, 20);
			this.txtGuildName.TabIndex = 2;
			this.txtGuildName.Tag = "requiresWebServer";
			// 
			// cbAcceptUploads
			// 
			this.cbAcceptUploads.AutoSize = true;
			this.cbAcceptUploads.Location = new System.Drawing.Point(101, 235);
			this.cbAcceptUploads.Name = "cbAcceptUploads";
			this.cbAcceptUploads.Size = new System.Drawing.Size(191, 17);
			this.cbAcceptUploads.TabIndex = 25;
			this.cbAcceptUploads.Tag = "requiresWebServer";
			this.cbAcceptUploads.Text = "Accept uploads from remote clients";
			this.cbAcceptUploads.UseVisualStyleBackColor = true;
			// 
			// Configuration
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(453, 404);
			this.Controls.Add(this.cbAcceptUploads);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.txtGuildName);
			this.Controls.Add(this.btnServerPasswordGenerate);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.btnBrowseLocalBackupFolder);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.txtLocalBackupFolder);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.nudLocalBackupInterval);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.txtServerPassword);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.txtRemoteUploadUrl);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.nudRemoteUploadInterval);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.btnBrowseLocalLua);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtLuaPath);
			this.Controls.Add(this.nudHttpPort);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cbEnableWebServer);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "Configuration";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Configuration";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Configuration_FormClosing);
			this.Load += new System.EventHandler(this.Configuration_Load);
			((System.ComponentModel.ISupportInitialize)(this.nudHttpPort)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudRemoteUploadInterval)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudLocalBackupInterval)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckBox cbEnableWebServer;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown nudHttpPort;
		private System.Windows.Forms.TextBox txtLuaPath;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnBrowseLocalLua;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown nudRemoteUploadInterval;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtRemoteUploadUrl;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtServerPassword;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.NumericUpDown nudLocalBackupInterval;
		private System.Windows.Forms.Button btnBrowseLocalBackupFolder;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox txtLocalBackupFolder;
		private System.Windows.Forms.OpenFileDialog openFileDialog_LuaFile;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog_LocalBackups;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnServerPasswordGenerate;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox txtGuildName;
		private System.Windows.Forms.CheckBox cbAcceptUploads;
	}
}
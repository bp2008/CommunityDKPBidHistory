namespace IngestDKPFile
{
	partial class IngestDKPFile
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
			this.btnBrowseLocalLua = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.txtLuaPath = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.txtServerPassword = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.txtRemoteUploadUrl = new System.Windows.Forms.TextBox();
			this.btnUpload = new System.Windows.Forms.Button();
			this.openFileDialog_LuaFile = new System.Windows.Forms.OpenFileDialog();
			this.SuspendLayout();
			// 
			// btnBrowseLocalLua
			// 
			this.btnBrowseLocalLua.Location = new System.Drawing.Point(366, 38);
			this.btnBrowseLocalLua.Name = "btnBrowseLocalLua";
			this.btnBrowseLocalLua.Size = new System.Drawing.Size(75, 23);
			this.btnBrowseLocalLua.TabIndex = 8;
			this.btnBrowseLocalLua.Tag = "";
			this.btnBrowseLocalLua.Text = "Browse";
			this.btnBrowseLocalLua.UseVisualStyleBackColor = true;
			this.btnBrowseLocalLua.Click += new System.EventHandler(this.btnBrowseLocalLua_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 21);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(134, 13);
			this.label2.TabIndex = 7;
			this.label2.Tag = "";
			this.label2.Text = "Path to CommunityDKP.lua";
			// 
			// txtLuaPath
			// 
			this.txtLuaPath.Location = new System.Drawing.Point(12, 40);
			this.txtLuaPath.Name = "txtLuaPath";
			this.txtLuaPath.Size = new System.Drawing.Size(348, 20);
			this.txtLuaPath.TabIndex = 6;
			this.txtLuaPath.Tag = "";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(12, 128);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(90, 13);
			this.label7.TabIndex = 17;
			this.label7.Text = "Server Password:";
			// 
			// txtServerPassword
			// 
			this.txtServerPassword.Location = new System.Drawing.Point(108, 125);
			this.txtServerPassword.Name = "txtServerPassword";
			this.txtServerPassword.Size = new System.Drawing.Size(252, 20);
			this.txtServerPassword.TabIndex = 16;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(12, 102);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(69, 13);
			this.label6.TabIndex = 15;
			this.label6.Tag = "requiresNoWebServer";
			this.label6.Text = "Upload URL:";
			// 
			// txtRemoteUploadUrl
			// 
			this.txtRemoteUploadUrl.Location = new System.Drawing.Point(101, 99);
			this.txtRemoteUploadUrl.Name = "txtRemoteUploadUrl";
			this.txtRemoteUploadUrl.Size = new System.Drawing.Size(340, 20);
			this.txtRemoteUploadUrl.TabIndex = 14;
			this.txtRemoteUploadUrl.Tag = "requiresNoWebServer";
			this.txtRemoteUploadUrl.Text = "http://example.com/Upload";
			// 
			// btnUpload
			// 
			this.btnUpload.Location = new System.Drawing.Point(118, 180);
			this.btnUpload.Name = "btnUpload";
			this.btnUpload.Size = new System.Drawing.Size(147, 43);
			this.btnUpload.TabIndex = 18;
			this.btnUpload.Text = "Upload";
			this.btnUpload.UseVisualStyleBackColor = true;
			this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
			// 
			// openFileDialog_LuaFile
			// 
			this.openFileDialog_LuaFile.DefaultExt = "lua";
			this.openFileDialog_LuaFile.FileName = "CommunityDKP.lua";
			this.openFileDialog_LuaFile.Filter = "Lua files|*.lua";
			// 
			// IngestDKPFile
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(461, 243);
			this.Controls.Add(this.btnUpload);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.txtServerPassword);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.txtRemoteUploadUrl);
			this.Controls.Add(this.btnBrowseLocalLua);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtLuaPath);
			this.Name = "IngestDKPFile";
			this.Text = "Manually Ingest DKP file";
			this.Load += new System.EventHandler(this.IngestDKPFile_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnBrowseLocalLua;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtLuaPath;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtServerPassword;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtRemoteUploadUrl;
		private System.Windows.Forms.Button btnUpload;
		private System.Windows.Forms.OpenFileDialog openFileDialog_LuaFile;
	}
}


using BPUtil;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IngestDKPFile
{
	public partial class IngestDKPFile : Form
	{
		public IngestDKPFile()
		{
			InitializeComponent();
		}

		private void IngestDKPFile_Load(object sender, EventArgs e)
		{

		}

		private void btnUpload_Click(object sender, EventArgs e)
		{
			if (File.Exists(txtLuaPath.Text))
			{
				WebRequestUtility remoteUploadUtility = new WebRequestUtility("DKPHistory Client", 10000);

				try
				{
					if (Uri.TryCreate(txtRemoteUploadUrl.Text, UriKind.Absolute, out Uri uri))
					{
						if (!uri.Host.Equals("example.com", StringComparison.OrdinalIgnoreCase))
						{
							byte[] fileContent = File.ReadAllBytes(txtLuaPath.Text);
							string authString = GenerateAuthString();
							BpWebResponse response = remoteUploadUtility.POST(uri.OriginalString, fileContent, "application/octet-stream", new string[] { "X-Dkp-Auth", authString });
							if (response.StatusCode == 200 && response.str.StartsWith("1"))
							{
								// Upload complete
								MessageBox.Show("Upload Complete");
							}
							else
							{
								MessageBox.Show("Unable to upload lua file to remote server. Response status: " + response.StatusCode + ", Response body: " + response.str);
							}
						}
					}
					else
					{
						MessageBox.Show("Unable to parse remote upload URL. Check configuration.");
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.ToString());
				}
			}
			else
				MessageBox.Show("Lua file not found.");
		}
		private string GenerateAuthString(int dayOffset = 0)
		{
			DateTime now = DateTime.UtcNow.AddDays(dayOffset);
			string stringToHash = txtServerPassword.Text + now.Year + now.Month.ToString().PadLeft(2, '0') + now.Day.ToString().PadLeft(2, '0');
			return Hash.GetSHA256Hex(stringToHash);
		}

		private void btnBrowseLocalLua_Click(object sender, EventArgs e)
		{
			DialogResult dr = openFileDialog_LuaFile.ShowDialog();
			if (dr == DialogResult.OK)
				txtLuaPath.Text = openFileDialog_LuaFile.FileName;
		}
	}
}

using BPUtil;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MonolithDKPBidHistory
{
	public partial class DKPHistory : ServiceBase
	{
		public static Settings settings; // Initialized after construction by BPUtil.AppInit
		private WebServer webServer;
		private Thread thrFileManagement;
		private EventWaitHandle ewhThreadWaiter = new EventWaitHandle(false, EventResetMode.ManualReset);
		private static string luaFileContents = null;
		/// <summary>
		/// Lock this when accessing the MonolithDKP.lua file.
		/// </summary>
		public static object LuaFileLock = new object();

		/// <summary>
		/// Gets cached lua file contents from memory from the last time the file was read.
		/// </summary>
		/// <returns></returns>
		public static string GetLuaFileContents()
		{
			return luaFileContents;
		}
		public DKPHistory()
		{
			InitializeComponent();
		}

		protected override void OnStart(string[] args)
		{
			if (settings.enableWebServer)
			{
				webServer = new WebServer(settings.httpPort);
				webServer.Start();
			}

			thrFileManagement = new Thread(fileManagement);
			thrFileManagement.IsBackground = false;
			thrFileManagement.Name = "File Management";
			thrFileManagement.Start();
		}

		protected override void OnStop()
		{
			if (settings.enableWebServer)
				webServer?.Stop();
			ewhThreadWaiter.Set();
			thrFileManagement.Join();
		}
		private void fileManagement()
		{
			try
			{
				string localLuaPath = Globals.WritableDirectoryBase + "MonolithDKP.lua";
				long minutesWaited = 0;
				DateTime lastFileWrite = DateTime.MinValue;
				long lastLocalBackupMinutes = -99999999;
				long lastRemoteUploadMinutes = -99999999;
				bool needsLocalBackup = false;
				bool needsRemoteUpload = false;
				string previousHash = null;
				bool firstRun = true;
				WebRequestUtility remoteUploadUtility = new WebRequestUtility("DKPHistory Client", 10000);

				while (firstRun || !ewhThreadWaiter.WaitOne(60000))
				{
					firstRun = false;
					minutesWaited++;

					string hash = null;
					bool fileChanged = false;

					if (string.IsNullOrWhiteSpace(settings.luaFilePath))
						continue;

					// Make local copy of file
					try
					{
						lock (LuaFileLock)
						{
							FileInfo fiSrc = new FileInfo(settings.luaFilePath);
							if (!fiSrc.Exists)
							{
								Logger.Info("Could not find MonolithDKP.lua. Check configuration.");
								continue;
							}
							if (lastFileWrite != fiSrc.LastWriteTimeUtc)
							{
								lastFileWrite = fiSrc.LastWriteTimeUtc;
								File.Copy(fiSrc.FullName, localLuaPath, true);
								// Read file
								luaFileContents = File.ReadAllText(localLuaPath);

								// Calculate Hash Code
								hash = Hash.GetMD5HexOfFile(localLuaPath);
								fileChanged = previousHash != hash;
								previousHash = hash;
								needsLocalBackup = needsLocalBackup || fileChanged;
								needsRemoteUpload = needsRemoteUpload || fileChanged;
							}
						}
					}
					catch (Exception ex)
					{
						Logger.Debug(ex, "Error doing local file management.");
						continue;
					}

					// Make local backup of lua file
					if (needsLocalBackup
						&& !string.IsNullOrWhiteSpace(settings.localBackupPath)
						&& settings.localBackupIntervalMinutes > 0
						&& minutesWaited - lastLocalBackupMinutes >= settings.localBackupIntervalMinutes)
					{
						lastLocalBackupMinutes = minutesWaited;
						needsLocalBackup = false;
						try
						{
							if (!Directory.Exists(settings.localBackupPath))
								Directory.CreateDirectory(settings.localBackupPath);
							if (Directory.Exists(settings.localBackupPath))
							{
								DateTime fileTime = File.GetLastWriteTime(localLuaPath);
								string bkFileName = Path.Combine(settings.localBackupPath, "MonolithDKP-" + fileTime.ToString("yyyy-MM-dd hh-mm-ss") + ".lua");
								if (!File.Exists(bkFileName))
									File.Copy(localLuaPath, bkFileName, true);
								// Backup complete
							}
							else
							{
								Logger.Info("Could not find or create local backup path. Check configuration.");
							}
						}
						catch (Exception ex)
						{
							Logger.Debug(ex, "Error doing local backup.");
						}
					}

					// Perform remote upload of lua file
					if (needsRemoteUpload
						&& !string.IsNullOrWhiteSpace(settings.remoteUploadUrl)
						&& settings.remoteUploadIntervalMinutes > 0
						&& minutesWaited - lastRemoteUploadMinutes >= settings.remoteUploadIntervalMinutes)
					{
						needsRemoteUpload = false;
						lastRemoteUploadMinutes = minutesWaited;
						try
						{
							if (Uri.TryCreate(settings.remoteUploadUrl, UriKind.Absolute, out Uri uri))
							{
								if (!uri.Host.Equals("example.com", StringComparison.OrdinalIgnoreCase))
								{
									byte[] fileContent = File.ReadAllBytes(localLuaPath);
									string authString = GenerateAuthString();
									BpWebResponse response = remoteUploadUtility.POST(settings.remoteUploadUrl, fileContent, "application/octet-stream", new string[] { "X-Dkp-Auth", authString });
									if (response.StatusCode == 200 && response.str.StartsWith("1"))
									{
										// Upload complete
									}
									else
									{
										Logger.Info("Unable to upload lua file to remote server. Response status: " + response.StatusCode + ", Response body: " + response.str);
									}
								}
							}
							else
							{
								Logger.Info("Unable to parse remote upload URL. Check configuration.");
							}
						}
						catch (Exception ex)
						{
							Logger.Debug(ex, "Error doing remote upload.");
						}
					}
				}
			}
			catch (Exception ex)
			{
				Logger.Debug(ex, "File management thread suffered a critical failure!");
			}
		}

		private static string GenerateAuthString(int dayOffset = 0)
		{
			if (string.IsNullOrWhiteSpace(settings.serverPassword))
				throw new Exception("Server password was not set.");
			DateTime now = DateTime.UtcNow.AddDays(dayOffset);
			string stringToHash = settings.serverPassword + now.Year + now.Month.ToString().PadLeft(2, '0') + now.Day.ToString().PadLeft(2, '0');
			return Hash.GetSHA256Hex(stringToHash);
		}
		public static bool VerifyAuthString(string authString)
		{
			return authString == GenerateAuthString(0) || authString == GenerateAuthString(1) || authString == GenerateAuthString(-1);
		}
	}
}

using BPUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityDKPBidHistory
{
	public class Settings : SerializableObjectBase
	{
		public string guildName = "";
		public bool enableWebServer = false;
		public int httpPort = 80;

		/// <summary>
		/// Path to CommunityDKP.lua
		/// </summary>
		public string luaFilePath = "";

		/// <summary>
		/// [0 to disable] Every N minutes, hash check CommunityDKP.lua and upload to the remote server if contents have changed.
		/// </summary>
		public int remoteUploadIntervalMinutes = 0;
		/// <summary>
		/// Remote server URL to upload file to.
		/// </summary>
		public string remoteUploadUrl = "";
		/// <summary>
		/// If true, CommunityDKP.lua uploads from authenticated remote clients will be written to luaFilePath.
		/// </summary>
		public bool receiveUploads = false;
		/// <summary>
		/// Server password must match on local and remote server or else remote uploads will not work.
		/// </summary>
		public string serverPassword = "";

		/// <summary>
		/// [0 to disable] Every N minutes, save a backup of CommunityDKP.lua to this location if contents have changed.
		/// </summary>
		public int localBackupIntervalMinutes = 0;
		/// <summary>
		/// Path of a folder to save local backups in. If null or empty, a location is chosen automatically.
		/// </summary>
		public string localBackupPath = "";
	}
}

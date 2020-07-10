using System;

namespace CommunityDKPBidHistory
{
	public class LootItem
	{
		public int itemid; // wow classic item ID
		public string name;
		public string player;
		public string zone;
		public long date; // Unix epoch time in seconds
		public int cost;
		public string boss;
		public string color = "dddddd"; // hex color of item name

		/// <summary>
		/// Gets a string which uniquely identifies this loot item.
		/// </summary>
		/// <returns></returns>
		public string GetLootId()
		{
			return date + "|" + itemid + "|" + cost + "|" + player;
		}
	}
}

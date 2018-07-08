using Breakout.Core.Models.Maps;
using Breakout.Core.Utilities.Map;
using System.Collections.Generic;
using System.Linq;

namespace Breakout.Core.Models
{
	public struct MapInfo
	{
		public int Level { get; set; }
		public string Name { get; set; }
		public int ScoreFor2Star { get; set; }
		public int ScoreFor3Star { get; set; }

		public MapInfo(int level, string name, int scoreFor2Star, int scoreFor3Star)
		{
			Level = level;
			Name = name;
			ScoreFor2Star = scoreFor2Star;
			ScoreFor3Star = scoreFor3Star;
		}
	}

	internal static class MapManager
	{
		// 45 x 18
		public static readonly List<MapInfo> Maps = new List<MapInfo>()
		{
			new MapInfo (0, "Menu", 0, 0),
			//new MapInfo (1, "Flashing", 0, 0),

			//new MapInfo (1, "Quick", 0, 0),
			new MapInfo (1, "Minecraft", 30000, 40000), //
			new MapInfo (2, "Friendzone", 50000, 56000), //
			new MapInfo (3, "Bird", 52000, 60000),
			new MapInfo (4, "Poop", 51000, 61000),
			new MapInfo (5, "Whale", 53000, 63000),
			new MapInfo (6, "Classic", 111000, 120000), //
			new MapInfo (7, "Tank", 111000, 120000),
			new MapInfo (8, "Mario", 111000, 120000),
			new MapInfo (9, "Fastfood", 111000, 120000),
			new MapInfo (10, "Minions", 111000, 120000),

			// new MapInfo (1, "Quick2", 0, 0),
		};

		public static BlockMap Load(int lvlNumber)
		{
			var mapName = Maps.Where(m => m.Level == lvlNumber).Select(m => m.Name).First();

			return MapLoader.Load(mapName);
		}

		public static bool CanNextLevel(int level)
		{
			if (level >= Maps.Count - 1) // Minus Menu Stage
				return false;

			return true;
		}
	}
}

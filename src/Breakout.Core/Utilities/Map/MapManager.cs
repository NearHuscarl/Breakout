using Breakout.Core.Models.Maps;
using Breakout.Pipeline.TiledMap;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;

namespace Breakout.Core.Utilities.Map
{
	internal static class MapManager
	{
		// 45 x 16
		private static readonly string mapPath = "Maps/";
		private static ContentManager content;
		private static BlockMapReader blockMapReader;

		#region Stages

		public static readonly Dictionary<int, string> Stages = new Dictionary<int, string>()
		{
			{ 0, "Menu" },
			{ 1, "Classic" },
			{ 2, "Bird" },
			{ 3, "Minecraft" },
			{ 4, "Shit" },
			{ 5, "Mario" },
			{ 6, "Whale" },
			{ 7, "Friendzone" },
			{ 8, "Tank" },
			{ 9, "Minions" },
			{ 10, "Fastfood" },

			//{ 1, "Quick" },
			//{ 2, "Quick2" },
			//{ 3, "Mario" },
		};

		#endregion
		
		public static void Initialize(ContentManager content)
		{
			MapManager.content = content;
			MapManager.blockMapReader = new BlockMapReader();
		}

		public static BlockMap Load(int levelNumber)
		{
			TiledMap tiledMap = content.Load<TiledMap>(mapPath + Stages[levelNumber]);

			return blockMapReader.LoadGameObjects(tiledMap);
		}

		public static bool CanNextLevel(int level)
		{
			if (level >= Stages.Count - 1) // Minus Menu Stage
				return false;

			return true;
		}
	}
}

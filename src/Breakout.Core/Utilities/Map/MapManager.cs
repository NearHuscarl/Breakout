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
			{ 1, "Quick" },
			{ 2, "Quick2" },
			{ 3, "Mario" },
			// { 4, "Mario" },
			// { 5, "Mario" },
			// { 6, "Mario" },
			// { 7, "Mario" },
			// { 8, "Mario" },
			// { 9, "Mario" },
			// { 10, "Mario" },
			// { 11, "Mario" },
			// { 12, "Mario" },
			// { 13, "Mario" },
			// { 14, "Mario" },
			// { 15, "Mario" },
			// { 16, "Mario" },
			// { 17, "Mario" },
			// { 18, "Mario" },
			// { 19, "Mario" },
			// { 20, "Mario" },
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

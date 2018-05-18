using Breakout.Extensions;
using Breakout.Models.Bases;
using Breakout.Models.Blocks;
using Breakout.Models.Enums;
using Microsoft.Xna.Framework;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Models.Maps
{
	public static class MapManager
	{
		private static readonly string mapDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "maps");

		public static readonly Dictionary<string, BlockType> BlockMap = new Dictionary<string, BlockType>()
		{
			{ "_", BlockType.None },
			{ "x", BlockType.Skeleton },

			{ "0", BlockType.Black },
			{ "2", BlockType.Gray },
			{ "C", BlockType.Cyan },
			{ "G", BlockType.Green },
			{ "B", BlockType.Blue },
			{ "M", BlockType.Magenta },
			{ "Y", BlockType.Yellow },
			{ "O", BlockType.Orange },
			{ "R", BlockType.Red },

			{ "1", BlockType.Dark },
			{ "3", BlockType.LightGray },
			{ "c", BlockType.LightCyan },
			{ "g", BlockType.LightGreen },
			{ "b", BlockType.LightBlue },
			{ "m", BlockType.LightMagenta },
			{ "y", BlockType.LightYellow },
			{ "o", BlockType.LightOrange },
			{ "r", BlockType.LightRed },

			{ "f0", BlockType.FlashingBlack },
			{ "f2", BlockType.FlashingGray },
			{ "fc", BlockType.FlashingCyan },
			{ "fg", BlockType.FlashingGreen },
			{ "fb", BlockType.FlashingBlue },
			{ "fm", BlockType.FlashingMagenta },
			{ "fy", BlockType.FlashingYellow },
			{ "fo", BlockType.FlashingOrange },
			{ "fr", BlockType.FlashingRed },

			{ "4", BlockType.None },
			{ "5", BlockType.None },
		};

		public static MapMatrix Logo { get; set; } = new MapMatrix()
		{
			Layer1 = new List<List<string>> ()
			{
				new List<string> { "r", "r", "r", "5", "5", "o", "o", "o", "5", "5", "y", "y", "y", "5", "5", "5", "g", "5", "5", "5", "b", "5", "5", "b", "5", "m", "m", "m", "m", "5", "1", "5", "5", "1", "5", "2", "2", "2", "2", "2" },
      		new List<string> { "r", "5", "5", "r", "5", "o", "5", "5", "o", "5", "y", "5", "5", "5", "5", "g", "g", "g", "5", "5", "b", "5", "5", "b", "5", "m", "5", "5", "m", "5", "1", "5", "5", "1", "5", "5", "5", "2", "5", "5" },
      		new List<string> { "r", "5", "5", "r", "5", "o", "5", "5", "o", "5", "y", "5", "5", "5", "5", "g", "5", "g", "5", "5", "b", "5", "b", "5", "5", "m", "5", "5", "m", "5", "1", "5", "5", "1", "5", "5", "5", "2", "5", "5" },
      		new List<string> { "r", "5", "5", "r", "5", "o", "5", "o", "5", "5", "y", "5", "5", "5", "5", "g", "5", "g", "5", "5", "b", "5", "b", "5", "5", "m", "5", "5", "m", "5", "1", "5", "5", "1", "5", "5", "5", "2", "5", "5" },
      		new List<string> { "r", "r", "r", "5", "5", "o", "o", "5", "5", "5", "y", "y", "y", "5", "5", "g", "g", "g", "5", "5", "b", "b", "5", "5", "5", "m", "5", "5", "m", "5", "1", "5", "5", "1", "5", "5", "5", "2", "5", "5" },
      		new List<string> { "r", "5", "5", "r", "5", "o", "5", "o", "5", "5", "y", "5", "5", "5", "g", "g", "5", "g", "g", "5", "b", "5", "b", "5", "5", "m", "5", "5", "m", "5", "1", "5", "5", "1", "5", "5", "5", "2", "5", "5" },
      		new List<string> { "r", "5", "5", "r", "5", "o", "5", "5", "o", "5", "y", "5", "5", "5", "g", "5", "5", "5", "g", "5", "b", "5", "b", "5", "5", "m", "5", "5", "m", "5", "1", "5", "5", "1", "5", "5", "5", "2", "5", "5" },
      		new List<string> { "r", "5", "5", "r", "5", "o", "5", "5", "o", "5", "y", "5", "5", "5", "g", "5", "5", "5", "g", "5", "b", "5", "5", "b", "5", "m", "5", "5", "m", "5", "1", "5", "5", "1", "5", "5", "5", "2", "5", "5" },
      		new List<string> { "r", "r", "r", "5", "5", "o", "5", "5", "o", "5", "y", "y", "y", "5", "g", "5", "5", "5", "g", "5", "b", "5", "5", "b", "5", "m", "m", "m", "m", "5", "1", "1", "1", "1", "5", "5", "5", "2", "5", "5" },
			},

			Layer0 = new List<List<string>>()
			{
				new List<string> { "x", "x", "x", "_", "_", "x", "x", "x", "_", "_", "x", "x", "x", "_", "_", "_", "x", "_", "_", "_", "x", "_", "_", "x", "_", "x", "x", "x", "x", "_", "x", "_", "_", "x", "_", "x", "x", "x", "x", "x" },
				new List<string> { "x", "_", "_", "x", "_", "x", "_", "_", "x", "_", "x", "_", "_", "_", "_", "x", "x", "x", "_", "_", "x", "_", "_", "x", "_", "x", "_", "_", "x", "_", "x", "_", "_", "x", "_", "_", "_", "x", "_", "_" },
				new List<string> { "x", "_", "_", "x", "_", "x", "_", "_", "x", "_", "x", "_", "_", "_", "_", "x", "_", "x", "_", "_", "x", "_", "x", "_", "_", "x", "_", "_", "x", "_", "x", "_", "_", "x", "_", "_", "_", "x", "_", "_" },
				new List<string> { "x", "_", "_", "x", "_", "x", "_", "x", "_", "_", "x", "_", "_", "_", "_", "x", "_", "x", "_", "_", "x", "_", "x", "_", "_", "x", "_", "_", "x", "_", "x", "_", "_", "x", "_", "_", "_", "x", "_", "_" },
				new List<string> { "x", "x", "x", "_", "_", "x", "x", "_", "_", "_", "x", "x", "x", "_", "_", "x", "x", "x", "_", "_", "x", "x", "_", "_", "_", "x", "_", "_", "x", "_", "x", "_", "_", "x", "_", "_", "_", "x", "_", "_" },
				new List<string> { "x", "_", "_", "x", "_", "x", "_", "x", "_", "_", "x", "_", "_", "_", "x", "x", "_", "x", "x", "_", "x", "_", "x", "_", "_", "x", "_", "_", "x", "_", "x", "_", "_", "x", "_", "_", "_", "x", "_", "_" },
				new List<string> { "x", "_", "_", "x", "_", "x", "_", "_", "x", "_", "x", "_", "_", "_", "x", "_", "_", "_", "x", "_", "x", "_", "x", "_", "_", "x", "_", "_", "x", "_", "x", "_", "_", "x", "_", "_", "_", "x", "_", "_" },
				new List<string> { "x", "_", "_", "x", "_", "x", "_", "_", "x", "_", "x", "_", "_", "_", "x", "_", "_", "_", "x", "_", "x", "_", "_", "x", "_", "x", "_", "_", "x", "_", "x", "_", "_", "x", "_", "_", "_", "x", "_", "_" },
				new List<string> { "x", "x", "x", "_", "_", "x", "_", "_", "x", "_", "x", "x", "x", "_", "x", "_", "_", "_", "x", "_", "x", "_", "_", "x", "_", "x", "x", "x", "x", "_", "x", "x", "x", "x", "_", "_", "_", "x", "_", "_" },
			}
		};

		// 45 x 16
		public static MapMatrix CurrentMap { get; set; }

		private static MapMatrix LoadMapFile(string mapName)
		{
			string mapPath = Path.Combine(mapDir, mapName + ".json");
			string jsonStr = File.ReadAllText(mapPath);

			return JsonConvert.DeserializeObject<MapMatrix>(jsonStr);
		}

		private static Map LoadGameObjects(MapMatrix matrix)
		{
			int mapWidth = matrix.Layer1[0].Count * SpriteInfo.BlockWidth;
			int mapHeight = matrix.Layer1.Count * SpriteInfo.BlockHeight;

			Vector2 mapEntryPosition = new Vector2()
			{
				X = GameInfo.Screen.Width / 2 - mapWidth / 2,
				Y = SpriteInfo.BlockWidth * 1,
			};

			List<GameObject> layer0 = new List<GameObject>();
			List<Block> layer1 = new List<Block>();

			for (int r = 1; mapEntryPosition.Y + r * SpriteInfo.BlockHeight <= mapEntryPosition.Y + mapHeight; r++)
			{
				for (int c = 1; mapEntryPosition.X + c * SpriteInfo.BlockWidth <= mapEntryPosition.X + mapWidth; c++)
				{
					BlockType type0 = BlockMap[matrix.Layer0[r - 1][c - 1]];
					BlockType type1 = BlockMap[matrix.Layer1[r - 1][c - 1]];

					float x = mapEntryPosition.X + c * SpriteInfo.BlockWidth - c; // Make border of blocks overlap each other
					float y = mapEntryPosition.Y + r * SpriteInfo.BlockHeight - r;

					layer0.AddIfNotNull(ModelFactory.CreateSkeletonBlock(type0, new Vector2(x, y)));
					layer1.AddIfNotNull(ModelFactory.CreateBlock(type1, new Vector2(x, y)));
				}
			}

			return new Map()
			{
				Layer0 = layer0,
				Layer1 = layer1,
			};
		}

		public static Map LoadMap(string mapName)
		{
			CurrentMap = LoadMapFile(mapName);

			return LoadGameObjects(CurrentMap);
		}

		public static Map LoadLogo()
		{
			return LoadGameObjects(Logo);
		}
	}
}

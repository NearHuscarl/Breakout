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

		public static Map Logo { get; set; } = new Map()
		{
			Matrix = new List<List<string>> ()
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
		};

		// 45 x 16
		public static Map CurrentMap { get; set; }

		private static Map LoadMapFile(string mapName)
		{
			string mapPath = Path.Combine(mapDir, mapName + ".json");
			string jsonStr = File.ReadAllText(mapPath);

			return JsonConvert.DeserializeObject<Map>(jsonStr);
		}

		private static List<Block> Matrix2Blocks(Map map)
		{
			int mapWidth = map.Matrix[0].Count * GameInfo.BlockWidth;
			int mapHeight = map.Matrix.Count * GameInfo.BlockHeight;

			Vector2 mapEntryPosition = new Vector2()
			{
				X = GameInfo.Screen.Width / 2 - mapWidth / 2,
				Y = GameInfo.BlockWidth * 1,
			};

			List<Block> blocks = new List<Block>();

			for (int r = 1; mapEntryPosition.Y + r * GameInfo.BlockHeight <= mapEntryPosition.Y + mapHeight; r++)
			{
				for (int c = 1; mapEntryPosition.X + c * GameInfo.BlockWidth <= mapEntryPosition.X + mapWidth; c++)
				{
					BlockType blockType = BlockMap[map.Matrix[r - 1][c - 1]];

					if (blockType == BlockType.None)
						continue;

					float x = mapEntryPosition.X + c * GameInfo.BlockWidth - c; // Make border of blocks overlap each other
					float y = mapEntryPosition.Y + r * GameInfo.BlockHeight - r;

					Block newBlock = ModelFactory.CreateBlock(blockType, new Vector2(x, y));

					blocks.Add(newBlock);
				}
			}

			return blocks;
		}

		public static List<Block> LoadMap(string mapName)
		{
			CurrentMap = LoadMapFile(mapName);

			return Matrix2Blocks(CurrentMap);
		}

		public static List<Block> LoadLogo()
		{
			return Matrix2Blocks(Logo);
		}
	}
}

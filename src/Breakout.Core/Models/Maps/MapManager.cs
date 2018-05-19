using Breakout.Core.Models.Bases;
using Breakout.Core.Models.Blocks;
using Breakout.Core.Models.Enums;
using Breakout.Extensions;
using Breakout.Pipeline.TiledMap;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;

namespace Breakout.Core.Models.Maps
{
	public static class MapManager
	{
		// 45 x 16

		public static readonly Dictionary<string, BlockType> StrToBlock = new Dictionary<string, BlockType>()
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

		public static BlockMap LoadGameObjects(TiledMap matrix)
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
					BlockType type0 = StrToBlock[matrix.Layer0[r - 1][c - 1]];
					BlockType type1 = StrToBlock[matrix.Layer1[r - 1][c - 1]];

					float x = mapEntryPosition.X + c * SpriteInfo.BlockWidth - c; // Make border of blocks overlap each other
					float y = mapEntryPosition.Y + r * SpriteInfo.BlockHeight - r;

					layer0.AddIfNotNull(ModelFactory.CreateSkeletonBlock(type0, new Vector2(x, y)));
					layer1.AddIfNotNull(ModelFactory.CreateBlock(type1, new Vector2(x, y)));
				}
			}

			return new BlockMap()
			{
				Layer0 = layer0,
				Layer1 = layer1,
			};
		}
	}
}

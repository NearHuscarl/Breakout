using Breakout.Core.Models;
using Breakout.Core.Models.Bases;
using Breakout.Core.Models.Blocks;
using Breakout.Core.Models.Enums;
using Breakout.Core.Models.Maps;
using Breakout.Extensions;
using Breakout.Pipeline.TiledMap;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Breakout.Core.Utilities.Map
{
	public class BlockMapReader
	{
		public static readonly Dictionary<string, BlockType> StrToBlock = new Dictionary<string, BlockType>()
		{
			{ "_", BlockType.None },
			{ "x", BlockType.Skeleton },

			{ "0", BlockType.Black },
			{ "2", BlockType.Gray },
			{ "4", BlockType.Silver },
			{ "C", BlockType.Cyan },
			{ "G", BlockType.Green },
			{ "B", BlockType.Blue },
			{ "M", BlockType.Magenta },
			{ "Y", BlockType.Yellow },
			{ "O", BlockType.Orange },
			{ "R", BlockType.Red },

			{ "1", BlockType.Dark },
			{ "3", BlockType.LightGray },
			{ "5", BlockType.White },
			{ "c", BlockType.LightCyan },
			{ "g", BlockType.LightGreen },
			{ "b", BlockType.LightBlue },
			{ "m", BlockType.LightMagenta },
			{ "y", BlockType.LightYellow },
			{ "o", BlockType.LightOrange },
			{ "r", BlockType.LightRed },

			{ "f0", BlockType.FlashingBlack },
			{ "f2", BlockType.FlashingGray },
			{ "f4", BlockType.FlashingWhite },
			{ "fc", BlockType.FlashingCyan },
			{ "fg", BlockType.FlashingGreen },
			{ "fb", BlockType.FlashingBlue },
			{ "fm", BlockType.FlashingMagenta },
			{ "fy", BlockType.FlashingYellow },
			{ "fo", BlockType.FlashingOrange },
			{ "fr", BlockType.FlashingRed },
		};

		public BlockMap LoadGameObjects(TiledMap matrix)
		{
			int mapWidth = matrix.Layer1[0].Count * SpriteData.BlockWidth;
			int mapHeight = matrix.Layer1.Count * SpriteData.BlockHeight;

			Vector2 mapEntryPosition = new Vector2()
			{
				X = GlobalData.Screen.Width / 2 - mapWidth / 2,
				Y = SpriteData.BlockWidth * 1,
			};

			List<GameObject> layer0 = new List<GameObject>();
			List<Block> layer1 = new List<Block>();

			for (int r = 1; mapEntryPosition.Y + r * SpriteData.BlockHeight <= mapEntryPosition.Y + mapHeight; r++)
			{
				for (int c = 1; mapEntryPosition.X + c * SpriteData.BlockWidth <= mapEntryPosition.X + mapWidth; c++)
				{
					BlockType type0 = StrToBlock[matrix.Layer0[r - 1][c - 1]];
					BlockType type1 = StrToBlock[matrix.Layer1[r - 1][c - 1]];

					float x = mapEntryPosition.X + c * SpriteData.BlockWidth - c; // Make border of blocks overlap each other
					float y = mapEntryPosition.Y + r * SpriteData.BlockHeight - r;

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

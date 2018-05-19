using Breakout.Core.Models.Enums;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Core.Models.Blocks
{
	public static class BlockInfo
	{
		public struct BlockAtrributes
		{
			public int Health;
			public int PowerUpChance;
			public GameColor Color;

			private static BlockAtrributes emptyAttributes = new BlockAtrributes(0, 0, GameColor.None);

			public static BlockAtrributes Empty { get { return emptyAttributes; } }

			public BlockAtrributes(int health, int powerUpChance, GameColor color)
			{
				Health = health;
				PowerUpChance = powerUpChance;
				Color = color;
			}
		}

		public static Dictionary<BlockType, BlockAtrributes> Attributes = new Dictionary<BlockType, BlockAtrributes>()
		{
			{ BlockType.Red,     new BlockAtrributes(health: 10, powerUpChance: 30, color: GameColor.Red) },
			{ BlockType.Orange,  new BlockAtrributes(health: 60, powerUpChance: 20, color: GameColor.Orange) },
			{ BlockType.Yellow,  new BlockAtrributes(health: 50, powerUpChance: 15, color: GameColor.Yellow) },
			{ BlockType.Green,   new BlockAtrributes(health: 40, powerUpChance: 10, color: GameColor.Green) },
			{ BlockType.Blue,    new BlockAtrributes(health: 30, powerUpChance:  8, color: GameColor.Blue) },
			{ BlockType.Cyan,    new BlockAtrributes(health: 20, powerUpChance:  5, color: GameColor.Cyan) },
			{ BlockType.Magenta, new BlockAtrributes(health: 10, powerUpChance:  2, color: GameColor.Magenta) },
			{ BlockType.Gray,    new BlockAtrributes(health: 80, powerUpChance:  0, color: GameColor.Gray) },
			{ BlockType.Black,   new BlockAtrributes(health: 90, powerUpChance:  0, color: GameColor.Black) },

			{ BlockType.LightRed,     new BlockAtrributes(health: 10, powerUpChance: 30, color: GameColor.Red) },
			{ BlockType.LightOrange,  new BlockAtrributes(health: 60, powerUpChance: 20, color: GameColor.Orange) },
			{ BlockType.LightYellow,  new BlockAtrributes(health: 50, powerUpChance: 15, color: GameColor.Yellow) },
			{ BlockType.LightGreen,   new BlockAtrributes(health: 40, powerUpChance: 10, color: GameColor.Green) },
			{ BlockType.LightBlue,    new BlockAtrributes(health: 30, powerUpChance:  8, color: GameColor.Blue) },
			{ BlockType.LightCyan,    new BlockAtrributes(health: 20, powerUpChance:  5, color: GameColor.Cyan) },
			{ BlockType.LightMagenta, new BlockAtrributes(health: 10, powerUpChance:  2, color: GameColor.Magenta) },
			{ BlockType.LightGray,    new BlockAtrributes(health: 80, powerUpChance:  0, color: GameColor.Gray) },
			{ BlockType.Dark,         new BlockAtrributes(health: 90, powerUpChance:  0, color: GameColor.Black) },

			 // One hit, blow up surrounding when hit
			{ BlockType.FlashingRed,     new BlockAtrributes(health: 1, powerUpChance: 1, color: GameColor.Red) },
			{ BlockType.FlashingOrange,  new BlockAtrributes(health: 1, powerUpChance: 1, color: GameColor.Orange) },
			{ BlockType.FlashingYellow,  new BlockAtrributes(health: 1, powerUpChance: 1, color: GameColor.Yellow) },
			{ BlockType.FlashingGreen,   new BlockAtrributes(health: 1, powerUpChance: 1, color: GameColor.Green) },
			{ BlockType.FlashingBlue,    new BlockAtrributes(health: 1, powerUpChance: 1, color: GameColor.Blue) },
			{ BlockType.FlashingCyan,    new BlockAtrributes(health: 1, powerUpChance: 1, color: GameColor.Cyan) },
			{ BlockType.FlashingMagenta, new BlockAtrributes(health: 1, powerUpChance: 1, color: GameColor.Magenta) },
			{ BlockType.FlashingGray,    new BlockAtrributes(health: 1, powerUpChance: 1, color: GameColor.Gray) },
			{ BlockType.FlashingBlack,   new BlockAtrributes(health: 1, powerUpChance: 1, color: GameColor.Black) },

			{ BlockType.Skeleton, BlockAtrributes.Empty },
			{ BlockType.None, BlockAtrributes.Empty },
		};

		public static bool IsLight(BlockType blockType)
		{
			if (blockType.ToString().StartsWith("Light") || blockType.ToString() == "Dark")
				return true;

			return false;
		}

		public static bool IsFlashing(BlockType blockType)
		{
			if (blockType.ToString().StartsWith("Flashing"))
				return true;

			return false;
		}
	}
}

using Breakout.Models.Enums;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Models.Blocks
{
	public static class BlockInfo
	{
		public static Dictionary<BlockType, int> Health = new Dictionary<BlockType, int>()
		{
			{ BlockType.Red, 10 }, // One hit, make ball faster
			{ BlockType.Orange, 60 }, // Hardest block, 5 hits
			{ BlockType.Yellow, 50 },
			{ BlockType.Green, 40 },
			{ BlockType.Blue, 30 },
			{ BlockType.Cyan, 20 },
			{ BlockType.Magenta, 10 }, // Weakest Block, 1 hit
			{ BlockType.Gray, 80 },
			{ BlockType.Black, 100 },

			{ BlockType.LightRed, 10 },
			{ BlockType.LightOrange, 60 },
			{ BlockType.LightYellow, 50 },
			{ BlockType.LightGreen, 40 },
			{ BlockType.LightBlue, 30 },
			{ BlockType.LightCyan, 20 },
			{ BlockType.LightMagenta, 10 },
			{ BlockType.LightGray, 80 },
			{ BlockType.Dark, 100 },

			 // One hit, blow up surrounding when hit
			{ BlockType.FlashingRed, 1 },
			{ BlockType.FlashingOrange, 1 },
			{ BlockType.FlashingYellow, 1 },
			{ BlockType.FlashingGreen, 1 },
			{ BlockType.FlashingBlue, 1 },
			{ BlockType.FlashingCyan, 1 },
			{ BlockType.FlashingMagenta, 1 },
			{ BlockType.FlashingGray, 1 },
			{ BlockType.FlashingBlack, 1 },

			{ BlockType.None, 0 },
		};

		public static Dictionary<BlockType, int> PowerUpSpawnChance = new Dictionary<BlockType, int>()
		{
			{ BlockType.Red, 30 },
			{ BlockType.Orange, 20 },
			{ BlockType.Yellow, 15 },
			{ BlockType.Green, 10 },
			{ BlockType.Blue, 8 },
			{ BlockType.Cyan, 5 },
			{ BlockType.Magenta, 2 },
			{ BlockType.Gray, 0 },
			{ BlockType.Black, 0 },

			{ BlockType.LightRed, 30 },
			{ BlockType.LightOrange, 20 },
			{ BlockType.LightYellow, 15 },
			{ BlockType.LightGreen, 10 },
			{ BlockType.LightBlue, 8 },
			{ BlockType.LightCyan, 5 },
			{ BlockType.LightMagenta, 2 },
			{ BlockType.LightGray, 0 },
			{ BlockType.Dark, 0 },

			{ BlockType.FlashingRed, 10 },
			{ BlockType.FlashingOrange, 10 },
			{ BlockType.FlashingYellow, 10 },
			{ BlockType.FlashingGreen, 10 },
			{ BlockType.FlashingBlue, 10 },
			{ BlockType.FlashingCyan, 10 },
			{ BlockType.FlashingMagenta, 10 },
			{ BlockType.FlashingGray, 10 },
			{ BlockType.FlashingBlack, 10 },

			{ BlockType.None, 0 },
		};

		public static Dictionary<BlockType, GameColor> Color = new Dictionary<BlockType, GameColor>()
		{
			{ BlockType.Red, GameColor.Red },
			{ BlockType.Orange, GameColor.Orange },
			{ BlockType.Yellow, GameColor.Yellow },
			{ BlockType.Green, GameColor.Green },
			{ BlockType.Blue, GameColor.Blue },
			{ BlockType.Cyan, GameColor.Cyan },
			{ BlockType.Magenta, GameColor.Magenta },
			{ BlockType.Gray, GameColor.Gray },
			{ BlockType.Black, GameColor.Black },

			{ BlockType.LightRed, GameColor.Red },
			{ BlockType.LightOrange, GameColor.Orange },
			{ BlockType.LightYellow, GameColor.Yellow },
			{ BlockType.LightGreen, GameColor.Green },
			{ BlockType.LightBlue, GameColor.Blue },
			{ BlockType.LightCyan, GameColor.Cyan },
			{ BlockType.LightMagenta, GameColor.Magenta },
			{ BlockType.LightGray, GameColor.Gray },
			{ BlockType.Dark, GameColor.Black },

			{ BlockType.FlashingRed, GameColor.Red },
			{ BlockType.FlashingOrange, GameColor.Orange },
			{ BlockType.FlashingYellow, GameColor.Yellow },
			{ BlockType.FlashingGreen, GameColor.Green },
			{ BlockType.FlashingBlue, GameColor.Blue },
			{ BlockType.FlashingCyan, GameColor.Cyan },
			{ BlockType.FlashingMagenta, GameColor.Magenta },
			{ BlockType.FlashingGray, GameColor.Gray },
			{ BlockType.FlashingBlack, GameColor.Black },

			{ BlockType.None, GameColor.None },
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

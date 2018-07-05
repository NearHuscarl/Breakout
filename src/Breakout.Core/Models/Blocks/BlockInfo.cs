using Breakout.Core.Models.Enums;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Core.Models.Blocks
{
	public struct BlockAtrributes
	{
		public int Health;
		public GameColor Color;
		public PowerUpType FavoredPowerUp;
		public PowerUpType SecondaryFavorePowerUp;

		private static BlockAtrributes emptyAttributes = new BlockAtrributes(0, GameColor.None, PowerUpType.Nothing, PowerUpType.Nothing);

		public static BlockAtrributes Empty { get { return emptyAttributes; } }

		public BlockAtrributes(int health, GameColor color, PowerUpType favoredPowerUp, PowerUpType secondaryFavoredPowerUp = PowerUpType.Nothing)
		{
			Health = health;
			Color = color;
			FavoredPowerUp = favoredPowerUp;
			SecondaryFavorePowerUp = secondaryFavoredPowerUp;
		}
	}

	public static class BlockInfo
	{
		public static Dictionary<BlockType, BlockAtrributes> Attributes = new Dictionary<BlockType, BlockAtrributes>()
		{
			{ BlockType.Red,     new BlockAtrributes(health: 10, color: GameColor.Red, favoredPowerUp: PowerUpType.Stronger) },
			{ BlockType.Orange,  new BlockAtrributes(health: 60, color: GameColor.Orange, favoredPowerUp: PowerUpType.Slower) },
			{ BlockType.Yellow,  new BlockAtrributes(health: 50, color: GameColor.Yellow, favoredPowerUp: PowerUpType.Faster) },
			{ BlockType.Green,   new BlockAtrributes(health: 40, color: GameColor.Green, favoredPowerUp: PowerUpType.Double, secondaryFavoredPowerUp: PowerUpType.Triple) },
			{ BlockType.Blue,    new BlockAtrributes(health: 30, color: GameColor.Blue, favoredPowerUp: PowerUpType.Weaker) },
			{ BlockType.Cyan,    new BlockAtrributes(health: 20, color: GameColor.Cyan, favoredPowerUp: PowerUpType.Bigger, secondaryFavoredPowerUp: PowerUpType.Smaller) },
			{ BlockType.Magenta, new BlockAtrributes(health: 10, color: GameColor.Magenta, favoredPowerUp: PowerUpType.Nothing) },
			{ BlockType.Gray,    new BlockAtrributes(health: 80, color: GameColor.Gray, favoredPowerUp: PowerUpType.Magnetize) },
			{ BlockType.Black,   new BlockAtrributes(health: 90, color: GameColor.Black, favoredPowerUp: PowerUpType.Longer, secondaryFavoredPowerUp: PowerUpType.Shorter) },

			{ BlockType.LightRed,     new BlockAtrributes(health: 10, color: GameColor.Red, favoredPowerUp: PowerUpType.Stronger) },
			{ BlockType.LightOrange,  new BlockAtrributes(health: 60, color: GameColor.Orange, favoredPowerUp: PowerUpType.Slower) },
			{ BlockType.LightYellow,  new BlockAtrributes(health: 50, color: GameColor.Yellow, favoredPowerUp: PowerUpType.Faster) },
			{ BlockType.LightGreen,   new BlockAtrributes(health: 40, color: GameColor.Green, favoredPowerUp: PowerUpType.Double, secondaryFavoredPowerUp: PowerUpType.Triple) },
			{ BlockType.LightBlue,    new BlockAtrributes(health: 30, color: GameColor.Blue, favoredPowerUp: PowerUpType.Weaker) },
			{ BlockType.LightCyan,    new BlockAtrributes(health: 20, color: GameColor.Cyan, favoredPowerUp: PowerUpType.Bigger, secondaryFavoredPowerUp: PowerUpType.Smaller) },
			{ BlockType.LightMagenta, new BlockAtrributes(health: 10, color: GameColor.Magenta, favoredPowerUp: PowerUpType.Nothing) },
			{ BlockType.LightGray,    new BlockAtrributes(health: 80, color: GameColor.Gray, favoredPowerUp: PowerUpType.Magnetize) },
			{ BlockType.Dark,         new BlockAtrributes(health: 90, color: GameColor.Black, favoredPowerUp: PowerUpType.Longer, secondaryFavoredPowerUp: PowerUpType.Shorter) },

			 // One hit, blow up surrounding when hit
			{ BlockType.FlashingRed,     new BlockAtrributes(health: 1, color: GameColor.Red, favoredPowerUp: PowerUpType.Stronger) },
			{ BlockType.FlashingOrange,  new BlockAtrributes(health: 1, color: GameColor.Orange, favoredPowerUp: PowerUpType.Slower) },
			{ BlockType.FlashingYellow,  new BlockAtrributes(health: 1, color: GameColor.Yellow, favoredPowerUp: PowerUpType.Faster) },
			{ BlockType.FlashingGreen,   new BlockAtrributes(health: 1, color: GameColor.Green, favoredPowerUp: PowerUpType.Double, secondaryFavoredPowerUp: PowerUpType.Triple) },
			{ BlockType.FlashingBlue,    new BlockAtrributes(health: 1, color: GameColor.Blue, favoredPowerUp: PowerUpType.Weaker) },
			{ BlockType.FlashingCyan,    new BlockAtrributes(health: 1, color: GameColor.Cyan, favoredPowerUp: PowerUpType.Bigger, secondaryFavoredPowerUp: PowerUpType.Smaller) },
			{ BlockType.FlashingMagenta, new BlockAtrributes(health: 1, color: GameColor.Magenta, favoredPowerUp: PowerUpType.Nothing) },
			{ BlockType.FlashingGray,    new BlockAtrributes(health: 1, color: GameColor.Gray, favoredPowerUp: PowerUpType.Magnetize) },
			{ BlockType.FlashingBlack,   new BlockAtrributes(health: 1, color: GameColor.Black, favoredPowerUp: PowerUpType.Longer, secondaryFavoredPowerUp: PowerUpType.Shorter) },

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

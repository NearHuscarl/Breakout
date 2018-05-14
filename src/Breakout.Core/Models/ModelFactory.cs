using Breakout.Models.Balls;
using Breakout.Models.Bases;
using Breakout.Models.Blocks;
using Breakout.Models.Enums;
using Breakout.Models.Explosions;
using Breakout.Models.Maps;
using Breakout.Models.Paddles;
using Breakout.Models.Players;
using Breakout.Models.PowerUps;
using Breakout.Models.Texts;
using Breakout.Utilities;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Breakout.Models
{
	public static class ModelFactory
	{
		public static Rectangle CreateFooter()
		{
			return new Rectangle()
			{
				X = 0,
				Y = GameInfo.Screen.Height - GameInfo.ScoreFont.Height,

				Width = GameInfo.Screen.Width,
				Height = GameInfo.ScoreFont.Height,
			};
		}

		public static Paddle CreatePaddle()
		{
			return new Paddle(
				length: GameInfo.PaddleLength,
				height: GameInfo.PaddleHeight,
				velocity: GameInfo.PaddleVelocity);
		}

		public static List<Ball> CreateBall()
		{
			Vector2 position = new Vector2()
			{
				X = GameInfo.Screen.Width / 2 - GameInfo.BallRadius / 2,
				Y = GameInfo.Screen.Height * 0.7f,
			};

			Ball ball = new Ball(
				radius: GameInfo.BallRadius,
				strength: GameInfo.BallStrength,
				velocity: GameInfo.BallVelocity,
				position: position);

			ball.ResetPosition();

			return new List<Ball>()
			{
				ball,
			};
		}

		/// <summary>
		/// Create ball randomly. Used in spawning in menu
		/// </summary>
		/// <returns></returns>
		public static List<Ball> CreateRandomBalls()
		{
			List<Ball> balls = new List<Ball>();
			int numOfBall = RandomMath.RandomBetween(1, 4); // Random spawn 1-3 balls

			foreach (int i in Enumerable.Range(1, numOfBall))
			{
				Vector2 position = new Vector2()
				{
					X = RandomMath.RandomBetween(0, GameInfo.Screen.Width - GameInfo.BallRadius * 2),
					Y = RandomMath.RandomBetween(0, GameInfo.Screen.Height - GameInfo.BallRadius * 2),
				};

				Ball ball = new Ball(
						radius: GameInfo.BallRadius,
						strength: GameInfo.BallStrength,
						velocity: GameInfo.BallVelocity,
						position: position);

				ball.ChangeDirection(RandomMath.RandomBetween(0, 360));
				balls.Add(ball);
			}

			return balls;
		}

		public static Player CreatePlayer(Rectangle footer)
		{
			Player player = new Player()
			{
				Score = new ScoreManager(),
				Live = new Text(text: 3, prompt: GameInfo.LiveText),
				CurrentCombo = new Text(text: 0, prompt: GameInfo.CurrentComboText),
				HighestCombo = new Text(text: 0, prompt: GameInfo.HighestComboText),
			};

			player.Score.Position = new Vector2()
			{
				X = (footer.Width / 2 - GameInfo.ScoreFont.GetLength(player.Score.FullText) / 2),
				Y = footer.Y,
			};

			player.Live.Position = new Vector2()
			{
				X = 5,
				Y = footer.Y,
			};

			player.CurrentCombo.Position = new Vector2()
			{
				X = GameInfo.ScoreFont.GetLength(player.Live.FullText),
				Y = footer.Y,
			};

			player.HighestCombo.Position = new Vector2()
			{
				X = GameInfo.ScoreFont.GetLength(player.Live.FullText) + GameInfo.ScoreFont.GetLength(player.CurrentCombo.FullText),
				Y = footer.Y,
			};

			return player;
		}

		public static Text CreateBlockLeftText(Rectangle footer, int numOfBlocks)
		{
			Text blockLeftText = new Text(text: numOfBlocks, prompt: GameInfo.BlockLeftText);

			blockLeftText.Position = new Vector2()
			{
				X = GameInfo.Screen.Width - GameInfo.ScoreFont.GetLength(blockLeftText.FullText),
				Y = footer.Y,
			};

			return blockLeftText;
		}

		public static PowerUpPackage CreatePowerUpPackage(PowerUp powerUp, Vector2 position)
		{
			return new PowerUpPackage(powerUp, width: GameInfo.PackageWidth, height: GameInfo.PackageHeight, position: position);
		}

		public static List<Block> CreateLogo()
		{
			return MapManager.LoadLogo();
		}

		public static Block CreateBlock(BlockType blockType, Vector2 position)
		{
			if (BlockInfo.IsFlashing(blockType))
				return new FlashingBlock(EntryPoint.Game.Scene, position, blockType);

			else if (BlockInfo.IsLight(blockType))
				return new LightBlock(EntryPoint.Game.Scene, position, blockType);

			return new NormalBlock(EntryPoint.Game.Scene, position, blockType);
		}

		public static List<Block> CreateBlocks()
		{
			return MapManager.LoadMap("quick");
		}

		/// <summary>
		/// Create explosive Rectangle with center position is origin center position and
		/// radius is width and height
		/// </summary>
		/// <param name="radius"></param>
		/// <param name="origin"></param>
		/// <returns></returns>
		public static Explosion CreateExplosion(Rectangle origin)
		{
			Rectangle rectangle = new Rectangle()
			{
				X = (origin.X + origin.Width / 2 - GameInfo.ExplosiveRadius / 2),
				Y = (origin.Y + origin.Height / 2 - GameInfo.ExplosiveRadius / 2),
				Width = GameInfo.ExplosiveRadius,
				Height = GameInfo.ExplosiveRadius,
			};

			return new Explosion(rectangle);
		}
	}
}

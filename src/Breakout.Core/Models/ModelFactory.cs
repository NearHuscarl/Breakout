using Breakout.Models.Balls;
using Breakout.Models.Bases;
using Breakout.Models.Blocks;
using Breakout.Models.UIComponents;
using Breakout.Models.Explosions;
using Breakout.Models.Maps;
using Breakout.Models.Meta;
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
		private static int buttonWidth;
		private static int buttonHeight;

		private static int paddleWidth;
		private static int paddleHeight;

		private static int ballRadius;
		private static int ballStrength;
		private static float ballVelocity;

		private static int blockWidth;
		private static int blockHeight;

		private static int packageWidth;
		private static int packageHeight;

		private static int explosiveRadius;

		public static void Initialize()
		{
			buttonWidth = 150;
			buttonHeight = 40;

			paddleWidth = 100;
			paddleHeight = 17;

			ballRadius = 8;
			ballStrength = 5;
			ballVelocity = 6f;

			blockWidth = 20;
			blockHeight = 20;

			packageWidth = 20;
			packageHeight = 20;

			explosiveRadius = 40;
	}

	public static Button CreateStartButton()
		{
			return new Button(width: buttonWidth, height: buttonHeight, xRatio: 0.5f, yRatio: 0.5f, text: "Start Game");
		}

		public static Button CreateCreditButton()
		{
			return new Button(width: buttonWidth, height: buttonHeight, xRatio: 0.5f, yRatio: 0.6f, text: "About");
		}

		public static Button CreateExitButton()
		{
			return new Button(width: buttonWidth, height: buttonHeight, xRatio: 0.5f, yRatio: 0.7f, text: "Exit Game");
		}

		public static Paddle CreatePaddle()
		{
			return new Paddle(width: paddleWidth, height: paddleHeight);
		}

		public static List<Ball> CreateBall()
		{
			Vector2 position = new Vector2()
			{
				X = GameInfo.Screen.Width / 2 - ballRadius / 2,
				Y = GameInfo.Screen.Height * 0.7f,
			};

			Ball ball = new Ball(
				radius: ballRadius,
				strength: ballStrength,
				velocity: ballVelocity,
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
					X = RandomMath.RandomBetween(0, GameInfo.Screen.Width - ballRadius),
					Y = RandomMath.RandomBetween(0, GameInfo.Screen.Height - ballRadius),
				};

				Ball ball = new Ball(
						radius: ballRadius,
						strength: ballStrength,
						velocity: ballVelocity,
						position: position);

				ball.ChangeDirection(RandomMath.RandomBetween(0, 360));
				balls.Add(ball);
			}

			return balls;
		}

		public static GameObject CreateFooter()
		{
			return new GameObject()
			{
				Position = new Vector2()
				{
					X = 0,
					Y = GameInfo.Screen.Height - GameInfo.Font.Height,
				},

				Width = GameInfo.Screen.Width,
				Height = GameInfo.Font.Height,
			};
		}

		public static Player CreatePlayer(GameObject footer)
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
				X = (footer.Width / 2 - GameInfo.Font.GetLength(player.Score.FullText) / 2),
				Y = footer.Position.Y,
			};

			player.Live.Position = new Vector2()
			{
				X = 5,
				Y = footer.Position.Y,
			};

			player.CurrentCombo.Position = new Vector2()
			{
				X = GameInfo.Font.GetLength(player.Live.FullText),
				Y = footer.Position.Y,
			};

			player.HighestCombo.Position = new Vector2()
			{
				X = GameInfo.Font.GetLength(player.Live.FullText) + GameInfo.Font.GetLength(player.CurrentCombo.FullText),
				Y = footer.Position.Y,
			};

			return player;
		}

		public static Text CreateBlockLeftText(GameObject footer, int numOfBlocks)
		{
			Text blockLeftText = new Text(text: numOfBlocks, prompt: GameInfo.BlockLeftText);

			blockLeftText.Position = new Vector2()
			{
				X = GameInfo.Screen.Width - GameInfo.Font.GetLength(blockLeftText.FullText),
				Y = footer.Position.Y,
			};

			return blockLeftText;
		}

		public static PowerUpPackage CreatePowerUpPackage(PowerUp powerUp, Vector2 position)
		{
			return new PowerUpPackage(powerUp, width: packageWidth, height: packageHeight, position: position);
		}

		public static List<Block> CreateLogo()
		{
			return MapManager.LoadLogo(blockWidth: blockWidth, blockHeight: blockHeight);
		}

		public static List<Block> CreateBlocks()
		{
			return MapManager.LoadMap("mario", blockWidth: blockWidth, blockHeight: blockHeight);
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
				X = (origin.X + origin.Width / 2 - explosiveRadius / 2),
				Y = (origin.Y + origin.Height / 2 - explosiveRadius / 2),
				Width = explosiveRadius,
				Height = explosiveRadius,
			};

			return new Explosion(rectangle);
		}
	}
}

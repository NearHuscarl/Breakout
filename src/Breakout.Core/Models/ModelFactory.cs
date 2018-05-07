using Breakout.Models.Balls;
using Breakout.Models.Blocks;
using Breakout.Models.Buttons;
using Breakout.Models.Enums;
using Breakout.Models.Maps;
using Breakout.Models.Meta;
using Breakout.Models.Paddles;
using Breakout.Models.Players;
using Breakout.Models.PowerUps;
using Breakout.Models.Texts;
using Breakout.Utilities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Models
{
	public static class ModelFactory
	{
		private static int paddleWidth;
		private static int paddleHeight;

		private static int ballRadius;
		private static int ballStrength;
		private static float ballVelocity;

		private static int blockWidth;
		private static int blockHeight;

		private static int packageWidth;
		private static int packageHeight;

		public static void Initialize()
		{
			paddleWidth = 100;
			paddleHeight = 17;

			ballRadius = 8;
			ballStrength = 5;
			ballVelocity = 6f;

			blockWidth = 20;
			blockHeight = 20;

			packageWidth = 20;
			packageHeight = 20;
		}

		public static Button CreateStartButton()
		{
			return new Button(xRatio: 0.5f, yRatio: 0.5f);
		}

		public static Button CreateCreditButton()
		{
			return new Button(xRatio: 0.5f, yRatio: 0.6f);
		}

		public static Button CreateExitButton()
		{
			return new Button(xRatio: 0.5f, yRatio: 0.7f);
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

		public static Player CreatePlayer()
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
				X = (GameInfo.Footer.Width / 2 - GameInfo.Font.GetLength(player.Score.FullText) / 2),
				Y = GameInfo.Footer.Y,
			};

			player.Live.Position = new Vector2()
			{
				X = 5,
				Y = GameInfo.Footer.Y,
			};

			player.CurrentCombo.Position = new Vector2()
			{
				X = GameInfo.Font.GetLength(player.Live.FullText),
				Y = GameInfo.Footer.Y,
			};

			player.HighestCombo.Position = new Vector2()
			{
				X = GameInfo.Font.GetLength(player.Live.FullText) + GameInfo.Font.GetLength(player.CurrentCombo.FullText),
				Y = GameInfo.Footer.Y,
			};

			return player;
		}

		public static Text CreateBlockLeftText(int numOfBlocks)
		{
			Text blockLeftText = new Text(text: numOfBlocks, prompt: GameInfo.BlockLeftText);

			blockLeftText.Position = new Vector2()
			{
				X = GameInfo.Screen.Width - GameInfo.Font.GetLength(blockLeftText.FullText),
				Y = GameInfo.Footer.Y,
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
	}
}

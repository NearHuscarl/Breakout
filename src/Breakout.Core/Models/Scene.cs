using Breakout.Models.Balls;
using Breakout.Models.Blocks;
using Breakout.Models.Buttons;
using Breakout.Models.Enums;
using Breakout.Models.Meta;
using Breakout.Models.Paddles;
using Breakout.Models.Players;
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
	public static class Scene
	{
		private static float deltaTime;

		public static Button StartButton { get; set; }
		public static Button CreditButton { get; set; }
		public static Button ExitButton { get; set; }

		public static Paddle Paddle { get; set; }
		public static List<Ball> Balls { get; set; }
		public static List<Block> Blocks { get; set; }

		public static Player Player { get; set; }

		public static Text BlockLeft { get; set; }

		public static void InitializeMenu()
		{
			StartButton = ModelFactory.CreateStartButton();
			CreditButton = ModelFactory.CreateCreditButton();
			ExitButton = ModelFactory.CreateExitButton();
		}

		public static void InitializeGame()
		{
			Player = ModelFactory.CreatePlayer();

			Paddle = ModelFactory.CreatePaddle();
			Balls = ModelFactory.CreateBall();

			Blocks = ModelFactory.CreateBlocks();
			BlockLeft = ModelFactory.CreateBlockLeftText(Blocks.Count);
		}

		public static void Reset()
		{
			Player.CurrentCombo.Content = "0";

			Paddle = ModelFactory.CreatePaddle();
			Balls = ModelFactory.CreateBall();
		}

		/// <summary>
		/// Update physics and stuff in the whole game
		/// </summary>
		public static void Step(float elapsed)
		{
			deltaTime = elapsed;

			foreach (var ball in Balls.ToList())
				HandleBall(ball);

			foreach (var block in Blocks.ToList())
				HandleBlock(block);
		}

		private static void HandleBall(Ball ball)
		{
			if (ball.IsOffBottom())
				Balls.Remove(ball);

			ball.HandleWallCollision();
			ball.HandlePaddleCollision(Paddle);

			foreach (var block in Blocks)
			{
				if (ball.HandleCollision(block))
				{
					Player.Score.AddScore(160);
					Player.CurrentCombo.Get(1);

					if (Player.CurrentCombo > Player.HighestCombo)
						Player.HighestCombo.Get(1);
				}
			}

			ball.UpdateMovement(deltaTime);
		}

		private static void HandleBlock(Block block)
		{
			if (block.IsBroken)
			{
				Blocks.Remove(block);
				BlockLeft.Take(1);
			}
		}

		public static void CleanUp()
		{
			if (Player != null)
				Player.Score.StopRecording();
		}
	}
}

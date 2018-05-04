using Breakout.Models.Balls;
using Breakout.Models.Bases;
using Breakout.Models.Blocks;
using Breakout.Models.Enums;
using Breakout.Models.Meta;
using Breakout.Models.Paddles;
using Breakout.Models.Players;
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

		public static Button StartButton;
		public static Button CreditButton;
		public static Button ExitButton;

		public static Paddle Paddle { get; set; }
		public static List<Ball> Balls { get; set; }
		public static List<Block> Blocks { get; set; }

		public static Player Player { get; set; }

		public static int BlockLeft;

		public static void Initialize()
		{
			InitializeMenu();
			InitializeGame();
		}

		public static void InitializeMenu()
		{
			StartButton = new Button(xRatio: 0.5f, yRatio: 0.4f);
			CreditButton = new Button(xRatio: 0.5f, yRatio: 0.5f);
			ExitButton = new Button(xRatio: 0.5f, yRatio: 0.6f);
		}

		public static void InitializeGame()
		{
			Player = new Player();
			Balls = new List<Ball>();

			InitializePaddle();
			InitializeBall();
			InitializeBlocks();
			BlockLeft = Blocks.Count;
		}

		public static void Reset()
		{
			InitializePaddle();
			InitializeBall();
		}

		private static void InitializePaddle()
		{
			Paddle = new Paddle(width: 100, height: 17);
		}

		private static void InitializeBall()
		{
			Ball ball = new Ball(radius: 8, strength: 5, velocity: 6f);

			ball.ResetPosition();

			Balls.Clear();
			Balls.Add(ball);
		}

		private static void InitializeBlocks()
		{
			int blockWidth = 30;
			int blockHeight = 30;
			Blocks = new List<Block>();

			// TODO: design level
			for (int w = 0; w * blockWidth < GameInfo.Screen.Width; w++)
			{
				for (int h = 0; h * blockHeight < GameInfo.Screen.Height / 2; h++)
				{
					int x = blockWidth * w;
					int y = blockHeight* h;
					BlockType blockType = RandomMath.RandomEnum<BlockType>();

					Block newBlock = new Block(blockType, width: 30, height: 30, position: new Vector2(x, y));

					Blocks.Add(newBlock);
				}
			}
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

			Blocks.ForEach(block => ball.HandleCollision(block));
			ball.UpdateMovement(deltaTime);
		}

		private static void HandleBlock(Block block)
		{
			if (block.IsBroken)
				Blocks.Remove(block);
		}
	}
}

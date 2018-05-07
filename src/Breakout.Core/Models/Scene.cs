using Breakout.Extensions;
using Breakout.Models.Balls;
using Breakout.Models.Blocks;
using Breakout.Models.Buttons;
using Breakout.Models.Enums;
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
	public static class Scene
	{
		private static float deltaTime;

		public static Button StartButton { get; set; }
		public static Button CreditButton { get; set; }
		public static Button ExitButton { get; set; }

		public static Paddle Paddle { get; set; }
		public static List<Ball> Balls { get; set; }
		public static List<Block> Blocks { get; set; }

		public static List<PowerUpPackage> Packages { get; set; }
		public static List<PowerUp> PowerUps { get; set; }

		public static Player Player { get; set; }

		public static Text BlockLeft { get; set; }

		public static void InitializeMenu()
		{
			StartButton = ModelFactory.CreateStartButton();
			CreditButton = ModelFactory.CreateCreditButton();
			ExitButton = ModelFactory.CreateExitButton();

			Balls = ModelFactory.CreateRandomBalls();
			Blocks = ModelFactory.CreateLogo();

			PowerUps = new List<PowerUp>();
			Packages = new List<PowerUpPackage>();
		}

		public static void InitializeGame()
		{
			Player = ModelFactory.CreatePlayer();

			Paddle = ModelFactory.CreatePaddle();
			Balls = ModelFactory.CreateBall();

			Blocks = ModelFactory.CreateBlocks();
			BlockLeft = ModelFactory.CreateBlockLeftText(Blocks.Count);

			PowerUps = new List<PowerUp>();
			Packages = new List<PowerUpPackage>();
		}

		public static void Reset()
		{
			Player.CurrentCombo.Content = "0";

			Paddle = ModelFactory.CreatePaddle();
			Balls = ModelFactory.CreateBall();
		}

		/// <summary>
		/// Update physics and behaviour of all entities in the game
		/// </summary>
		public static void Step(float elapsed, bool isMenu=false)
		{
			deltaTime = elapsed;

			foreach (var ball in Balls.ToList())
				HandleBall(ball, isMenu);

			foreach (var block in Blocks.ToList())
				HandleBlock(block, isMenu);

			foreach (var powerUp in PowerUps.ToList())
				HandlePowerUp(powerUp);

			foreach (var package in Packages.ToList())
				HandlePackage(package);
		}

		private static void HandleBall(Ball ball, bool isMenu)
		{
			if (isMenu)
				HandleBallInMenu(ball);
			else
				HandleBallInGame(ball);
		}

		private static void HandleBallInMenu(Ball ball)
		{
			ball.HandleWallCollision(isContained: true);

			foreach (var block in Blocks)
				ball.HandleCollision(block);

			ball.HandleCollision(StartButton);
			ball.HandleCollision(CreditButton);
			ball.HandleCollision(ExitButton);

			ball.UpdateMovement(deltaTime);
		}

		private static void HandleBallInGame(Ball ball)
		{
			if (ball.IsOffBottom())
				Balls.Remove(ball);

			ball.HandleWallCollision();
			ball.HandlePaddleCollision(Paddle);

			foreach (var block in Blocks)
			{
				if (!ball.HandleCollision(block))
					continue;

				Player.Score.AddScore(160);
				Player.CurrentCombo.Add(1);

				if (Player.CurrentCombo > Player.HighestCombo)
					Player.HighestCombo.Add(1);
			}

			ball.UpdateMovement(deltaTime);
		}

		private static void HandleBlock(Block block, bool isMenu)
		{
			if (block.IsBroken)
			{
				if (block.Type == BlockType.Red)
					PowerUps.Add(new PowerUp(PowerUpType.Faster, Balls));

				Packages.AddIfNotNull(block.SpawnPowerUpPackage());

				Blocks.Remove(block);

				if (!isMenu)
					BlockLeft.Take(1);
			}
		}

		public static void HandlePowerUp(PowerUp powerUp)
		{
			powerUp.Timer -= deltaTime;

			if (!powerUp.Active)
			{
				powerUp.Deactivate();
				PowerUps.Remove(powerUp);
			}
		}

		public static void HandlePackage(PowerUpPackage package)
		{
			if (Paddle != null && package.IsTouching(Paddle))
			{
				PowerUp powerUp = package.GetPowerUp();

				if (powerUp.Target == PowerUpTarget.Ball)
					powerUp.Activate(Balls);
				else
					powerUp.Activate(Paddle);

				PowerUps.Add(powerUp);
				Packages.Remove(package);
			}

			if (package.IsOffBottom())
				Packages.Remove(package);

			package.UpdateMovement(deltaTime);
		}

		public static void CleanUp()
		{
			if (Player != null)
				Player.Score.StopRecording();
		}
	}
}

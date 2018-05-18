using Breakout.Models.Balls;
using Breakout.Models.Blocks;
using Breakout.Models.Explosions;
using Breakout.Models.Paddles;
using Breakout.Models.Players;
using Breakout.Models.PowerUps;
using Breakout.Models.Scores;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using Breakout.Models.Maps;

namespace Breakout.Models
{
	public class Scene : GameComponent
	{
		private float deltaTime;

		public Paddle Paddle { get; set; }

		public Map Map { get; set; }
		public List<Ball> Balls { get; set; }

		public List<PowerUpPackage> Packages { get; set; }
		public List<PowerUp> PowerUps { get; set; }

		public List<Explosion> ExplosiveZones;
		public Player Player { get; set; }

		public Score BlockLeft { get; set; }

		public bool IsInGame { get; private set; } = false;

		public Scene(Game game) : base(game)
		{

		}

		public void InitializeMenu()
		{
			EntryPoint.Game.Scene.CleanUp();

			Balls = ModelFactory.CreateRandomBalls();
			Map = ModelFactory.CreateLogo();

			PowerUps = new List<PowerUp>();
			Packages = new List<PowerUpPackage>();
			ExplosiveZones = new List<Explosion>();

			IsInGame = false;
		}

		public void InitializeGame()
		{
			Player = ModelFactory.CreatePlayer();

			Paddle = ModelFactory.CreatePaddle();
			Balls = ModelFactory.CreateBall();

			Map = ModelFactory.CreateBlocks();
			BlockLeft = new Score(GameInfo.BlockLeftText, Map.Layer1.Count);

			PowerUps = new List<PowerUp>();
			Packages = new List<PowerUpPackage>();
			ExplosiveZones = new List<Explosion>();

			IsInGame = true;
		}

		public void Reset()
		{
			Player.CurrentCombo.Set(0);

			Paddle = ModelFactory.CreatePaddle();
			Balls = ModelFactory.CreateBall();
		}

		/// <summary>
		/// Update physics and behaviour of all entities in the game
		/// </summary>
		public void Step(float elapsed)
		{
			deltaTime = elapsed;

			foreach (var ball in Balls.ToList())
				HandleBall(ball);

			foreach (var block in Map.Layer1.ToList())
				HandleBlock(block);

			foreach (var package in Packages.ToList())
				HandlePackage(package);

			foreach (var powerUp in PowerUps.ToList())
				HandlePowerUp(powerUp);

			foreach (var explosion in ExplosiveZones.ToList())
				HandleExplosion(explosion);
		}

		private void HandleBall(Ball ball)
		{
			if (IsInGame)
				HandleBallInGame(ball);
			else
				HandleBallInMenu(ball);
		}

		private void HandleBallInMenu(Ball ball)
		{
			ball.HandleWallCollision(isContained: true);

			foreach (var block in Map.Layer1)
				ball.HandleCollision(block);

			ball.UpdateMovement(deltaTime);
		}

		private void HandleBallInGame(Ball ball)
		{
			if (ball.IsOffBottom())
				Balls.Remove(ball);

			ball.HandleWallCollision();
			ball.HandlePaddleCollision(Paddle);

			foreach (var block in Map.Layer1)
			{
				if (ball.HandleCollision(block))
				{
					UpdateScores();
					break;
				}
			}

			ball.UpdateMovement(deltaTime);
		}

		private void UpdateScores()
		{
			Player.Score.AddScore(160);
			Player.CurrentCombo.Add(1);

			if (Player.CurrentCombo > Player.HighestCombo)
			{
				Player.HighestCombo.Add(1);
			}
		}

		private void HandleBlock(Block block)
		{
			if (block.IsBroken)
			{
				block.OnDestroy();
				Map.Layer1.Remove(block);

				if (IsInGame)
					BlockLeft.Take(1);
			}
		}

		public void HandlePackage(PowerUpPackage package)
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

		public void HandlePowerUp(PowerUp powerUp)
		{
			powerUp.Timer -= deltaTime;

			if (!powerUp.Active)
			{
				powerUp.Deactivate();
				PowerUps.Remove(powerUp);
			}
		}

		public void HandleExplosion(Explosion explosion)
		{
			explosion.Timer -= deltaTime;

			if (!explosion.Active)
				return;

			foreach (var block in Map.Layer1)
			{
				if (block.Rectangle.Intersects(explosion.Rectangle))
					block.Hit();
			}

			ExplosiveZones.Remove(explosion);
		}

		public void CleanUp()
		{
			if (Player != null)
				Player.Score.StopRecording();
		}

		#region Instance Disposal Methods

		/// <summary>
		/// Clean up the component when it is disposing.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			try
			{
				CleanUp();
			}
			finally
			{
				base.Dispose(disposing);
			}
		}

		#endregion
	}
}

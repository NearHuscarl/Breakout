using Breakout.Core.Models.Balls;
using Breakout.Core.Models.Blocks;
using Breakout.Core.Models.Explosions;
using Breakout.Core.Models.Paddles;
using Breakout.Core.Models.Players;
using Breakout.Core.Models.PowerUps;
using Breakout.Core.Models.Scores;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using Breakout.Core.Models.Maps;
using Breakout.Pipeline.TiledMap;
using System;

namespace Breakout.Core.Models
{
	public class Scene : GameComponent
	{
		private float deltaTime;

		private bool isBackground;

		public bool IsBackground
		{
			get { return isBackground; }

			set
			{
				if (value)
					Volume = 0.05f;
				else
					Volume = 1f;

				isBackground = value;
			}
		}

		public float Volume { get; private set; } = 1f;

		public Paddle Paddle { get; set; }

		public BlockMap Map { get; set; }
		public List<Ball> Balls { get; set; }

		public List<PowerUpPackage> Packages { get; set; }
		public List<PowerUp> PowerUps { get; set; }

		public List<Explosion> ExplosiveZones;
		public Player Player { get; set; }

		public Timer Timer { get; set; }
		public int BlockLeft { get; set; }

		public bool IsInGame { get; private set; } = false;

		public Scene(Game game) : base(game)
		{

		}

		public void InitializeMenu(TiledMap logo)
		{
			EntryPoint.Game.Scene.CleanUp();

			Balls = ModelFactory.CreateRandomBalls();
			Map = MapManager.LoadGameObjects(logo);

			PowerUps = new List<PowerUp>();
			Packages = new List<PowerUpPackage>();
			ExplosiveZones = new List<Explosion>();

			IsInGame = false;
		}

		public void InitializeGame(TiledMap map)
		{
			EntryPoint.Game.Scene.CleanUp();

			Timer = new Timer();
			Player = ModelFactory.CreatePlayer();

			Paddle = ModelFactory.CreatePaddle();
			Balls = ModelFactory.CreateBall();

			Map = MapManager.LoadGameObjects(map);
			BlockLeft = Map.Layer1.Count;

			PowerUps = new List<PowerUp>();
			Packages = new List<PowerUpPackage>();
			ExplosiveZones = new List<Explosion>();

			IsInGame = true;
		}

		public void Reset()
		{
			Player.CurrentCombo = 0;

			Paddle = ModelFactory.CreatePaddle();
			Balls = ModelFactory.CreateBall();
		}

		/// <summary>
		/// Update physics and behaviour of all entities in the game
		/// </summary>
		public void Step(float elapsed)
		{
			deltaTime = elapsed;

			if (IsInGame)
				Timer.Count.Update(deltaTime);

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
			Player.CurrentCombo++;

			if (Player.CurrentCombo > Player.HighestCombo)
			{
				Player.HighestCombo++;
			}
		}

		private void HandleBlock(Block block)
		{
			if (block.IsBroken)
			{
				block.OnDestroy();
				Map.Layer1.Remove(block);

				if (IsInGame)
					BlockLeft--;
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

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
using Breakout.Core.Models.Data;
using Breakout.Core.Utilities.Map;
using Breakout.Core.Models.Enums;

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
		public string MapName { get; set; }

		public List<Ball> Balls { get; set; }

		public List<PowerUpPackage> Packages { get; set; }
		public List<PowerUp> PowerUps { get; set; }

		public List<Explosion> ExplosiveZones;
		public Player Player { get; set; }

		public Timer Timer { get; set; }
		public int BlockLeft { get; set; }

		public int FinalScore { get; set; }
		public int HighScore { get; set; } = 0;

		public bool IsInGame { get; private set; } = false;

		public Scene(Game game) : base(game)
		{

		}

		public void InitializeMenu()
		{
			EntryPoint.Game.Scene.CleanUp();

			Paddle = null;
			Balls = ModelFactory.CreateRandomBalls();

			Map = MapManager.Load(0);
			MapName = MapManager.Stages[0];

			PowerUps = new List<PowerUp>();
			Packages = new List<PowerUpPackage>();
			ExplosiveZones = new List<Explosion>();

			IsInGame = false;
		}

		public void InitializeGame(Session session)
		{
			EntryPoint.Game.Scene.CleanUp();

			Timer = new Timer();

			HighScore = session.CurrentScore;
			Player = ModelFactory.CreatePlayer(session);

			Map = MapManager.Load(session.CurrentLevel);
			MapName = MapManager.Stages[session.CurrentLevel];

			Paddle = ModelFactory.CreatePaddle();
			Balls = ModelFactory.CreateBall();

			BlockLeft = Map.Layer1.Count;

			PowerUps = new List<PowerUp>();
			Packages = new List<PowerUpPackage>();
			ExplosiveZones = new List<Explosion>();

			IsInGame = true;
		}

		/// <summary>
		/// Reset ball and paddle after losing a live
		/// </summary>
		public void Reset()
		{
			Player.CurrentCombo = 0;

			Paddle = ModelFactory.CreatePaddle();
			Balls = ModelFactory.CreateBall();
			PowerUps.Clear();
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
			Paddle.HandleBall(ball);

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

		public void TriggerPowerup(PowerUp powerUp)
		{
			PowerUp similarPowerup = null;

			switch (powerUp.PowerUpType)
			{
				case PowerUpType.Bigger:
				case PowerUpType.Smaller:
					similarPowerup = PowerUps.Where(p => p.PowerUpType == PowerUpType.Bigger || p.PowerUpType == PowerUpType.Smaller).FirstOrDefault();
					break;

				case PowerUpType.Longer:
				case PowerUpType.Shorter:
					similarPowerup = PowerUps.Where(p => p.PowerUpType == PowerUpType.Longer || p.PowerUpType == PowerUpType.Shorter).FirstOrDefault();
					break;

				case PowerUpType.Faster:
				case PowerUpType.Slower:
					similarPowerup = PowerUps.Where(p => p.PowerUpType == PowerUpType.Faster || p.PowerUpType == PowerUpType.Slower).FirstOrDefault();
					break;

				case PowerUpType.Stronger:
				case PowerUpType.Weaker:
					similarPowerup = PowerUps.Where(p => p.PowerUpType == PowerUpType.Stronger || p.PowerUpType == PowerUpType.Weaker).FirstOrDefault();
					break;
			}

			if (similarPowerup == null)
			{
				PowerUps.Add(powerUp);
			}
			else
			{
				PowerUps.Remove(similarPowerup);
				PowerUps.Add(powerUp);
			}

			powerUp.Activate();
		}

		public void HandlePackage(PowerUpPackage package)
		{
			package.Timer += deltaTime;

			if (package.IsCompletelyOffBottom())
				Packages.Remove(package);

			foreach (var ball in Balls)
			{
				if (package.IsTouching(ball) && package.Timer >= PowerUpPackage.ReadyToHitBallInterval)
				{
					package.SpawnPowerUp(ball);
					break;
				}
			}

			if (Paddle != null && package.IsTouching(Paddle))
				package.SpawnPowerUp(Paddle);

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
					block.Hit(explosion);
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

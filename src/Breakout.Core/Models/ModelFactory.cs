using Breakout.Core.Models.Balls;
using Breakout.Core.Models.Bases;
using Breakout.Core.Models.Blocks;
using Breakout.Core.Models.Enums;
using Breakout.Core.Models.Explosions;
using Breakout.Core.Models.Maps;
using Breakout.Core.Models.Paddles;
using Breakout.Core.Models.Players;
using Breakout.Core.Models.PowerUps;
using Breakout.Core.Models.Scores;
using Breakout.Core.Utilities;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Breakout.Core.Models
{
	public static class ModelFactory
	{
		//public static Rectangle CreateFooter()
		//{
		//	return new Rectangle()
		//	{
		//		X = 0,
		//		Y = GameInfo.Screen.Height - GameInfo.ScoreFont.Height,

		//		Width = GameInfo.Screen.Width,
		//		Height = GameInfo.ScoreFont.Height,
		//	};
		//}

		public static Paddle CreatePaddle()
		{
			return new Paddle(
				scene: EntryPoint.Game.Scene,
				length: GameInfo.PaddleLength,
				height: SpriteInfo.PaddleHeight,
				velocity: GameInfo.PaddleVelocity);
		}

		public static List<Ball> CreateBall()
		{
			Vector2 position = new Vector2()
			{
				X = GameInfo.Screen.Width / 2 - SpriteInfo.BallRadius / 2,
				Y = GameInfo.Screen.Height * 0.7f,
			};

			Ball ball = new Ball(
				scene: EntryPoint.Game.Scene,
				radius: SpriteInfo.BallRadius,
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
					X = RandomMath.RandomBetween(0, GameInfo.Screen.Width - SpriteInfo.BallRadius * 2),
					Y = RandomMath.RandomBetween(0, GameInfo.Screen.Height - SpriteInfo.BallRadius * 2),
				};

				Ball ball = new Ball(
						scene: EntryPoint.Game.Scene,
						radius: SpriteInfo.BallRadius,
						strength: GameInfo.BallStrength,
						velocity: GameInfo.BallVelocity,
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
				Score = new DynamicScore(),
				Live = 3,
				CurrentCombo = 0,
				HighestCombo = 0,
			};

			return player;
		}

		public static PowerUpPackage CreatePowerUpPackage(PowerUp powerUp, Vector2 position)
		{
			return new PowerUpPackage(powerUp, width: SpriteInfo.PackageWidth, height: SpriteInfo.PackageHeight, position: position);
		}

		public static Block CreateBlock(BlockType blockType, Vector2 position)
		{
			if (blockType == BlockType.None)
				return null;

			if (BlockInfo.IsFlashing(blockType))
				return new FlashingBlock(EntryPoint.Game.Scene, SpriteInfo.BlockWidth, SpriteInfo.BlockHeight, position, blockType);

			else if (BlockInfo.IsLight(blockType))
				return new LightBlock(EntryPoint.Game.Scene, SpriteInfo.BlockWidth, SpriteInfo.BlockHeight, position, blockType);

			return new NormalBlock(EntryPoint.Game.Scene, SpriteInfo.BlockWidth, SpriteInfo.BlockHeight, position, blockType);
		}

		public static GameObject CreateSkeletonBlock(BlockType blockType, Vector2 position)
		{
			if (blockType == BlockType.Skeleton)
				return new GameObject(SpriteInfo.BlockWidth, SpriteInfo.BlockHeight, position);

			return null;
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

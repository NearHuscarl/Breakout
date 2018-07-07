using Breakout.Core.Models.Balls;
using Breakout.Core.Models.Enums;
using Breakout.Core.Models.Paddles;
using Breakout.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Core.Models.PowerUps
{
	public static class PowerUpBehaviour
	{
		public static Dictionary<PowerUpType, Action<Scene>> BallPowerUp = new Dictionary<PowerUpType, Action<Scene>>()
		{
			{ PowerUpType.Double, DoubleBall },
			{ PowerUpType.Triple, TripleBall },
			{ PowerUpType.Bigger, IncreaseBallSize },
			{ PowerUpType.Smaller, DecreaseBallSize },
			{ PowerUpType.Stronger, StrengthenBall },
			{ PowerUpType.Weaker, WeakenBall },
			{ PowerUpType.Faster, MakeBallFaster },
			{ PowerUpType.Slower, MakeBallSlower },
			{ PowerUpType.Nothing, DoNothing },
		};

		public static Dictionary<PowerUpType, Action<Scene>> BallPowerDown = new Dictionary<PowerUpType, Action<Scene>>()
		{
			{ PowerUpType.Double, DoNothing },
			{ PowerUpType.Triple, DoNothing },
			{ PowerUpType.Bigger, RestoreBallSize },
			{ PowerUpType.Smaller, RestoreBallSize },
			{ PowerUpType.Stronger, RestoreBallStrength },
			{ PowerUpType.Weaker, RestoreBallStrength },
			{ PowerUpType.Faster, RestoreBallSpeed },
			{ PowerUpType.Slower, RestoreBallSpeed },
			{ PowerUpType.Nothing, DoNothing },
		};

		public static Dictionary<PowerUpType, Action<Scene>> PaddlePowerUp = new Dictionary<PowerUpType, Action<Scene>>()
		{
			{ PowerUpType.Longer, IncreasePaddleLength },
			{ PowerUpType.Shorter, DecreasePaddleLength },
			{ PowerUpType.Magnetize, MagnetizePaddle },
		};

		public static Dictionary<PowerUpType, Action<Scene>> PaddlePowerDown = new Dictionary<PowerUpType, Action<Scene>>()
		{
			{ PowerUpType.Longer, RestorePaddleLength },
			{ PowerUpType.Shorter, RestorePaddleLength },
			{ PowerUpType.Magnetize, DemagnetizePaddle },
		};

		private static void DoubleBall(Scene scene)
		{
			if (scene.Balls.Count > 32) // max is 64
				return;

			var balls = scene.Balls;
			var oldBalls = balls.ToList();

			balls.Clear();

			foreach (var oldBall in oldBalls)
			{
				// the new ball will be spawned at the exact same position with the old ball on the paddle
				// so they will be forever overlapped anyway. This also prevent a bug where paddle dont
				// have the info of the new attached balls
				if (oldBall.IsAttached)
					continue;

				var ball1 = oldBall.ShallowCopy();
				var ball2 = oldBall.ShallowCopy();

				ball1.Angle = oldBall.Angle + 20;
				ball2.Angle = oldBall.Angle - 20;

				balls.Add(ball1);
				balls.Add(ball2);
			}
		}

		private static void TripleBall(Scene scene)
		{
			if (scene.Balls.Count > 21) // max is 64
				return;

			var balls = scene.Balls;
			var oldBalls = balls.ToList();

			foreach (var oldBall in oldBalls)
			{
				if (oldBall.IsAttached)
					continue;

				var ball1 = oldBall.ShallowCopy();
				var ball2 = oldBall.ShallowCopy();

				ball1.Angle = oldBall.Angle + 20;
				ball2.Angle = oldBall.Angle - 20;

				balls.Add(ball1);
				balls.Add(ball2);
			}
		}

		private static void IncreaseBallSize(Scene scene)
		{
			scene.Balls.ForEach(ball => ball.Size = ball.Size.Next());
		}

		private static void DecreaseBallSize(Scene scene)
		{
			scene.Balls.ForEach(ball => ball.Size = ball.Size.Previous());
		}

		private static void RestoreBallSize(Scene scene)
		{
			scene.Balls.ForEach(ball => ball.Size = BallSize.Medium);
		}

		private static void StrengthenBall(Scene scene)
		{
			scene.Balls.ForEach(ball => ball.Strength = ball.Strength.Next());
		}

		private static void WeakenBall(Scene scene)
		{
			scene.Balls.ForEach(ball => ball.Strength = ball.Strength.Previous());
		}

		private static void RestoreBallStrength(Scene scene)
		{
			scene.Balls.ForEach(ball => ball.Strength = BallStrength.Normal);
		}

		private static void MakeBallFaster(Scene scene)
		{
			scene.Balls.ForEach(ball => ball.Velocity += 150);
		}

		private static void MakeBallSlower(Scene scene)
		{
			scene.Balls.ForEach(ball => ball.Velocity -= 50);
		}

		private static void RestoreBallSpeed(Scene scene)
		{
		}

		private static void IncreasePaddleLength(Scene scene)
		{
			var paddle = scene.Paddle;

			if (paddle == null)
				return;

			paddle.Length = paddle.Length.Next();
		}

		private static void DecreasePaddleLength(Scene scene)
		{
			var paddle = scene.Paddle;

			if (paddle == null)
				return;

			paddle.Length = paddle.Length.Previous();
		}

		private static void RestorePaddleLength(Scene scene)
		{
			var paddle = scene.Paddle;

			if (paddle == null)
				return;

			paddle.Length = PaddleLength.Medium;
		}

		private static void MagnetizePaddle(Scene scene)
		{
			var oldPaddle = scene.Paddle;

			if (oldPaddle == null)
				return;

			if (oldPaddle.GetType() == typeof(MagnetizedPaddle))
				return;

			scene.Paddle = ModelFactory.CreateMagnatizedPaddle();
			scene.Paddle.CopyAttributes(oldPaddle);
		}

		private static void DemagnetizePaddle(Scene scene)
		{
			var oldPaddle = scene.Paddle;

			if (oldPaddle == null)
				return;

			if (oldPaddle.GetType() != typeof(MagnetizedPaddle))
				return;

			scene.Balls.ForEach(b => b.IsAttached = false);

			scene.Paddle = ModelFactory.CreatePaddle();
			scene.Paddle.CopyAttributes(oldPaddle);
		}

		private static void DoNothing(Scene scene)
		{

		}
	}
}

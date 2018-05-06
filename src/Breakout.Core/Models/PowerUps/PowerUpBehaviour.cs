using Breakout.Models.Balls;
using Breakout.Models.Enums;
using Breakout.Models.Paddles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Models.PowerUps
{
	public static class PowerUpBehaviour
	{
		public static Dictionary<PowerUpType, Action<List<Ball>>> BallPowerUp = new Dictionary<PowerUpType, Action<List<Ball>>>()
		{
			{ PowerUpType.Double, DoubleBall },
			{ PowerUpType.Triple, TripleBall },
			{ PowerUpType.Bigger, IncreaseBallSize },
			{ PowerUpType.Smaller, DecreaseBallSize },
			{ PowerUpType.Stronger, StrengthenBall },
			{ PowerUpType.Weaker, WeakenBall },
			{ PowerUpType.Faster, MakeBallFaster },
			{ PowerUpType.Slower, MakeBallSlower },
		};

		public static Dictionary<PowerUpType, Action<List<Ball>>> BallPowerDown = new Dictionary<PowerUpType, Action<List<Ball>>>()
		{
			{ PowerUpType.Double, DoNothing },
			{ PowerUpType.Triple, DoNothing },
			{ PowerUpType.Bigger, DecreaseBallSize },
			{ PowerUpType.Smaller, IncreaseBallSize },
			{ PowerUpType.Stronger, WeakenBall },
			{ PowerUpType.Weaker, StrengthenBall },
			{ PowerUpType.Faster, MakeBallSlower },
			{ PowerUpType.Slower, MakeBallFaster },
		};

		public static Dictionary<PowerUpType, Action<Paddle>> PaddlePowerUp = new Dictionary<PowerUpType, Action<Paddle>>()
		{
			{ PowerUpType.Longer, IncreasePaddleLength },
			{ PowerUpType.Shorter, DecreasePaddleLength },
		};

		public static Dictionary<PowerUpType, Action<Paddle>> PaddlePowerDown = new Dictionary<PowerUpType, Action<Paddle>>()
		{
			{ PowerUpType.Longer, DecreasePaddleLength },
			{ PowerUpType.Shorter, IncreasePaddleLength },
		};

		private static void DoubleBall(List<Ball> balls)
		{
			//balls.Add(new Ball());
		}

		private static void TripleBall(List<Ball> balls)
		{
			//balls.Add(new Ball());
			//balls.Add(new Ball());
		}

		private static void IncreaseBallSize(List<Ball> balls)
		{
			ModifyBalls(balls, ball => ball.Radius += 2);
		}

		private static void DecreaseBallSize(List<Ball> balls)
		{
			ModifyBalls(balls, ball => ball.Radius -= 2);
		}

		private static void StrengthenBall(List<Ball> balls)
		{
			ModifyBalls(balls, ball => ball.Strength += 2);
		}

		private static void WeakenBall(List<Ball> balls)
		{
			ModifyBalls(balls, ball => ball.Strength -= 2);
		}

		private static void MakeBallFaster(List<Ball> balls)
		{
			ModifyBalls(balls, ball => ball.Velocity += 100);
		}

		private static void MakeBallSlower(List<Ball> balls)
		{
			ModifyBalls(balls, ball => ball.Velocity -= 100);
		}

		private static void ModifyBalls(List<Ball> balls, Action<Ball> modification)
		{
			foreach (var ball in balls)
			{
				modification.Invoke(ball);
			}
		}

		private static void IncreasePaddleLength(Paddle paddle)
		{
			paddle.Length += 2;
		}

		private static void DecreasePaddleLength(Paddle paddle)
		{
			paddle.Length -= 2;
		}

		private static void DoNothing(List<Ball> balls)
		{

		}

		private static void DoNothing(Paddle paddle)
		{

		}
	}
}

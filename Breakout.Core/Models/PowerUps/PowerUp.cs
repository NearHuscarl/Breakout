using Breakout.Models.Balls;
using Breakout.Models.Bases;
using Breakout.Models.Enums;
using Breakout.Models.Interfaces;
using Breakout.Models.Paddles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Models.PowerUps
{
	public class PowerUp : MovingObject
	{
		public PowerUpType PowerUpType { get; }

		public PowerUp(PowerUpType powerUpType)
		{
			PowerUpType = powerUpType;
		}

		public void ModifyAbility<T>(T entity)
		{
			List<Ball> balls = entity as List<Ball>;

			if (balls != null)
			{
				var BallModification = PowerUpBehaviour.Balls[PowerUpType];

				BallModification.Invoke(balls);
				return;
			}

			Paddle paddle = entity as Paddle;

			if (paddle != null)
			{
				var PaddleModification = PowerUpBehaviour.Paddle[PowerUpType];

				PaddleModification.Invoke(paddle);
				return;
			}
		}
	}
}

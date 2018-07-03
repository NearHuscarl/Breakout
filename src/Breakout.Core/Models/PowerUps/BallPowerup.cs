using Breakout.Core.Models.Balls;
using Breakout.Core.Models.Enums;
using System;
using System.Collections.Generic;

namespace Breakout.Core.Models.PowerUps
{
	public class BallPowerUp : PowerUp
	{
		private List<Ball> balls;

		public BallPowerUp(PowerUpType type, List<Ball> balls) : base(type)
		{
			this.balls = balls;
		}

		public override void Activate()
		{
			PowerUpBehaviour.BallPowerUp[PowerUpType].Invoke(balls);
		}

		public override void Deactivate()
		{
			PowerUpBehaviour.BallPowerDown[PowerUpType].Invoke(balls);
		}
	}
}

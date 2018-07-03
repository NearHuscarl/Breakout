using System;
using Breakout.Core.Models.Enums;
using Breakout.Core.Models.Paddles;

namespace Breakout.Core.Models.PowerUps
{
	public class PaddlePowerUp : PowerUp
	{
		private Paddle paddle;

		public PaddlePowerUp(PowerUpType type, Paddle paddle) : base(type)
		{
			this.paddle = paddle;
		}

		public override void Activate()
		{
			PowerUpBehaviour.PaddlePowerUp[PowerUpType].Invoke(paddle);
		}

		public override void Deactivate()
		{
			PowerUpBehaviour.PaddlePowerDown[PowerUpType].Invoke(paddle);
		}
	}
}

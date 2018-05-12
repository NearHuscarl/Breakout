using Breakout.Models.Balls;
using Breakout.Models.Bases;
using Breakout.Models.Enums;
using Breakout.Models.Paddles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Models.PowerUps
{
	public enum PowerUpTarget
	{
		Ball,
		Paddle,
	}

	public class PowerUp : RectangleObject
	{
		#region Properties

		public PowerUpType PowerUpType { get; private set;  }

		/// <summary>
		/// when timer hits zero, powerup stop and destroy itself
		/// </summary>
		public float Timer { get; set; }

		public bool Active
		{
			get
			{
				if (Timer <= 0)
					return false;

				return true;
			}
		}

		public PowerUpTarget Target
		{
			get
			{
				if (PowerUpBehaviour.BallPowerUp.ContainsKey(PowerUpType))
					return PowerUpTarget.Ball;

				return PowerUpTarget.Paddle;
			}
		}

		#endregion

		// the things that power-up can affect
		private List<Ball> balls;
		private Paddle paddle;

		public PowerUp(PowerUpType type)
		{
			PowerUpType = type;
			Timer = 20f;
		}

		public PowerUp(PowerUpType type, List<Ball> balls)
		{
			this.balls = balls;
			this.PowerUpType = type;
			this.Timer = 20f;

			Activate(balls);
		}

		public PowerUp(PowerUpType type, Paddle paddle)
		{
			this.paddle = paddle;
			this.PowerUpType = type;
			this.Timer = 20f;

			Activate(paddle);
		}

		public void Activate(List<Ball> balls)
		{
			this.balls = balls;

			PowerUpBehaviour.BallPowerUp[PowerUpType].Invoke(balls);
		}

		public void Activate(Paddle paddle)
		{
			this.paddle = paddle;

			PowerUpBehaviour.PaddlePowerUp[PowerUpType].Invoke(paddle);
		}

		public void Deactivate()
		{
			if (paddle != null)
				PowerUpBehaviour.PaddlePowerDown[PowerUpType].Invoke(paddle);

			if (balls != null)
				PowerUpBehaviour.BallPowerDown[PowerUpType].Invoke(balls);
		}
	}
}

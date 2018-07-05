using Breakout.Core.Models.Balls;
using Breakout.Core.Models.Bases;
using Breakout.Core.Models.Enums;
using Breakout.Core.Models.Paddles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Core.Models.PowerUps
{
	public class PowerUp
	{
		private Scene scene;

		#region Properties

		public static readonly float ActiveTime = 20f; // in secs
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

		#endregion

		public PowerUp(Scene scene, PowerUpType type)
		{
			this.scene = scene;

			PowerUpType = type;

			Timer = ActiveTime;
		}

		public void Activate()
		{
			if (PowerUpBehaviour.BallPowerUp.ContainsKey(PowerUpType))
			{
				PowerUpBehaviour.BallPowerUp[PowerUpType].Invoke(scene);
			}
			else
			{
				PowerUpBehaviour.PaddlePowerUp[PowerUpType].Invoke(scene);
			}
		}

		public void Deactivate()
		{
			if (PowerUpBehaviour.BallPowerDown.ContainsKey(PowerUpType))
			{
				PowerUpBehaviour.BallPowerDown[PowerUpType].Invoke(scene);
			}
			else
			{
				PowerUpBehaviour.PaddlePowerDown[PowerUpType].Invoke(scene);
			}
		}
	}
}

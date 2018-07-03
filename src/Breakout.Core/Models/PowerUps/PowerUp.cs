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
	public abstract class PowerUp : RectangleObject
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

		#endregion

		public PowerUp(PowerUpType type)
		{
			PowerUpType = type;
			Timer = 20f;
		}

		public abstract void Activate();
		public abstract void Deactivate();
	}
}

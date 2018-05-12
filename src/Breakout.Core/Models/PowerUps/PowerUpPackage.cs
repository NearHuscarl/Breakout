using Breakout.Models.Balls;
using Breakout.Models.Bases;
using Breakout.Models.Enums;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Breakout.Models.PowerUps
{
	/// <summary>
	/// Package contain power-up
	/// </summary>
	public class PowerUpPackage : RectangleObject
	{
		public PowerUp PowerUp { get; private set; }

		public PowerUpPackage(PowerUp powerUp, int width, int height, Vector2 position)
			: base(width, height, position)
		{
			PowerUp = powerUp;
			Velocity = 500f;
			Direction = new Vector2(0, -1); // going down
		}

		public PowerUp GetPowerUp()
		{
			return PowerUp;
		}
	}
}

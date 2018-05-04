using Breakout.Models.Enums;
using Breakout.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Models.PowerUps
{
	public static class PowerUpGenerator
	{
		public static PowerUp GenerateRandomPowerUp()
		{
			PowerUpType powerUpType = RandomMath.RandomEnum<PowerUpType>();

			return new PowerUp(powerUpType);
		}
	}
}

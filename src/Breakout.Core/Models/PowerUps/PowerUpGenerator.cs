using Breakout.Core.Models.Enums;
using Breakout.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Core.Models.PowerUps
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

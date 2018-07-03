using Breakout.Core.Models.Enums;
using Breakout.Core.Utilities.GameMath;

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

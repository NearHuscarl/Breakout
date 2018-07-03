using Breakout.Core.Models.Enums;
using Breakout.Core.Utilities.GameMath;

namespace Breakout.Core.Models.PowerUps
{
	public static class PowerUpGenerator
	{
		public static PowerUp GenerateRandomPowerUp(Scene scene)
		{
			PowerUpType powerUpType = RandomMath.RandomEnum<PowerUpType>();

			if (PowerUpBehaviour.BallPowerUp.ContainsKey(powerUpType))
			{
				return new BallPowerUp(powerUpType, scene.Balls);
			}

			return new PaddlePowerUp(powerUpType, scene.Paddle);
		}
	}
}

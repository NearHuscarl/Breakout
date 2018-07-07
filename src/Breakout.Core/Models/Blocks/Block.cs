using Breakout.Extensions;
using Breakout.Core.Models.Bases;
using Breakout.Core.Models.Enums;
using Breakout.Core.Models.PowerUps;
using Microsoft.Xna.Framework;
using Breakout.Core.Utilities.GameMath;
using Breakout.Core.Models.Balls;
using Breakout.Core.Models.Explosions;

namespace Breakout.Core.Models.Blocks
{
	public abstract class Block : RectangleObject, IInteractive
	{
		public GameColor Color { get; private set; }

		private int health;

		public int Health
		{
			get
			{
				return health;
			}
			protected set
			{
				health = value;

				if (value <= 0)
				{
					IsBroken = true;
				}
			}
		}
		public int MaxHealth { get; private set; }

		public bool IsBroken { get; private set; } = false;

		private int powerUpSpawnChance = 15; // in percent

		protected PowerUpType favoredPowerUp;
		protected PowerUpType secondaryfavoredPowerUp;

		public Block(Scene scene, int width, int height, Vector2 position, BlockAtrributes attrs)
			: base(width, height, position)
		{
			this.scene = scene;

			this.Color = attrs.Color;
			this.MaxHealth = attrs.Health;
			this.Health = this.MaxHealth;
			this.favoredPowerUp = attrs.FavoredPowerUp;
			this.secondaryfavoredPowerUp = attrs.SecondaryFavorePowerUp;
		}

		private PowerUpPackage SpawnPowerUpPackage()
		{
			// TODO: remove
			//PowerUp pu = null;

			//if (RandomMath.RandomBoolean())
			//	pu = new PowerUp(scene, PowerUpType.Magnetize);
			//else
			//	pu = new PowerUp(scene, PowerUpType.Triple);

			//return ModelFactory.CreatePowerUpPackage(pu, this.Position);


			if (!RandomMath.RandomPercent(powerUpSpawnChance))
				return null;

			PowerUp powerUp = null;
			var randNum = RandomMath.RandomBetween(0, 100);

			if (0 <= randNum && randNum < 30 && favoredPowerUp != PowerUpType.Nothing)
				powerUp = new PowerUp(scene, favoredPowerUp);

			else if (30 <= randNum && randNum < 50 && secondaryfavoredPowerUp != PowerUpType.Nothing)
				powerUp = new PowerUp(scene, secondaryfavoredPowerUp);

			else
				powerUp = new PowerUp(scene, RandomMath.RandomEnum<PowerUpType>());

			if (powerUp.PowerUpType == PowerUpType.Nothing)
				return null;

			return ModelFactory.CreatePowerUpPackage(powerUp, this.Position);
		}

		public virtual void Hit(object src)
		{
			if (src.GetType() == typeof(Ball))
			{
				var ball = (Ball)src;

				switch (ball.Strength)
				{
					case BallStrength.Weak:
						Health -= 5;
						scene.UpdateScores(35);
						break;

					case BallStrength.Normal:
						Health -= 10;
						scene.UpdateScores(70);
						break;

					case BallStrength.Strong:
						Health -= 30;
						scene.UpdateScores(210);
						break;
				}

				scene.UpdateCombo();
			}

			if (src.GetType() == typeof(Explosion))
			{
				Health -= 10;
				scene.UpdateScores(20);
			}
		}

		public virtual void OnDestroy()
		{
			scene.Packages.AddIfNotNull(this.SpawnPowerUpPackage());
		}
	}
}

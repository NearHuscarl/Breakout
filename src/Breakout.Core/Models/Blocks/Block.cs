using Breakout.Extensions;
using Breakout.Models.Bases;
using Breakout.Models.Enums;
using Breakout.Models.PowerUps;
using Breakout.Utilities;
using Microsoft.Xna.Framework;

namespace Breakout.Models.Blocks
{
	public abstract class Block : RectangleObject
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

		protected readonly int powerUpSpawnChance;

		protected Scene scene;

		public Block(Scene scene, Vector2 position, BlockType blockType) : base(GameInfo.BlockWidth, GameInfo.BlockHeight, position)
		{
			this.scene = scene;
			this.Color = BlockInfo.Color[blockType];
			this.MaxHealth = BlockInfo.Health[blockType];
			this.Health = this.MaxHealth;
			this.powerUpSpawnChance = BlockInfo.PowerUpSpawnChance[blockType];
		}

		private PowerUpPackage SpawnPowerUpPackage()
		{
			if (RandomMath.RandomPercent(powerUpSpawnChance))
			{
				PowerUp powerUp = PowerUpGenerator.GenerateRandomPowerUp();
				return ModelFactory.CreatePowerUpPackage(powerUp, this.Position);
			}

			return null;
		}

		public override void Hit()
		{
			Health -= 10;
		}

		public virtual void OnDestroy()
		{
			scene.Packages.AddIfNotNull(this.SpawnPowerUpPackage());
		}
	}
}

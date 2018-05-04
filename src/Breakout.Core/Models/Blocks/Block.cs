using Breakout.Models.Bases;
using Breakout.Models.Enums;
using Breakout.Models.PowerUps;
using Breakout.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Models.Blocks
{
	public class Block : DynamicObject
	{
		private int health;

		public int Health
		{
			get
			{
				return health;
			}
			private set
			{
				health = value;

				if (value <= 0)
				{
					IsBroken = true;
				}
			}
		}

		public BlockType Type { get; set;  }
		public bool IsBroken { get; private set; } = false;

		private readonly int powerUpSpawnChance;

		public Block(BlockType type, int width, int height, Vector2 position) : base(width, height, position)
		{
			this.Type = type;
			this.Health = BlockInfo.Health[Type];
			this.powerUpSpawnChance = BlockInfo.PowerUpSpawnChance[Type];
		}

		public PowerUp SpawnPowerUp()
		{
			if (RandomMath.RandomPercent(powerUpSpawnChance))
			{
				return PowerUpGenerator.GenerateRandomPowerUp();
			}
			else
			{
				return null;
			}
		}

		public override void Hit()
		{
			Health -= 10;
		}
	}
}

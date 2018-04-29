using Breakout.Models.Enums;
using Breakout.Models.Interfaces;
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
	public class Block : IBlock
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

		public BlockType BlockType { get; }
		public bool IsBroken { get; private set; } = false;
		public Vector2 Position { get; set; }

		private readonly int powerUpSpawnChance;

		public Block(BlockType blockType)
		{
			BlockType = blockType;
			Health = BlockInfo.Health[blockType];
			powerUpSpawnChance = BlockInfo.PowerUpSpawnChance[blockType];
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

		public void Hit()
		{
			Health -= 10;
		}
	}
}

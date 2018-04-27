using Breakout.Models.Interfaces;
using Breakout.Models.PowerUps;
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
		public Vector2 Position { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public Texture2D Texture { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public PowerUp SpawnPowerUp()
		{
			// PowerUp PowerUpGenerator.GenerateRandomPowerUp(sprites)
			return new PowerUp();
		}
	}
}

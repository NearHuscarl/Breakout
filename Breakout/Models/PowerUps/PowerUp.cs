using Breakout.Models.Balls;
using Breakout.Models.Interfaces;
using Breakout.Models.Paddles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Models.PowerUps
{
	public class PowerUp : IPowerUp
	{
		public Vector2 Position { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public Texture2D Texture { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public void ModifyAbility(Paddle paddle, List<Ball> balls)
		{
			// BonusGenerator.GenerateRandomBonus(ref sprites)
		}
	}
}

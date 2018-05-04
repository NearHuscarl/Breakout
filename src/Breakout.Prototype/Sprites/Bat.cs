using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Sprites
{
	public class Bat : Sprite
	{
		public Bat(Texture2D texture) : base(texture)
		{
			speed = 12f;
		}

		public override void Update(GameTime gameTime)
		{
			if (input == null)
			{
				throw new Exception("Please give a new value to 'input'");
			}

			velocity = Vector2.Zero;

			if (Keyboard.GetState().IsKeyDown(input.Left))
				velocity.X -= speed;

			else if (Keyboard.GetState().IsKeyDown(input.Right))
				velocity.X += speed;

			position += velocity;

			LockBat();
		}

		private void LockBat()
		{
			position.X = MathHelper.Clamp(position.X, 0, Game1.screenWidth - texture.Width);
		}

		public void ResetPosition()
		{
			position.X = (Game1.screenWidth / 2) - (texture.Width / 2);
			position.Y = Game1.screenHeight - texture.Height - 10;
		}
	}
}

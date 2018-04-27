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
	public class Ball : Sprite
	{
		private float timer = 0f;

		public int speedIncrementSpan = 10; // How often the speed will increment

		public Ball(Texture2D texture) : base(texture)
		{
			speed = 3f;
		}

		public override void Update(GameTime gameTime)
		{
			timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

			// if (timer > speedIncrementSpan)
			// {
			// 	speed++;
			// 	timer = 0;
			// }

			CheckWallCollision();

			position += velocity * speed;
		}

		public void ResetPosition(Rectangle bat)
		{
			var direction = Game1.random.Next(0, 4);

			switch (direction)
			{
				case 0:
					velocity = new Vector2(1, 1);
					break;
				case 1:
					velocity = new Vector2(1, -1);
					break;
				case 2:
					velocity = new Vector2(-1, -1);
					break;
				case 3:
					velocity = new Vector2(-1, 1);
					break;
			}

			position.X = bat.X + bat.Width / 2 - texture.Width / 2;
			position.Y = bat.Y - texture.Width;
			timer = 0;
		}

		private void CheckWallCollision()
		{
			if (position.X <= 0)
				velocity.X = -velocity.X;

			if (position.X + texture.Width >= Game1.screenWidth)
				velocity.X = -velocity.X;

			if (position.Y <= 0)
				velocity.Y = -velocity.Y;
		}

		private bool CheckSpriteCollision(Sprite sprite)
		{
			bool collided = false;

			if (velocity.X > 0 && IsTouchingLeft(sprite))
			{
				velocity.X = -velocity.X;
				collided = true;
			}

			if (velocity.X < 0 && IsTouchingRight(sprite))
			{
				velocity.X = -velocity.X;
				collided = true;
			}

			if (velocity.Y > 0 && IsTouchingTop(sprite))
			{
				velocity.Y = -velocity.Y;
				collided = true;
			}

			if (velocity.Y < 0 && IsTouchingBottom(sprite))
			{
				velocity.Y = -velocity.Y;
				collided = true;
			}

			return collided;
		}

		public void CheckBatCollision(Bat bat)
		{
			CheckSpriteCollision(bat);
		}

		public void CheckBlocksCollision(Blocks blocks)
		{
			foreach (var block in blocks.Get())
			{
				if (CheckSpriteCollision(block))
				{
					blocks.BrickHit(block);
				}
			}
		}

		public bool IsOffBottom()
		{
			if (position.Y + texture.Height >= Game1.screenHeight)
				return true;

			return false;
		}
	}
}

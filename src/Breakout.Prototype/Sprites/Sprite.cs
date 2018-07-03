using Breakout.Core.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Sprites
{
	public class Sprite
	{
		protected Texture2D texture;

		public Vector2 position;
		public Vector2 velocity;
		public float speed { get; set; }
		public Input input { get; set; }

		public Rectangle Rectangle
		{
			get
			{
				return new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
			}
		}

		public Sprite(Texture2D texture)
		{
			this.texture = texture;
		}

		public virtual void Update(GameTime gameTime)
		{

		}

		public virtual void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(texture, position, Color.White);
		}

		#region Collision

		protected bool IsTouchingLeft(Sprite sprite)
		{
			return this.Rectangle.Right + this.velocity.X > sprite.Rectangle.Left &&
				this.Rectangle.Left < sprite.Rectangle.Left &&
				this.Rectangle.Bottom > sprite.Rectangle.Top &&
				this.Rectangle.Top < sprite.Rectangle.Bottom;
		}

		protected bool IsTouchingRight(Sprite sprite)
		{
			return this.Rectangle.Left + this.velocity.X < sprite.Rectangle.Right &&
				this.Rectangle.Right > sprite.Rectangle.Right &&
				this.Rectangle.Bottom > sprite.Rectangle.Top &&
				this.Rectangle.Top < sprite.Rectangle.Bottom;
		}

		protected bool IsTouchingTop(Sprite sprite)
		{
			return this.Rectangle.Bottom + this.velocity.Y > sprite.Rectangle.Top &&
				this.Rectangle.Top < sprite.Rectangle.Top &&
				this.Rectangle.Right > sprite.Rectangle.Left &&
				this.Rectangle.Left < sprite.Rectangle.Right;
		}

		protected bool IsTouchingBottom(Sprite sprite)
		{
			return this.Rectangle.Top + this.velocity.Y < sprite.Rectangle.Bottom &&
				this.Rectangle.Bottom > sprite.Rectangle.Bottom &&
				this.Rectangle.Right > sprite.Rectangle.Left &&
				this.Rectangle.Left < sprite.Rectangle.Right;
		}

		#endregion
	}
}

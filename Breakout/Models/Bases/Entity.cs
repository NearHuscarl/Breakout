using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Models.Bases
{
	public abstract class Entity : GameObject
	{
		public Vector2 Velocity { get; set; }

		public Entity()
		{

		}

		public Entity(int width, int height)
		{
			this.Width = width;
			this.Height = height;
		}

		public Entity(int width, int height, Vector2 position)
		{
			this.Width = width;
			this.Height = height;
			this.Position = position;
		}

		public virtual void SetPosition(Vector2 position)
		{
			Position = position;
		}

		public virtual void SetPosition(int x, int y)
		{
			Position = new Vector2(x, y);
		}

		#region Collision

		protected bool IsTouchingLeft(Entity entity)
		{
			return this.Rectangle.Right + this.Velocity.X > entity.Rectangle.Left &&
				this.Rectangle.Left < entity.Rectangle.Left &&
				this.Rectangle.Bottom > entity.Rectangle.Top &&
				this.Rectangle.Top < entity.Rectangle.Bottom;
		}

		protected bool IsTouchingRight(Entity entity)
		{
			return this.Rectangle.Left + this.Velocity.X < entity.Rectangle.Right &&
				this.Rectangle.Right > entity.Rectangle.Right &&
				this.Rectangle.Bottom > entity.Rectangle.Top &&
				this.Rectangle.Top < entity.Rectangle.Bottom;
		}

		protected bool IsTouchingTop(Entity entity)
		{
			return this.Rectangle.Bottom + this.Velocity.Y > entity.Rectangle.Top &&
				this.Rectangle.Top < entity.Rectangle.Top &&
				this.Rectangle.Right > entity.Rectangle.Left &&
				this.Rectangle.Left < entity.Rectangle.Right;
		}

		protected bool IsTouchingBottom(Entity entity)
		{
			return this.Rectangle.Top + this.Velocity.Y < entity.Rectangle.Bottom &&
				this.Rectangle.Bottom > entity.Rectangle.Bottom &&
				this.Rectangle.Right > entity.Rectangle.Left &&
				this.Rectangle.Left < entity.Rectangle.Right;
		}

		#endregion
	}
}

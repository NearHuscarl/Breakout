using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Models.Bases
{
	public abstract class MovingObject : GameObject
	{
		public Vector2 Direction;
		public float Velocity { get; set; }

		public MovingObject()
		{

		}

		public MovingObject(int width, int height)
		{
			this.Width = width;
			this.Height = height;
		}

		public MovingObject(int width, int height, Vector2 position)
		{
			this.Width = width;
			this.Height = height;
			this.Position = position;
		}

		#region Collision

		protected bool IsTouchingLeft(GameObject obj)
		{
			return this.Rectangle.Right + this.Direction.X > obj.Rectangle.Left &&
				this.Rectangle.Left < obj.Rectangle.Left &&
				this.Rectangle.Bottom > obj.Rectangle.Top &&
				this.Rectangle.Top < obj.Rectangle.Bottom;
		}

		protected bool IsTouchingRight(GameObject obj)
		{
			return this.Rectangle.Left + this.Direction.X < obj.Rectangle.Right &&
				this.Rectangle.Right > obj.Rectangle.Right &&
				this.Rectangle.Bottom > obj.Rectangle.Top &&
				this.Rectangle.Top < obj.Rectangle.Bottom;
		}

		protected bool IsTouchingTop(GameObject obj)
		{
			return this.Rectangle.Bottom + this.Direction.Y > obj.Rectangle.Top &&
				this.Rectangle.Top < obj.Rectangle.Top &&
				this.Rectangle.Right > obj.Rectangle.Left &&
				this.Rectangle.Left < obj.Rectangle.Right;
		}

		protected bool IsTouchingBottom(GameObject obj)
		{
			return this.Rectangle.Top + this.Direction.Y < obj.Rectangle.Bottom &&
				this.Rectangle.Bottom > obj.Rectangle.Bottom &&
				this.Rectangle.Right > obj.Rectangle.Left &&
				this.Rectangle.Left < obj.Rectangle.Right;
		}

		#endregion
	}
}

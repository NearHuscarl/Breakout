using Breakout.Models.Meta;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Models.Bases
{
	public abstract class DynamicObject : GameObject
	{
		public Vector2 Direction;
		public virtual float Velocity { get; set; }

		public DynamicObject()
		{

		}

		public DynamicObject(int width, int height)
		{
			this.Width = width;
			this.Height = height;
		}

		public DynamicObject(int width, int height, Vector2 position)
		{
			this.Width = width;
			this.Height = height;
			this.Position = position;
		}

		/// <summary>
		/// Method to describe certain action when this object is hit with another
		/// Dynamic Object
		/// </summary>
		public virtual void Hit()
		{

		}

		/// <summary>
		/// Move to new position based on current Direction and Velocity
		/// </summary>
		/// <param name="elapsed"></param>
		public virtual void UpdateMovement(float elapsed)
		{
			Position += Direction * Velocity * elapsed;
		}

		public bool IsOffBottom()
		{
			if (this.Position.Y + this.Height > GameInfo.Screen.Height)
			{
				return true;
			}
			return false;
		}

		public bool IsHittingLeftWall()
		{
			if (Position.X <= 0)
				return true;

			return false;
		}

		public bool IsHittingRightWall()
		{
			if (Position.X + Width >= GameInfo.Screen.Width)
				return true;

			return false;
		}

		public bool IsHittingRoof()
		{
			if (Position.Y <= 0)
				return true;

			return false;
		}

		public bool IsSameXDirection(DynamicObject obj)
		{
			return (this.Direction.X > 0 && obj.Direction.X > 0) ||
				(this.Direction.X < 0 && obj.Direction.X < 0);
		}

		public bool IsOppositeXDirection(DynamicObject obj)
		{
			return (this.Direction.X < 0 && obj.Direction.X > 0) ||
				(this.Direction.X < 0 && obj.Direction.X > 0);
		}

		public bool IsSameYDirection(DynamicObject obj)
		{
			return (this.Direction.Y > 0 && obj.Direction.Y > 0) ||
				(this.Direction.Y < 0 && obj.Direction.Y < 0);
		}

		public bool IsOppositeYDirection(DynamicObject obj)
		{
			return (this.Direction.Y > 0 && obj.Direction.Y > 0) ||
				(this.Direction.Y < 0 && obj.Direction.Y < 0);
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

		public bool IsTouching(GameObject obj)
		{
			return IsTouchingLeft(obj) ||
				IsTouchingRight(obj) ||
				IsTouchingTop(obj) ||
				IsTouchingBottom(obj);
		}

		#endregion
	}
}

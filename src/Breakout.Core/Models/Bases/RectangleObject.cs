using Breakout.Core.Models.Shapes;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Core.Models.Bases
{
	public class RectangleObject : DynamicObject, IRectangle
	{
		public Rectangle Rectangle
		{
			get
			{
				return new Rectangle((int)Position.X, (int)Position.Y, Width, Height);
			}
		}

		public RectangleObject()
		{

		}
		
		public RectangleObject(int width, int height, Vector2 position)
		{
			this.Width = width;
			this.Height = height;
			this.Position = position;
		}

		#region Collision

		protected bool IsTouchingLeftTop(RectangleObject obj)
		{
			return this.Rectangle.Right + this.Direction.X > obj.Rectangle.Left &&
				this.Rectangle.Left < obj.Rectangle.Left &&
				this.Rectangle.Top < obj.Rectangle.Top &&
				this.Rectangle.Bottom > obj.Rectangle.Top;
		}

		protected bool IsTouchingRightTop(RectangleObject obj)
		{
			return this.Rectangle.Left + this.Direction.X < obj.Rectangle.Right &&
				this.Rectangle.Right > obj.Rectangle.Right &&
				this.Rectangle.Top < obj.Rectangle.Top &&
				this.Rectangle.Bottom > obj.Rectangle.Top;
		}

		protected bool IsTouchingLeftBottom(RectangleObject obj)
		{
			return this.Rectangle.Right + this.Direction.X > obj.Rectangle.Left &&
				this.Rectangle.Left < obj.Rectangle.Left &&
				this.Rectangle.Bottom > obj.Rectangle.Bottom &&
				this.Rectangle.Top < obj.Rectangle.Bottom;
		}

		protected bool IsTouchingRightBottom(RectangleObject obj)
		{
			return this.Rectangle.Left + this.Direction.X < obj.Rectangle.Right &&
				this.Rectangle.Right > obj.Rectangle.Right &&
				this.Rectangle.Bottom > obj.Rectangle.Bottom &&
				this.Rectangle.Top < obj.Rectangle.Bottom;
		}

		protected bool IsTouchingTop(RectangleObject obj)
		{
			return this.Rectangle.Bottom + this.Direction.Y > obj.Rectangle.Top &&
				this.Rectangle.Top < obj.Rectangle.Top &&
				this.Rectangle.Right > obj.Rectangle.Left &&
				this.Rectangle.Left < obj.Rectangle.Right;
		}

		protected bool IsTouchingBottom(RectangleObject obj)
		{
			return this.Rectangle.Top + this.Direction.Y < obj.Rectangle.Bottom &&
				this.Rectangle.Bottom > obj.Rectangle.Bottom &&
				this.Rectangle.Right > obj.Rectangle.Left &&
				this.Rectangle.Left < obj.Rectangle.Right;
		}

		protected bool IsTouchingLeft(RectangleObject obj)
		{
			return this.Rectangle.Right + this.Direction.X > obj.Rectangle.Left &&
				this.Rectangle.Left < obj.Rectangle.Left &&
				this.Rectangle.Bottom > obj.Rectangle.Top &&
				this.Rectangle.Top < obj.Rectangle.Bottom;
		}

		protected bool IsTouchingRight(RectangleObject obj)
		{
			return this.Rectangle.Left + this.Direction.X < obj.Rectangle.Right &&
				this.Rectangle.Right > obj.Rectangle.Right &&
				this.Rectangle.Bottom > obj.Rectangle.Top &&
				this.Rectangle.Top < obj.Rectangle.Bottom;
		}

		protected bool IsTouchingTop(CircleObject obj)
		{
			return this.Rectangle.Bottom + this.Direction.Y > obj.Circle.Top &&
				this.Rectangle.Top < obj.Circle.Top &&
				this.Rectangle.Right > obj.Circle.Left &&
				this.Rectangle.Left < obj.Circle.Right;
		}

		protected bool IsTouchingBottom(CircleObject obj)
		{
			return this.Rectangle.Top + this.Direction.Y < obj.Circle.Bottom &&
				this.Rectangle.Bottom > obj.Circle.Bottom &&
				this.Rectangle.Right > obj.Circle.Left &&
				this.Rectangle.Left < obj.Circle.Right;
		}

		protected bool IsTouchingLeft(CircleObject obj)
		{
			return this.Rectangle.Right + this.Direction.X > obj.Circle.Left &&
				this.Rectangle.Left < obj.Circle.Left &&
				this.Rectangle.Bottom > obj.Circle.Top &&
				this.Rectangle.Top < obj.Circle.Bottom;
		}

		protected bool IsTouchingRight(CircleObject obj)
		{
			return this.Rectangle.Left + this.Direction.X < obj.Circle.Right &&
				this.Rectangle.Right > obj.Circle.Right &&
				this.Rectangle.Bottom > obj.Circle.Top &&
				this.Rectangle.Top < obj.Circle.Bottom;
		}

		public bool IsTouching(RectangleObject obj)
		{
			if (this.Rectangle.Intersects(obj.Rectangle))
				return true;

			return false;
		}

		public bool IsTouching(CircleObject obj)
		{
			if (this.IsTouchingTop(obj) ||
				this.IsTouchingBottom(obj) ||
				this.IsTouchingLeft(obj) ||
				this.IsTouchingRight(obj))
				return true;

			return false;
		}

		#endregion
	}
}

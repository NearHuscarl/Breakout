using Breakout.Models.Shapes;
using Microsoft.Xna.Framework;

namespace Breakout.Models.Bases
{
	public class CircleObject : DynamicObject, ICircle
	{
		public int Radius { get; set; }
		public Circle Circle
		{
			get
			{
				return new Circle((int)Position.X + Radius, (int)Position.Y + Radius, Radius);
			}
		}

		public CircleObject()
		{

		}

		public CircleObject(int radius, Vector2 position)
		{
			Radius = radius;
			Position = position;
		}

		protected bool IsTouchingLeft(IInteractive obj)
		{
			return this.Circle.Right + this.Direction.X > obj.Rectangle.Left &&
				this.Circle.Left < obj.Rectangle.Left &&
				this.Circle.Bottom > obj.Rectangle.Top &&
				this.Circle.Top < obj.Rectangle.Bottom;
		}

		protected bool IsTouchingRight(IInteractive obj)
		{
			return this.Circle.Left + this.Direction.X < obj.Rectangle.Right &&
				this.Circle.Right > obj.Rectangle.Right &&
				this.Circle.Bottom > obj.Rectangle.Top &&
				this.Circle.Top < obj.Rectangle.Bottom;
		}

		protected bool IsTouchingTop(IInteractive obj)
		{
			return this.Circle.Bottom + this.Direction.Y > obj.Rectangle.Top &&
				this.Circle.Top < obj.Rectangle.Top &&
				this.Circle.Right > obj.Rectangle.Left &&
				this.Circle.Left < obj.Rectangle.Right;
		}

		protected bool IsTouchingBottom(IInteractive obj)
		{
			return this.Circle.Top + this.Direction.Y < obj.Rectangle.Bottom &&
				this.Circle.Bottom > obj.Rectangle.Bottom &&
				this.Circle.Right > obj.Rectangle.Left &&
				this.Circle.Left < obj.Rectangle.Right;
		}
	}
}

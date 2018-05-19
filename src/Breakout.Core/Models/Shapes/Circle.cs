using Microsoft.Xna.Framework;

namespace Breakout.Core.Models.Shapes
{
	public struct Circle
	{
		public int Radius { get; private set; }

		public int X { get; private set; }
		public int Y { get; private set; }

		public int Top
		{
			get { return Y - Radius; }
		}

		public int Bottom
		{
			get { return Y + Radius; }
		}

		public int Left
		{
			get { return X - Radius; }
		}

		public int Right
		{
			get { return X + Radius; }
		}

		public Circle(int x, int y, int radius)
		{
			Radius = radius;
			X = x;
			Y = y;
		}

		public bool Intersects(Rectangle rectangle)
		{
			// Find the closest point to the circle within the rectangle
			float closestX = MathHelper.Clamp(this.X, rectangle.Left, rectangle.Right);
			float closestY = MathHelper.Clamp(this.Y, rectangle.Top, rectangle.Bottom);

			// TODO: refactor this to use Vector2.Length()
			// Calculate the distance between the circle's center and this closest point
			float distanceX = this.X - closestX;
			float distanceY = this.Y - closestY;

			// If the distance is less than the circle's radius, an intersection occurs
			float distanceSquared = (distanceX * distanceX) + (distanceY * distanceY);
			return distanceSquared < (this.Radius * this.Radius);
		}

		public bool Intersects(Circle circle)
		{
			// put simply, if the distance between the circle centre's is less than
			// their combined radius
			var centre0 = new Vector2(circle.X, circle.Y);
			var centre1 = new Vector2(X, Y);
			return Vector2.Distance(centre0, centre1) < Radius + circle.Radius;
		}

		#region Collision

		//public bool IsTouchingLeft(Rectangle)

		#endregion
	}
}

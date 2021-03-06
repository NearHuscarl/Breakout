﻿using Breakout.Core.Utilities.GameMath;
using Microsoft.Xna.Framework;

namespace Breakout.Core.Models.Bases
{
	public abstract class DynamicObject : GameObject
	{
		protected Scene scene;

		public Vector2 Direction;
		public virtual float Velocity { get; set; }

		// In monogame, Y is inverted compared to X and Y in math
		public float Angle
		{
			get
			{
				Vector2 invertedYDir = new Vector2(Direction.X, -Direction.Y);

				return GeometryMath.Vector2Angle(invertedYDir);
			}
			set
			{
				Direction = GeometryMath.Angle2Vector(-value);
			}
		}

		protected void ReflectHorizontally()
		{
			Direction.X = -Direction.X;
			Angle += RandomMath.RandomBetween(-4f, 4f);
		}

		protected void ReflectVertically()
		{
			Direction.Y = -Direction.Y;
			Angle += RandomMath.RandomBetween(-4f, 4f);
		}

		/// <summary>
		/// Move to new position based on current Direction and Velocity
		/// </summary>
		/// <param name="elapsed"></param>
		public virtual void UpdateMovement(float elapsed)
		{
			Position += Direction * Velocity * elapsed;
		}

		#region Is Hitting Edges

		public bool IsOffBottom(Vector2 position)
		{
			if (position.Y + this.Height > GlobalData.Screen.Height)
			{
				return true;
			}
			return false;
		}

		public bool IsHittingLeftWall(Vector2 position)
		{
			if (position.X <= 0)
				return true;

			return false;
		}

		public bool IsHittingRightWall(Vector2 position)
		{
			if (position.X + Width >= GlobalData.Screen.Width)
				return true;

			return false;
		}

		public bool IsHittingRoof(Vector2 position)
		{
			if (position.Y <= 0)
				return true;

			return false;
		}

		public bool IsOffBottom()
		{
			if (this.Position.Y + this.Height > GlobalData.Screen.Height)
			{
				return true;
			}
			return false;
		}

		public bool IsCompletelyOffBottom()
		{
			if (this.Position.Y > GlobalData.Screen.Height)
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
			if (Position.X + Width >= GlobalData.Screen.Width)
				return true;

			return false;
		}

		public bool IsHittingRoof()
		{
			if (Position.Y <= 0)
				return true;

			return false;
		}

		#endregion

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
	}
}

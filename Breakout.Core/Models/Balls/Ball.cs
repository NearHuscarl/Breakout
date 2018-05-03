using Breakout.Models.Bases;
using Breakout.Models.Interfaces;
using Breakout.Models.Meta;
using Breakout.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Models.Balls
{
	public class Ball : MovingObject
	{
		public float Radius
		{
			get
			{
				return Width / 2;
			}
			set
			{
				this.Width = this.Height = (int)(value * 2);
			}
		}
		public int Strength { get; set; }

		public Ball(float radius, int strength, float velocity)
		{
			this.Width = this.Height = (int)(radius * 2);

			this.Position = new Vector2()
			{
				X = GameInfo.Screen.Width / 2 - Width / 2,
				Y = GameInfo.Screen.Height * 0.8f,
			};

			this.Velocity = 250f;
		}

		public void ResetPosition()
		{
			var direction = RandomMath.RandomBetween(0, 4);

			switch (direction)
			{
				case 0:
					Direction = new Vector2(1, 1);
					break;
				case 1:
					Direction = new Vector2(1, -1);
					break;
				case 2:
					Direction = new Vector2(-1, -1);
					break;
				case 3:
					Direction = new Vector2(-1, 1);
					break;
			}
		}

		public bool IsOffBottom()
		{
			if (this.Position.Y + this.Height > GameInfo.Screen.Height)
			{
				return true;
			}
			return false;
		}

		private bool IsHittingLeftWall()
		{
			if (Position.X <= 0)
				return true;

			return false;
		}

		private bool IsHittingRightWall()
		{
			if (Position.X + Width >= GameInfo.Screen.Width)
				return true;

			return false;
		}

		private bool IsHittingRoof()
		{
			if (Position.Y <= 0)
				return true;

			return false;
		}

		public void HandleWallCollision()
		{
			if (this.IsHittingLeftWall() || this.IsHittingRightWall())
				Direction.X = -Direction.X;

			if (this.IsHittingRoof())
				Direction.Y = -Direction.Y;
		}

		public void HandleCollision(MovingObject entity)
		{
			if (Direction.X > 0 && IsTouchingLeft(entity))
				Direction.X = -Direction.X;

			if (Direction.X < 0 && IsTouchingRight(entity))
				Direction.X = -Direction.X;

			if (Direction.Y > 0 && IsTouchingTop(entity))
				Direction.Y = -Direction.Y;

			if (Direction.Y < 0 && IsTouchingBottom(entity))
				Direction.Y = -Direction.Y;
		}

		public void UpdateMovement(float elapsed)
		{
			Position += Direction * Velocity * elapsed;
		}
	}
}

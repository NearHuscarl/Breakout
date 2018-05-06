using Breakout.Models.Bases;
using Breakout.Models.Meta;
using Breakout.Models.Paddles;
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
	public class Ball : OctilinearObject
	{
		public float MaxVelocity { get; set; }
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
				Y = GameInfo.Screen.Height * 0.7f,
			};

			this.Velocity = 320f;
			this.MaxVelocity = 520f;
		}

		public void ResetPosition()
		{
			var angle = RandomMath.RandomBoolean() ?
				RandomMath.RandomBetween(45, 135) : RandomMath.RandomBetween(225, 315);

			ChangeDirection(angle);
		}

		public void HandleWallCollision()
		{
			if (this.IsHittingLeftWall() || this.IsHittingRightWall())
				Direction.X = -Direction.X;

			if (this.IsHittingRoof())
				Direction.Y = -Direction.Y;
		}

		private void ReflectHorizontally()
		{
			Direction.X = -Direction.X;
			ChangeDirection(Angle + RandomMath.RandomBetween(-4f, 4f));
		}

		private void ReflectVertically()
		{
			Direction.Y = -Direction.Y;
			ChangeDirection(Angle + RandomMath.RandomBetween(-4f, 4f));
		}

		/// <summary>
		/// Solve collision between ball and another object. Return true
		/// if collision happens, false if not
		/// </summary>
		/// <param name="obj">object to check collision with</param>
		/// <returns>Determite if ball hit object</returns>
		public bool HandleCollision(DynamicObject obj)
		{
			bool isCollided = false;

			if (Direction.X > 0 && IsTouchingLeft(obj))
			{
				ReflectHorizontally();
				obj.Hit();
				isCollided = true;
			}

			if (Direction.X < 0 && IsTouchingRight(obj))
			{
				ReflectHorizontally();
				obj.Hit();
				isCollided = true;
			}

			if (Direction.Y > 0 && IsTouchingTop(obj))
			{
				ReflectVertically();
				obj.Hit();
				isCollided = true;
			}

			if (Direction.Y < 0 && IsTouchingBottom(obj))
			{
				ReflectVertically();
				obj.Hit();
				isCollided = true;
			}

			return isCollided;
		}

		/// <summary>
		/// When ball hits paddle, it will not reflect back normally like when
		/// it's hitting wall or block. But instead, it will simply bound back
		/// on the left side if it hits the left side of the paddle and vice versa
		///           __
		///          |\      |
		///            \     |
		///             \   ╲|╱
		///   1          \   │               0                             -1 --> percentOffset
		///               \.-|-.             | - 90 degree
		///               /\ |  \            |
		///               \ \|  /            |
		///   180 degree   '-.-'             |                              0 degree
		///   +--------------│---------------|-+----------------------------+
		///   |              │               |                              | --> Paddle Object
		///   +--------------│---------------|------------------------------+
		///                  │               │
		/// ballCenterXPos ──┘               │
		///                                  └──── paddleCenterXPos
		/// </summary>
		/// <param name="paddle"></param>
		public void HandlePaddleCollision(Paddle paddle)
		{
			if (IsTouchingTop(paddle))
			{
				float ballCenterXPos = this.Position.X + this.Width / 2;
				float paddleCenterXPos = paddle.Position.X + paddle.Width / 2;
				float percentOffset = (paddleCenterXPos - ballCenterXPos) * 1 / (paddle.Width / 2);

				ChangeDirection(90 + percentOffset * 90);
			}

			else if (Direction.Y > 0 && IsTouchingLeft(paddle))
				ReflectHorizontally();

			else if (Direction.X < 0 && IsTouchingRight(paddle))
				ReflectHorizontally();

			else if (Direction.Y < 0 && IsTouchingBottom(paddle))
				ReflectVertically();
		}

		public override void UpdateMovement(float elapsed)
		{
			Position += Direction * MathHelper.Clamp(Velocity, 0, MaxVelocity) * elapsed;
		}
	}
}

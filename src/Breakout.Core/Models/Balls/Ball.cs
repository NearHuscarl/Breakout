using Breakout.Models.Bases;
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
	public class Ball : CircleObject
	{
		private float velocity;

		#region Properties

		public float MaxVelocity { get; set; }
		public float MinVelocity { get; set; }

		public override float Velocity
		{
			set
			{
				float diff = CurrentVelocity - Velocity;

				velocity = value;
				CurrentVelocity = velocity + diff;
			}
			get
			{
				return velocity;
			}
		}

		/// <summary>
		/// Ball + Paddle velocity. If not equal to this.Velocity
		/// It will gradually move toward this.Velocity
		/// </summary>
		public float CurrentVelocity { get; set; }

		public int Strength { get; set; }

		public float Angle
		{
			get
			{
				Vector2 invertedYDir = new Vector2(Direction.X, -Direction.Y);

				return GeometryMath.Vector2Angle(invertedYDir);
			}
		}

		#endregion

		public Ball(int radius, int strength, float velocity, Vector2 position) : base(radius, position)
		{
			this.Radius = radius;
			this.Width = this.Height = (Radius * 2);
			this.Position = position;

			this.Velocity = velocity;
			this.MinVelocity = velocity - 200;
			this.MaxVelocity = velocity + 200;

			this.CurrentVelocity = Velocity;
		}

		public void ResetPosition()
		{
			var angle = RandomMath.RandomBoolean() ?
				RandomMath.RandomBetween(45, 135) : RandomMath.RandomBetween(225, 315);

			ChangeDirection(angle);
		}

		/// <summary>
		/// isContained is a boolean value. If true the bottom will act as
		/// a wall and the ball will bounce back. Used for ball in menu
		/// </summary>
		/// <param name="isContained"></param>
		public void HandleWallCollision(bool isContained=false)
		{
			if (this.IsHittingLeftWall() || this.IsHittingRightWall())
			{
				Direction.X = -Direction.X;
				AudioManager.PlaySound("HitWall");
			}

			if (this.IsHittingRoof() || (this.IsOffBottom() && isContained == true))
			{
				Direction.Y = -Direction.Y;
				AudioManager.PlaySound("HitWall");
			}
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
		public bool HandleCollision(IInteractive obj)
		{
			bool isCollided = false;

			if (Direction.X > 0 && IsTouchingLeft(obj))
			{
				ReflectHorizontally();
				obj.Hit();
				isCollided = true;
			}

			else if (Direction.X < 0 && IsTouchingRight(obj))
			{
				ReflectHorizontally();
				obj.Hit();
				isCollided = true;
			}

			else if (Direction.Y > 0 && IsTouchingTop(obj))
			{
				ReflectVertically();
				obj.Hit();
				isCollided = true;
			}

			else if (Direction.Y < 0 && IsTouchingBottom(obj))
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
		///   0          \   │              0.5                             1 --> paddle contact
		///               \.-|-.             | - 90 degree
		///               /\ |  \            |
		///               \ \|  /            |
		///   180 degree   '-.-'             |                              0 degree
		///   +--------------│---------------|-+----------------------------+
		///   |              │               |                              | --> Paddle Object
		///   +--------------│---------------|------------------------------+
		///                  │
		///  collisionPosX ──┘
		///
		/// </summary>
		/// <param name="paddle"></param>
		public void HandlePaddleCollision(Paddle paddle)
		{
			if (IsTouchingTop(paddle))
			{
				float collisionPosX = this.Position.X + this.Width / 2;
				float paddleContact = (collisionPosX - paddle.Position.X) / paddle.Width;
				float ballReturnedAngle = MathHelper.Lerp(180, 0, paddleContact);

				ChangeDirection(ballReturnedAngle);
				paddle.Hit();
			}

			else if (Direction.Y > 0 && IsTouchingLeft(paddle) || Direction.X < 0 && IsTouchingRight(paddle))
			{
				paddle.Hit();
				ReflectHorizontally();
			}

			//else if (Direction.Y < 0 && IsTouchingBottom(paddle))
			//	ReflectVertically();


			if (this.IsSameXDirection(paddle))
				CurrentVelocity += paddle.Velocity;

			if (this.IsOppositeXDirection(paddle))
				CurrentVelocity -= paddle.Velocity;
		}

		public override void UpdateMovement(float elapsed)
		{
			if (CurrentVelocity > Velocity)
				CurrentVelocity--;

			if (CurrentVelocity < Velocity)
				CurrentVelocity++;

			Position += Direction * MathHelper.Clamp(CurrentVelocity, MinVelocity, MaxVelocity) * elapsed;

			// Fix a bug when ball stuck at wall border when both paddle and wall jam the ball at 2 edges
			Position.X = MathHelper.Clamp(Position.X, 0, GameInfo.Screen.Width - this.Width);
		}
	}
}

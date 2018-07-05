using System;
using Breakout.Core.Models.Bases;
using Breakout.Core.Models.Paddles;
using Breakout.Core.Utilities.Audio;
using Breakout.Core.Utilities.GameMath;
using Microsoft.Xna.Framework;
using Breakout.Core.Models.Enums;
using System.Collections.Generic;
using Breakout.Extensions;

namespace Breakout.Core.Models.Balls
{
	public class Ball : CircleObject
	{
		private BallSize size = BallSize.Medium;
		private BallStrength strength = BallStrength.Normal;
		private float velocity;

		#region Properties

		public static readonly Dictionary<BallSize, int> RadiusDict = new Dictionary<BallSize, int>()
		{
			{ BallSize.Small, 11 },
			{ BallSize.Medium, 17 },
			{ BallSize.Big, 23 },	
		};

		public BallSize Size
		{
			get { return size; }
			set
			{
				Position.X -= (RadiusDict[value] - RadiusDict[Size]) / 2;
				size = value;
				ClampPosition();

				switch (value)
				{
					case BallSize.Small:
						Velocity = BaseVelocity + 150;
						break;

					case BallSize.Medium:
						Velocity = BaseVelocity;
						break;

					case BallSize.Big:
						Velocity = BaseVelocity -= 50;
						break;
				}
			}
		}

		public BallStrength Strength
		{
			get { return strength; }
			set
			{
				strength = value;
				// TODO: set damage for block
			}
		}

		public bool IsAttached { get; set; } = false; // is attach to magnetized paddle

		public float BaseVelocity { get; private set; }
		public float MaxVelocity { get; private set; }
		public float MinVelocity { get; private set; }

		public override float Velocity
		{
			get { return velocity; }

			set
			{
				var diff = CurrentVelocity - Velocity;

				velocity = MathHelper.Clamp(value, MinVelocity, MaxVelocity);
				CurrentVelocity = velocity + diff;
			}
		}

		public override int Width
		{
			get { return RadiusDict[Size]; }
			set { }
		}

		public override int Height
		{
			get { return RadiusDict[Size]; }
			set { }
		}

		public override int Radius
		{
			get { return RadiusDict[Size] / 2; }
			set { }
		}

		/// <summary>
		/// Ball + Paddle velocity. If not equal to this.Velocity
		/// It will gradually move toward this.Velocity
		/// </summary>
		public float CurrentVelocity { get; set; }

		#endregion

		public Ball(Scene scene, Vector2 position)
		{
			this.scene = scene;

			this.Position = position;

			if (GlobalData.Settings.Difficulty == Difficulty.Hard)
				this.BaseVelocity = 440f;
			else
				this.BaseVelocity = 360f;

			// Order is important
			this.MinVelocity = BaseVelocity - 100;
			this.MaxVelocity = BaseVelocity + 300;
			this.Velocity = BaseVelocity;

			this.CurrentVelocity = Velocity;
			this.Position = position;
		}

		public void IncreaseSize()
		{
			//Position.X -= (Radius[Size.Next()] - Lengths[Length]) / 2;
			//Length = Length.Next();
			//ClampPosition();
		}

		public void DecreaseSize()
		{
			//Position.X += (Lengths[Length] - Lengths[Length.Previous()]) / 2;
			//Length = Length.Previous();
			//ClampPosition();
		}

		public Ball ShallowCopy()
		{
			return (Ball)this.MemberwiseClone();
		}

		private void ClampPosition()
		{
			Position.X = MathHelper.Clamp(Position.X, 0, GlobalData.Screen.Width - this.Width);
			Position.Y = MathHelper.Clamp(Position.Y, 0, GlobalData.Screen.Height - this.Height);
		}

		public void ResetPosition()
		{
			Angle = RandomMath.RandomBoolean() ?
				RandomMath.RandomBetween(45, 135) : RandomMath.RandomBetween(225, 315);
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
				AudioManager.PlaySound("HitWall", percent: scene.Volume);
			}

			if (this.IsHittingRoof() || (this.IsOffBottom() && isContained == true))
			{
				Direction.Y = -Direction.Y;
				AudioManager.PlaySound("HitWall", percent: scene.Volume);
			}
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
				obj.Hit(this);
				isCollided = true;
			}

			else if (Direction.X < 0 && IsTouchingRight(obj))
			{
				ReflectHorizontally();
				obj.Hit(this);
				isCollided = true;
			}

			else if (Direction.Y > 0 && IsTouchingTop(obj))
			{
				ReflectVertically();
				obj.Hit(this);
				isCollided = true;
			}

			else if (Direction.Y < 0 && IsTouchingBottom(obj))
			{
				ReflectVertically();
				obj.Hit(this);
				isCollided = true;
			}

			return isCollided;
		}

		/// <summary>
		/// When the ball hits the paddle, it will not reflect back normally like when
		/// it's hitting wall or block. But instead, it will simply bound back
		/// on the left side if it hits the left side of the paddle and vice versa
		///           __
		///          |\      |
		///            \     |
		///             \   ╲|╱
		///   0          \   │              0.5                             1 --> contact area
		///               \.-|-.             | - 90 degree
		///               /\ |  \            |
		///               \ \|  /            |
		///   180 degree   '-.-'             |                              0 degree
		///   +--------------│---------------|-+----------------------------+
		///   |              │               |                              | --> Paddle Object
		///   +--------------│---------------|------------------------------+
		/// </summary>
		public void BounceBack(Paddle paddle)
		{
			if (IsTouchingTop(paddle))
			{
				float contactArea = paddle.GetPaddleContactArea(this);
				float bounceBackAngle = paddle.GetBounceBackAngle(contactArea);

				Angle = bounceBackAngle;
				paddle.Hit(this);
			}
			else if (Direction.Y > 0 && IsTouchingLeft(paddle) || Direction.X < 0 && IsTouchingRight(paddle))
			{
				paddle.Hit(this);
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
			if (IsAttached)
				return;

			if (CurrentVelocity > Velocity)
				CurrentVelocity--;

			if (CurrentVelocity < Velocity)
				CurrentVelocity++;

			Position += Direction * CurrentVelocity * elapsed;

			// Fix a bug when ball stuck at wall border when both paddle and wall jam the ball at 2 edges
			Position.X = MathHelper.Clamp(Position.X, 0, GlobalData.Screen.Width - this.Width);
		}
	}
}

using Breakout.Core.Models.Balls;
using Breakout.Core.Models.Bases;
using Breakout.Core.Models.Enums;
using Breakout.Core.Utilities.Audio;
using Breakout.Extensions;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Breakout.Core.Models.Paddles
{
	public class Paddle : RectangleObject, IInteractive
	{
		private Vector2 oldPosition;
		private PaddleLength length;

		#region Properties

		public static readonly Dictionary<PaddleLength, int> Lengths = new Dictionary<PaddleLength, int>()
		{
			{ PaddleLength.ExtraShort, 80 },
			{ PaddleLength.Short, 100 },
			{ PaddleLength.Medium, 120 },
			{ PaddleLength.Long, 135 },
			{ PaddleLength.ExtraLong, 150 },
		};

		public PaddleLength Length
		{
			get { return length; }
			set
			{
				Position.X -= (Lengths[value] - Lengths[Length]) / 2;
				length = value;
				ClampPosition();
			}
		}

		public override int Width
		{
			get { return Lengths[Length]; }
		}

		#endregion


		public Paddle(Scene scene, int height)
		{
			this.Height = height;
			this.scene = scene;

			this.Position = new Vector2()
			{
				X = GlobalData.Screen.Width / 2 - Width / 2,
				Y = GlobalData.Screen.Height - Height - 30,
			};

			switch (GlobalData.Settings.Difficulty)
			{
				case Difficulty.Easy:
					this.Length = PaddleLength.Long;
					this.Velocity = 800f;
					break;

				case Difficulty.Normal:
					this.Length = PaddleLength.Medium;
					this.Velocity = 800f;
					break;

				case Difficulty.Hard:
					this.Length = PaddleLength.Short;
					this.Velocity = 1000f;
					break;
			}
		}

		public void CopyAttributes(Paddle paddle)
		{
			this.Position = paddle.Position;
			this.Length = paddle.Length;
		}

		private void ClampPosition()
		{
			if (this.IsHittingLeftWall())
				Position.X = 0;
			else if (this.IsHittingRightWall())
				Position.X = GlobalData.Screen.Width - Width;
		}

		public void DriftLeft(float elapsed)
		{
			Direction = new Vector2(-1, 0);
			MoveHorizontally(0.1f * elapsed);
		}

		public void DriftRight(float elapsed)
		{
			Direction = new Vector2(1, 0);
			MoveHorizontally(0.1f * elapsed);
		}

		public void MoveLeft(float elapsed)
		{
			Direction = new Vector2(-1, 0);
			MoveHorizontally(elapsed);
		}

		public void MoveRight(float elapsed)
		{
			Direction = new Vector2(1, 0);
			MoveHorizontally(elapsed);
		}

		private void MoveHorizontally(float elapsed)
		{
			oldPosition = Position;
			Position += Direction * Velocity * elapsed;

			if (this.IsHittingLeftWall())
			{
				Position.X = 0;

				if (!this.IsHittingLeftWall(oldPosition))
					AudioManager.PlaySound("PaddleHitWall", percent: scene.Volume);
			}

			if (this.IsHittingRightWall())
			{
				Position.X = GlobalData.Screen.Width - Width;

				if (!this.IsHittingRightWall(oldPosition))
					AudioManager.PlaySound("PaddleHitWall", percent: scene.Volume);
			}

			Direction = Vector2.Zero;
		}

		public virtual void HandleBall(Ball ball)
		{
			ball.BounceBack(this);
		}

		public virtual void Hit(object src)
		{
			AudioManager.PlaySound("HitPaddle", percent: scene.Volume);
		}

		/// <summary>
		///                .-*-.
		///               /     \
		///               \     /
		///   0            '-.-'            0.5                             1 --> contact area
		///   +--------------│---------------|------------------------------+
		///   |              │               |                              | --> Paddle Object
		///   +--------------│---------------|------------------------------+
		///                  │
		///  collisionPosX ──┘
		///
		/// </summary>
		public float GetPaddleContactArea(Ball ball)
		{
			float collisionPosX = ball.Position.X + ball.Width / 2;

			return (collisionPosX - this.Position.X) / this.Width;
		}

		public float GetBounceBackAngle(float contactArea)
		{
			return MathHelper.Lerp(160, 20, contactArea);
		}
	}
}

using Breakout.Core.Models.Bases;
using Breakout.Core.Models.Enums;
using Breakout.Core.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Core.Models.Paddles
{
	public class Paddle : RectangleObject, IInteractive
	{
		private Vector2 oldPosition;

		private static readonly Dictionary<PaddleLength, int> lengthDict = new Dictionary<PaddleLength, int>()
		{
			{ PaddleLength.ExtraShort, 80 },
			{ PaddleLength.Short, 100 },
			{ PaddleLength.Medium, 120 },
			{ PaddleLength.Long, 135 },
			{ PaddleLength.ExtraLong, 150 },
		};

		public PaddleLength Length { get; private set; }

		public override int Width
		{
			get
			{
				return lengthDict[Length];
			}
		}

		public Paddle(Scene scene, PaddleLength length, int height, float velocity) : base(lengthDict[length], height)
		{
			this.scene = scene;
			this.Length = length;

			this.Position = new Vector2()
			{
				X = GameInfo.Screen.Width / 2 - Width / 2,
				Y = GameInfo.Screen.Height - Height - 30,
			};

			this.Velocity = velocity;
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
				Position.X = GameInfo.Screen.Width - Width;

				if (!this.IsHittingRightWall(oldPosition))
					AudioManager.PlaySound("PaddleHitWall", percent: scene.Volume);
			}

			Direction = Vector2.Zero;
		}

		public void ModifyLength(int offset)
		{
			Width += offset;
		}

		public void Hit()
		{
			AudioManager.PlaySound("HitPaddle", percent: scene.Volume);
		}
	}
}

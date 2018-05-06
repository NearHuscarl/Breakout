using Breakout.Models.Bases;
using Breakout.Models.Meta;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Models.Paddles
{
	public class Paddle : DynamicObject
	{
		public int Length
		{
			get
			{
				return this.Width;
			}
			set
			{
				this.Width = value;
			}
		}

		public Paddle(int width, int height) : base(width, height)
		{
			this.Length = width;

			this.Position = new Vector2()
			{
				X = GameInfo.Screen.Width / 2 - Width / 2,
				Y = GameInfo.Screen.Height - Height - 30,
			};

			this.Velocity = 800f;
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
			Position += Direction * Velocity * elapsed;
			Position.X = MathHelper.Clamp(Position.X, 0, GameInfo.Screen.Width - Width);
			Direction = Vector2.Zero;
		}

		public void ModifyLength(int offset)
		{
			Length += offset;
		}
	}
}

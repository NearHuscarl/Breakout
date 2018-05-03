using Breakout.Models.Bases;
using Breakout.Models.Interfaces;
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
				Y = GameInfo.Screen.Height - Height - 10,
			};

			this.Velocity = 800f;
		}

		public void MoveLeft(float elapsed)
		{
			MoveHorizontally(-this.Velocity * elapsed);
		}

		public void MoveRight(float elapsed)
		{
			MoveHorizontally(this.Velocity * elapsed);
		}

		private void MoveHorizontally(float offset)
		{
			Position.X += offset;
			Position.X = MathHelper.Clamp(Position.X, 0, GameInfo.Screen.Width - Width);
		}

		public void ModifyLength(int offset)
		{
			Length += offset;
		}
	}
}

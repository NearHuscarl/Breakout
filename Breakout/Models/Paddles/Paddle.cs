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
	public class Paddle : Entity
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

		public float Velocity { get; set; }

		public Paddle(int width, int height) : base(width, height)
		{
			this.Length = width;

			this.Position = new Vector2()
			{
				X = GameInfo.Screen.Width / 2 - Width / 2,
				Y = GameInfo.Screen.Height - Height - 10,
			};
		}

		public void ModifyLength(int offset)
		{
			Length += offset;
		}
	}
}

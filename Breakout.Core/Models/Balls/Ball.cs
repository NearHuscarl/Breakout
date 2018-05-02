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

namespace Breakout.Models.Balls
{
	public class Ball : Entity
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
		public Vector2 Direction;

		public Ball(float radius, int strength, float velocity)
		{
			this.Width = this.Height = (int)(radius * 2);

			this.Position = new Vector2()
			{
				X = GameInfo.Screen.Width / 2 - Width / 2,
				Y = GameInfo.Screen.Height * 0.8f,
			};
		}

		public bool IsOffBottom()
		{
			if (this.Position.Y + this.Height > GameInfo.Screen.Height)
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
			if (Position.X + Width >= GameInfo.Screen.Width)
				return true;

			return false;
		}

		public bool IsHittingRoof()
		{
			if (Position.Y <= 0)
				return true;

			return false;
		}
	}
}

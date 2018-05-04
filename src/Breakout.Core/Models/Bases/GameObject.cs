using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Models.Bases
{
	public abstract class GameObject
	{
		public int Width { get; set; }
		public int Height { get; set; }
		public Vector2 Position;
		public Rectangle Rectangle
		{
			get
			{
				return new Rectangle((int)Position.X, (int)Position.Y, Width, Height);
			}
		}
	}
}

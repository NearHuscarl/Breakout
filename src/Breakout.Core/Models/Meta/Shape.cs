using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Models.Meta
{
	public class Shape
	{
		public int Width { get; set; }
		public int Height { get; set; }

		public Vector2 Position { get; set; }

		public float X
		{
			get
			{
				return Position.X;
			}
		}

		public float Y
		{
			get
			{
				return Position.Y;
			}
		}

		public Shape()
		{

		}

		public Shape(int width, int height)
		{
			Width = width;
			Height = height;
			Position = new Vector2();
		}

		public Shape(int width, int height, Vector2 position)
		{
			Width = width;
			Height = height;
			Position = position;
		}
	}
}

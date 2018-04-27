using Breakout.Models.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Models.Paddles
{
	public class Paddle : IPaddle
	{
		public Vector2 Position { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public Texture2D Texture { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public void MoveLeft(int speed)
		{
			throw new NotImplementedException();
		}

		public void MoveRight(int speed)
		{
			throw new NotImplementedException();
		}
	}
}

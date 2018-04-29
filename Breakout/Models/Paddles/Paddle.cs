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
		public int Length { get; set; }
		public float Velocity { get; set; }
		
		public void ModifyLength(int offset)
		{
			Length+= offset;
		}
	}
}

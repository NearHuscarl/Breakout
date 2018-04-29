using Breakout.Models.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Models.Balls
{
	public class Ball : IBall
	{
		public int Radius { get; set; }
		public int Strength { get; set; }
		public int Velocity { get; set; }
	}
}

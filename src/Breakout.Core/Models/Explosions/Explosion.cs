using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Models.Explosions
{
	public class Explosion
	{
		public Rectangle Rectangle { get; set; }
		public float Timer { get; set; }

		/// <summary>
		/// Boom when Active
		/// </summary>
		public bool Active
		{
			get
			{
				if (Timer < 0)
					return true;

				return false;
			}
		}

		public Explosion(Rectangle rectangle)
		{
			Rectangle = rectangle;
			Timer = 0.1f;
		}
	}
}

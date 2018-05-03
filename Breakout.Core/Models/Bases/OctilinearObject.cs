using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Models.Bases
{
	/// <summary>
	/// Game Objects that can move orthogonal and diagonal
	/// </summary>
	public class OctilinearObject : DynamicObject
	{
		private float rotation;

		public void ChangeDirection(float angle)
		{
			Direction = new Vector2()
			{
				X = (float)Math.Cos(MathHelper.ToRadians(rotation + angle)),
				Y = (float)Math.Sin(MathHelper.ToRadians(rotation + angle)),
			};
		}
	}
}

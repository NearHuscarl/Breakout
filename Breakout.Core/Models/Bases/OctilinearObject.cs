using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Models.Bases
{
	/// <summary>
	/// Game Objects that can move orthogonally and diagonally
	/// </summary>
	public class OctilinearObject : DynamicObject
	{
		/// <summary>
		/// Current angle in degree of OctilinearObject
		/// </summary>
		public float Angle
		{
			get
			{
				float radian = (float)Math.Atan2(-Direction.Y, Direction.X);
				float degree = radian * (180f / (float)Math.PI);

				return degree;
			}
		}

		public void ChangeDirection(float angle)
		{
			float radian = MathHelper.ToRadians(-angle);

			Direction = new Vector2()
			{
				X = (float)Math.Cos(radian),
				Y = (float)Math.Sin(radian),
			};
		}
	}
}

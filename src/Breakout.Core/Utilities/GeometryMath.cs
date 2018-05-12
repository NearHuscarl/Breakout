using Microsoft.Xna.Framework;
using System;

namespace Breakout.Utilities
{
	public static class GeometryMath
	{
		public static Vector2 Angle2Vector(float angle)
		{
			float radian = MathHelper.ToRadians(angle);

			return new Vector2()
			{
				X = (float)Math.Cos(radian),
				Y = (float)Math.Sin(radian),
			};
		}

		public static float Vector2Angle(Vector2 direction)
		{
			float radian = (float)Math.Atan2(direction.Y, direction.X);
			float degree = radian * (180f / (float)Math.PI);

			return degree;
		}

		public static Vector2 ReflectedDirection(Vector2 directionIn, float normalAngle)
		{
			float angleIn = Vector2Angle(directionIn);
			float angleOut = angleIn - 2 * (angleIn - normalAngle);

			return Angle2Vector(angleOut);
		}
	}
}

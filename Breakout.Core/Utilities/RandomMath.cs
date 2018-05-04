using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Utilities
{
	public static class RandomMath
	{
		private static Random random = new Random();
		public static Random Random
		{
			get
			{
				return random;
			}
		}

		public static bool RandomBoolean()
		{
			return random.Next(1, 3) == 1 ? true : false;
		}

		public static int RandomBetween(int minValue, int maxValue)
		{
			return random.Next(minValue, maxValue);
		}

		public static float RandomBetween(float minValue, float maxValue)
		{
			return minValue + (float)random.NextDouble() * (maxValue - minValue);
		}

		public static double RandomBetween(double minValue, double maxValue)
		{
			return minValue + random.NextDouble() * (maxValue - minValue);
		}

		public static Vector2 RandomDirection()
		{
			float angle = RandomBetween(0, MathHelper.TwoPi);
			Vector2 direction = new Vector2
			{
				X = (float)Math.Cos(angle),
				Y = (float)Math.Sin(angle),
			};

			return direction;
		}
		
		public static Vector2 RandomDirection(float minAngle, float maxAngle)
		{
			float angle = RandomBetween(MathHelper.ToRadians(minAngle), MathHelper.ToRadians(maxAngle)) - MathHelper.PiOver2;
			Vector2 direction = new Vector2
			{
				X = (float)Math.Cos(angle),
				Y = (float)Math.Sin(angle),
			};

			return direction;
		}

		public static bool RandomPercent(float percentage)
		{
			return random.NextDouble() * 100 < percentage;
		}

		public static T RandomEnum<T>()
		{
			var enumValues = Enum.GetValues(typeof(T));

			return (T) enumValues.GetValue(random.Next(enumValues.Length));
		}
	}
}

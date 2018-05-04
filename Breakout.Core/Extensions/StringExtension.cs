using Microsoft.Xna.Framework;
using System;

namespace Breakout.Extensions
{
	public static class StringExtension
	{
		public static Color ToColor(this string str)
		{
			if (str.StartsWith("#"))
				str = str.Substring(1);

			if (str.Length != 6)
				throw new Exception("Color not valid");

			return new Color(
					int.Parse(str.Substring(0, 2), System.Globalization.NumberStyles.HexNumber),
					int.Parse(str.Substring(2, 2), System.Globalization.NumberStyles.HexNumber),
					int.Parse(str.Substring(4, 2), System.Globalization.NumberStyles.HexNumber));
		}
	}
}

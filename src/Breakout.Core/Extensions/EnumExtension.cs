using System;

namespace Breakout.Extensions
{
	public static class EnumExtension
	{
		private enum Direction
		{
			Next,
			Previous,
		}

		private static void CheckType<T>()
		{
			if (!typeof(T).IsEnum)
			{
				throw new ArgumentException(string.Format("Argumnent {0} is not an Enum", typeof(T).FullName));
			}
		}

		public static T ParseEnum<T>(string value) where T : struct
		{
			return (T)Enum.Parse(typeof(T), value, ignoreCase: true);
		}

		private static T Move<T>(this T currentEnum, Direction direction) where T : struct
		{
			CheckType<T>();

			T[] enums = (T[])Enum.GetValues(currentEnum.GetType());
			int currentIndex = Array.IndexOf<T>(enums, currentEnum);

			if (direction == Direction.Next)
			{
				return (currentIndex == enums.Length - 1) ? enums[currentIndex] : enums[currentIndex + 1];
			}
			return (currentIndex == 0) ? enums[currentIndex] : enums[currentIndex - 1];
		}

		public static T Next<T>(this T currentEnum) where T : struct
		{
			return Move(currentEnum, Direction.Next);
		}

		public static T Previous<T>(this T currentEnum) where T : struct
		{
			return Move(currentEnum, Direction.Previous);
		}
	}
}

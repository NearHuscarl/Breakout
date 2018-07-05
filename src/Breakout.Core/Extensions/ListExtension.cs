using System.Collections;
using System.Collections.Generic;

namespace Breakout.Extensions
{
	public static class ListExtension
	{
		public static void AddIfNotNull<T>(this List<T> list, T item)
		{
			if (item != null)
				list.Add(item);
		}

		/// <summary>
		/// IList.Cleaer() alternative to remove all items in an ObservableCollection
		/// and trigger remove event
		/// </summary>
		/// <param name="list"></param>
		public static void RemoveAll(this IList list)
		{
			while (list.Count > 0)
			{
				list.RemoveAt(list.Count - 1);
			}
		}
	}
}

using Breakout.Core.Views.Screens;
using System.Collections.Generic;

namespace Breakout.Core.Views
{
	public static class WindowManager
	{
		public static List<Screen> Screens { get; private set; } = new List<Screen>();
		public static Screen CurrentScreen { get { return Screens[Screens.Count - 1]; } }

		public static void Open(Screen screen)
		{
			Screens.Add(screen);
		}

		/// <summary>
		/// Close top-most window
		/// </summary>
		public static void CloseWindow()
		{
			Screens.RemoveAt(Screens.Count - 1);
		}

		public static void CloseAllWindows()
		{
			Screens.Clear();
		}
	}
}

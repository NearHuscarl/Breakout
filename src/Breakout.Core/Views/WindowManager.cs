using Breakout.Views.Screens;
using System.Collections.Generic;

namespace Breakout.Views
{
	public static class WindowManager
	{
		public static List<Screen> Screens { get; set; } = new List<Screen>();

		public static void OpenMenu()
		{
			Screens.Clear();
			Screens.Add(new MenuScreen());
		}

		public static void OpenAbout()
		{
			Screens.Add(new AboutScreen());
		}

		public static void OpenSetting()
		{
			Screens.Add(new SettingScreen());
		}

		public static void OpenExitGamePrompt()
		{
			MessageBox msgBox = new MessageBox(title: "Exit Confirmation", text: "Are you sure to exit current game?");
			Screens.Add(msgBox);
		}

		public static void OpenExitAppPrompt()
		{
			MessageBox msgBox = new MessageBox(title: "Exit Confirmation", text: "Are you sure to quit game?");
			Screens.Add(msgBox);
		}

		/// <summary>
		/// Close top-most window
		/// </summary>
		public static void CloseWindow()
		{
			Screens.RemoveAt(Screens.Count - 1);
		}
	}
}

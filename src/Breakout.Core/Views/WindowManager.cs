using Breakout.Core.Views.Screens;
using System.Collections.Generic;

namespace Breakout.Core.Views
{
	public static class WindowManager
	{
		public static List<Screen> Screens { get; private set; } = new List<Screen>();

		public static void OpenMenu(out MenuScreen menuScreen)
		{
			Screens.Clear();
			Screens.Add(menuScreen = new MenuScreen());
		}

		public static void OpenAbout(out AboutScreen aboutScreen)
		{
			Screens.Add(aboutScreen = new AboutScreen());
		}

		public static void OpenSetting(out SettingScreen settingScreen)
		{
			Screens.Add(settingScreen = new SettingScreen());
		}

		public static void OpenRestartWindow(out MessageBox msgBox)
		{
			msgBox = new MessageBox(title: "Game Over", text: "Do you want to restart game?");
			Screens.Add(msgBox);
		}

		public static void OpenExitGamePrompt(out MessageBox msgBox)
		{
			msgBox = new MessageBox(title: "Exit Confirmation", text: "Are you sure to exit current game?");
			Screens.Add(msgBox);
		}

		public static void OpenExitAppPrompt(out MessageBox msgBox)
		{
			msgBox = new MessageBox(title: "Exit Confirmation", text: "Are you sure to quit game?");
			Screens.Add(msgBox);
		}

		public static void OpenWinningWindow(out WinningScreen winningScreen)
		{
			Screens.Add(winningScreen = new WinningScreen());
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

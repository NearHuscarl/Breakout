using Breakout.Models.UIComponents;

namespace Breakout.Models.Windows
{
	public static class WindowManager
	{
		public static GameScreen CurrentScreen { get; set; }

		public static void OpenExitGamePrompt()
		{
			CurrentScreen = new MessageBox(title: "Exit Confirmation", text: "Are you sure to exit current game?");
		}

		public static void OpenExitAppPrompt()
		{
			CurrentScreen = new MessageBox(title: "Exit Confirmation", text: "Are you sure to quit game?");
		}

		public static void OpenAbout()
		{
			CurrentScreen = new AboutScreen();
		}

		public static void OpenSetting()
		{
			CurrentScreen = new SettingScreen();
		}

		public static void CloseWindow()
		{
			CurrentScreen = null;
		}
	}
}

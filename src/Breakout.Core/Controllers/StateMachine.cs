using Breakout.Core.Controllers.BaseStates;
using Breakout.Core.Controllers.GameStates;
using Breakout.Core.Controllers.MenuStates;
using Breakout.Core.Models;
using Breakout.Core.Models.IO;
using Breakout.Core.Utilities.Audio;
using Breakout.Core.Utilities.Map;
using Breakout.Core.Views;
using Breakout.Core.Views.Screens;
using Microsoft.Xna.Framework;

namespace Breakout.Core.Controllers
{
	public static class StateMachine
	{
		public static Scene Scene;

		public static State PreviousState;
		public static State CurrentState;

		private static MenuState menuState;
		private static SettingState settingState;
		private static AboutState aboutState;
		private static OverwriteState overwriteState;
		private static PlayState gameState;
		private static PauseState pauseState;
		private static RestartState restartState;
		private static WinningState winningState;
		private static WinAllState winAllState;
		private static ExitGameState exitGameState;
		private static ExitAppState exitAppState;

		public static void Initialize(Scene scene)
		{
			Scene = scene;

			menuState = new MenuState();
			settingState = new SettingState();
			aboutState = new AboutState();
			overwriteState = new OverwriteState();
			gameState = new PlayState();
			pauseState = new PauseState();
			restartState = new RestartState();
			winningState = new WinningState();
			winAllState = new WinAllState();
			exitGameState = new ExitGameState();
			exitAppState = new ExitAppState();

			InitializeGame();
		}

		private static void InitializeGame()
		{
			GlobalData.Screen = new Rectangle()
			{
				Width = EntryPoint.Game.Graphics.PreferredBackBufferWidth,
				Height = EntryPoint.Game.Graphics.PreferredBackBufferHeight,
			};

			GlobalData.Initialize();

			AudioManager.LoadSound(EntryPoint.Game.Content);
			AudioManager.IsMute = GlobalData.Settings.IsMute;

			MapManager.Initialize(EntryPoint.Game.Content);

			Input.SetDefaultInput();

			OpenMenu();
		}

		// Highscore window
		//  1. Name Score
		//  2. Name Score
		//  ..
		//  10. Name Score
		//  Button: back

		private static void ChangeState(State state)
		{
			PreviousState = CurrentState;

			if (WindowManager.Screens.Count > 1)
				Scene.IsBackground = true;
			else
				Scene.IsBackground = false;

			CurrentState = state;
		}

		public static void ChangeToPreviousState()
		{
			WindowManager.CloseWindow();
			ChangeState(PreviousState);
			PreviousState = null;
		}

		#region Change State Event

		public static void OpenMenu()
		{
			Scene.InitializeMenu();

			WindowManager.CloseAllWindows();
			WindowManager.Open(new MenuScreen());
			ChangeState(menuState);
		}

		public static void OpenAbout()
		{
			WindowManager.Open(new AboutScreen());
			ChangeState(aboutState);
		}

		public static void OpenSetting()
		{
			WindowManager.Open(new SettingScreen());
			ChangeState(settingState);
		}

		public static void OpenOverwriteConfirm()
		{
			WindowManager.Open(new MessageBox(title: "Overwrite Confirmation", text: "Start a new game will overwrite old save file. Are you sure about that?"));
			ChangeState(overwriteState);
		}

		public static void PlayGame()
		{
			ChangeState(gameState);
		}

		public static void ResetGame()
		{
			AudioManager.PlaySound("LoseLive");
			Scene.Player.Live--;
			Scene.Reset();

			PauseGame();
		}

		public static void Restart()
		{
			Scene.InitializeGame(GlobalData.Session);
			PauseGame();
		}

		public static void GameOver()
		{
			WindowManager.Open(new MessageBox(title: "Game Over", text: "Do you want to restart game?"));
			ChangeState(restartState);
		}

		public static void WinGame()
		{
			AudioManager.PlaySound("WinGame", percent: 1.5f);

			// Avg score:
			// Time Bonus: 200 (5 mins)
			// Raw: 3000
			// Max Combo: 3 * 300 * 0.3 = 300
			// --> 3500
			WinningScreen winningScreen = new WinningScreen();

			winningScreen.Title.Text = $"Level {GlobalData.Session.CurrentLevel.ToString()} Passed!";

			// 1 mins: 1 / 60  * 70000 -> 1166
			// 3 mins: 1 / 180 * 70000 -> 388
			// 5 mins: 1 / 300 * 70000 -> 233

			int rawScore = Scene.Player.Score.Score;
			int timeBonus = (1 / Scene.Timer.Counter) * 70000;
			int comboScore = Scene.Player.HighestCombo * 5;

			winningScreen.TimeBonusUpdateAmount = timeBonus / Scene.Timer.Counter;

			Scene.FinalScore = rawScore + timeBonus + comboScore;

			WindowManager.Open(winningScreen);
			ChangeState(winningState);
		}

		public static void WinAll()
		{
			AudioManager.PlaySong("WinAllGame");

			WindowManager.Open(new WinAllScreen());
			ChangeState(winAllState);
		}

		public static void Exit()
		{
			EntryPoint.Game.Exit();
		}

		public static void PauseGame()
		{
			ChangeState(pauseState);
		}

		public static void ExitGame()
		{
			AudioManager.PlaySound("Interrupt");

			WindowManager.Open(new MessageBox(title: "Exit Confirmation", text: "Are you sure to exit current game?"));
			ChangeState(exitGameState);
		}

		public static void ExitApp()
		{
			AudioManager.PlaySound("Interrupt");

			WindowManager.Open(new MessageBox(title: "Exit Confirmation", text: "Are you sure to quit game?"));
			ChangeState(exitAppState);
		}

		#endregion
	}
}

using Breakout.Controllers.States;
using Breakout.Models;
using Breakout.Utilities;
using Breakout.Views;

namespace Breakout.Controllers
{
	public static class StateMachine
	{
		public static Scene Scene;

		public static State PreviousState;
		public static State CurrentState;

		private static InitialState initialState;
		private static MenuState menuState;
		private static SettingState settingState;
		private static AboutState aboutState;
		private static LoadingState loadingState;
		private static GameState gameState;
		private static PauseState pauseState;
		private static ExitGameState exitGameState;
		private static ExitAppState exitAppState;

		public static void Initialize(Scene scene)
		{
			Scene = scene;

			initialState = new InitialState();
			menuState = new MenuState();
			settingState = new SettingState();
			aboutState = new AboutState();
			loadingState = new LoadingState();
			gameState = new GameState();
			pauseState = new PauseState();
			exitGameState = new ExitGameState();
			exitAppState = new ExitAppState();

			CurrentState = initialState;
			CurrentState.Update();
		}

		// Prompt to exit window / game (x2)
		//  Are you sure to exit?
		//  Button: yes, no

		// Pass window
		//  Level n completed
		//  Score: xxx
		//  Button: continue

		// Setting window
		//  Sound: Mute checkbox
		//  Difficulties: Easy normal hard radio
		//  Button: apply, cancel

		// About window
		//  Author: Near Huscarl
		//  Source code: https://github.com/NearHuscarl/Breakout
		//  License: BSD 3-Clauses
		//  Button: back

		// Highscore window
		//  1. Name Score
		//  2. Name Score
		//  ..
		//  10. Name Score
		//  Button: back

		private static void ChangeState(State nextState)
		{
			// InitialState -> MenuState (init game)
			// MenuState -> LoadingState (load game)
			// MenuState -> AboutState (about window)
			// LoadingState -> PauseState (start game)
			// PauseState -> GameState (play game)
			// GameState -> PauseState (pause/reset game)
			// GameState -> ExitGameState (confirm restart/abort)
			// ExitGameState -> LoadingState (restart)
			// ExitGameState -> MenuState (abort)
			PreviousState = CurrentState;
			CurrentState = nextState;
		}

		public static void ChangeToPreviousState()
		{
			WindowManager.CloseWindow();
			CurrentState = PreviousState;
			PreviousState = null;
		}

		#region Change State Event

		public static void OpenMenu()
		{
			Scene.InitializeMenu();

			WindowManager.OpenMenu();
			menuState.AddScreen();
			ChangeState(menuState);
		}

		public static void OpenAbout()
		{
			WindowManager.OpenAbout();
			aboutState.AddScreen();
			ChangeState(aboutState);
		}

		public static void OpenSetting()
		{
			WindowManager.OpenSetting();
			settingState.AddScreen();
			ChangeState(settingState);
		}

		public static void LoadGame()
		{
			WindowManager.CloseWindow(); // Close menu window
			ChangeState(loadingState);
		}

		public static void StartGame()
		{
			ChangeState(pauseState);
		}

		public static void PlayGame()
		{
			ChangeState(gameState);
		}

		public static void ResetGame()
		{
			AudioManager.PlaySound("LoseLive");
			Scene.Player.Live.Take(1);
			Scene.Reset();

			ChangeState(pauseState);
		}

		public static void GameOver()
		{
			OpenMenu(); // TODO: Prompt asking to continue or not
		}

		public static void Exit()
		{
			EntryPoint.Game.Exit();
		}

		public static void PauseGame()
		{
			ChangeState(pauseState);
		}

		public static void ResumeGame()
		{
			//WindowManager.CloseWindow();
			ChangeToPreviousState();
		}

		public static void ExitGame()
		{
			AudioManager.PlaySound("Interrupt");

			WindowManager.OpenExitGamePrompt();
			exitGameState.AddScreen();
			ChangeState(exitGameState);
		}

		public static void ExitApp()
		{
			AudioManager.PlaySound("Interrupt");

			WindowManager.OpenExitAppPrompt();
			exitAppState.AddScreen();
			ChangeState(exitAppState);
		}

		#endregion
	}
}

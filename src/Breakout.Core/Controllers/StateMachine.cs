using Breakout.Core.Controllers.Levels;
using Breakout.Core.Controllers.States;
using Breakout.Core.Models;
using Breakout.Core.Utilities;
using Breakout.Core.Views;
using Breakout.Core.Views.Loaders;

namespace Breakout.Core.Controllers
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
		private static GameState gameState;
		private static PauseState pauseState;
		private static RestartState restartState;
		private static WinningState winningState;
		private static ExitGameState exitGameState;
		private static ExitAppState exitAppState;

		public static void Initialize(Scene scene)
		{
			Scene = scene;

			initialState = new InitialState();
			menuState = new MenuState();
			settingState = new SettingState();
			aboutState = new AboutState();
			gameState = new GameState();
			pauseState = new PauseState();
			restartState = new RestartState();
			winningState = new WinningState();
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
			if (WindowManager.Screens.Count > 1)
			{
				Scene.IsBackground = true;
			}
			else
			{
				Scene.IsBackground = false;
			}

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
			ChangeState(PreviousState);
			PreviousState = null;
		}

		#region Change State Event

		public static void OpenMenu()
		{
			Scene.InitializeMenu(LevelPicker.Logo);

			menuState.AddScreen();
			ChangeState(menuState);
		}

		public static void OpenAbout()
		{
			aboutState.AddScreen();
			ChangeState(aboutState);
		}

		public static void OpenSetting()
		{
			settingState.AddScreen();
			ChangeState(settingState);
		}

		public static void LoadGame()
		{
			WindowManager.CloseWindow(); // Close menu window

			Scene.InitializeGame(LevelPicker.CurrentLevel);
			ChangeState(pauseState);
		}

		public static void NextLevel()
		{
			WindowManager.CloseWindow();

			LevelPicker.NextLevel();
			Scene.InitializeGame(LevelPicker.CurrentLevel);
			ChangeState(pauseState);
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

			ChangeState(pauseState);
		}

		public static void GameOver()
		{
			restartState.AddScreen();
			ChangeState(restartState);
		}

		public static void WinGame()
		{
			//AudioManager.PlaySound("Winning");
			winningState.AddScreen();
			ChangeState(winningState);
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

			exitGameState.AddScreen();
			ChangeState(exitGameState);
		}

		public static void ExitApp()
		{
			AudioManager.PlaySound("Interrupt");

			exitAppState.AddScreen();
			ChangeState(exitAppState);
		}

		#endregion
	}
}

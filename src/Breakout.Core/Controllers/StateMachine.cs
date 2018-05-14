using Breakout.Controllers.States;
using Breakout.Models;
using Breakout.Models.Windows;
using Breakout.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Controllers
{
	public static class StateMachine
	{
		public static State PreviousState;
		public static State CurrentState;

		public static Dictionary<string, State> States = new Dictionary<string, State>();

		private static InitialState initialState;
		private static MenuState menuState;
		private static SettingState settingState;
		private static AboutState aboutState;
		private static LoadingState loadingState;
		private static GameState gameState;
		private static PauseState pauseState;
		private static ExitGameState exitGameState;
		private static ExitAppState exitAppState;

		public static void Initialize()
		{
			initialState = new InitialState();
			menuState = new MenuState();
			settingState = new SettingState();
			aboutState = new AboutState();
			loadingState = new LoadingState();
			gameState = new GameState();
			pauseState = new PauseState();
			exitGameState = new ExitGameState();
			exitAppState = new ExitAppState();

			States.Add("InitialState", initialState);
			States.Add("MenuState", menuState);
			States.Add("SettingState", settingState);
			States.Add("AboutState", aboutState);
			States.Add("LoadingState", loadingState);
			States.Add("GameState", gameState);
			States.Add("PauseState", pauseState);
			States.Add("ExitGameState", exitGameState);
			States.Add("ExitAppState", exitAppState);
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

		private static void ChangeState(string nextState)
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
			CurrentState = States[nextState];
		}

		public static void ChangeToPreviousState()
		{
			CurrentState = PreviousState;
			PreviousState = null;
		}

		#region change state event

		public static void OpenMenu()
		{
			EntryPoint.Game.Scene.InitializeMenu();
			ChangeState("MenuState");
		}

		public static void OpenAbout()
		{
			WindowManager.OpenAbout();
			ChangeState("AboutState");
		}

		public static void OpenSetting()
		{
			WindowManager.OpenSetting();
			ChangeState("SettingState");
		}

		public static void LoadGame()
		{
			ChangeState("LoadingState");
		}

		public static void StartGame()
		{
			ChangeState("PauseState");
		}

		public static void PlayGame()
		{
			ChangeState("GameState");
		}

		public static void ResetGame()
		{
			AudioManager.PlaySound("LoseLive");
			EntryPoint.Game.Scene.Player.Live.Take(1);
			EntryPoint.Game.Scene.Reset();

			ChangeState("PauseState");
		}

		public static void GameOver()
		{
			ChangeState("MenuState"); // TODO: Prompt asking to continue or not
		}

		public static void Exit()
		{
			EntryPoint.Game.Scene.CleanUp();
			EntryPoint.Game.Exit();
		}

		public static void ExitToMenu()
		{
			EntryPoint.Game.Scene.CleanUp();
			EntryPoint.Game.Scene.InitializeMenu();
			ChangeState("MenuState");
		}

		public static void PauseGame()
		{
			ChangeState("PauseState");
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

			ChangeState("ExitGameState");
		}

		public static void ExitApp()
		{
			AudioManager.PlaySound("Interrupt");
			WindowManager.OpenExitAppPrompt();

			ChangeState("ExitAppState");
		}

		#endregion
	}
}

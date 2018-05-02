using Breakout.Controllers.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Controllers
{
	public static class StateMachine
	{
		public static State CurrentState;
		public static Dictionary<string, State> States = new Dictionary<string, State>();

		private static InitialState initialState;
		private static MenuState menuState;
		private static CreditState creditState;
		private static LoadingState loadingState;
		private static GameState gameState;
		private static PauseState pauseState;
		private static ConfirmState confirmState;

		public static void Initialize()
		{
			initialState = new InitialState();
			menuState = new MenuState();
			creditState = new CreditState();
			loadingState = new LoadingState();
			gameState = new GameState();
			pauseState = new PauseState();
			confirmState = new ConfirmState();

			States.Add("InitialState", initialState);
			States.Add("MenuState", menuState);
			States.Add("CreditState", creditState);
			States.Add("LoadingState", loadingState);
			States.Add("GameState", gameState);
			States.Add("PauseState", pauseState);
			States.Add("ConfirmState", confirmState);
		}

		public static void ChangeState(string nextState)
		{
			// InitialState -> MenuState (init game)
			// MenuState -> LoadingState (load game)
			// LoadingState -> PauseState (start game)
			// PauseState -> GameState (play game)
			// GameState -> PauseState (pause/gameover)
			// GameState -> ConfirmState (confirm restart/abort)
			// ConfirmState -> LoadingState (restart)
			// ConfirmState -> MenuState (abort)
			CurrentState = States[nextState];
		}
	}
}

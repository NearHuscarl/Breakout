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

		private static MenuState menuState;
		private static CreditState creditState;
		private static InitialState initialState;
		private static GameState gameState;
		private static PauseState pauseState;

		public static void Initialize()
		{
			menuState = new MenuState();
			initialState = new InitialState();
			gameState = new GameState();
			pauseState = new PauseState();

			States.Add("MenuState", menuState);
			States.Add("CreditState", creditState);
			States.Add("InitialState", initialState);
			States.Add("GameState", gameState);
			States.Add("PauseState", pauseState);
		}

		public static void ChangeState(string nextState)
		{
			// MenuState
			// MenuState -> InitialState (load game)
			// InitalState -> GameState (start game)
			// GameState -> PauseState (pause)
			// GameState -> InitialState (restart)
			// GameState -> MenuState (abort)
			CurrentState = States[nextState];
		}
	}
}

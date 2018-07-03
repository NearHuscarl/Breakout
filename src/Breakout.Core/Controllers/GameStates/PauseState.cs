using Breakout.Core.Controllers.BaseStates;
using Breakout.Core.Models.IO;
using Breakout.Core.Utilities.Helper;
using Breakout.Core.Views.Renderers;

namespace Breakout.Core.Controllers.GameStates
{
	public class PauseState : GameState
	{
		public override void Update()
		{
			base.Update();

			if (InputHelper.IsNewKeyPress(Input.PlayGame))
			{
				StateMachine.PlayGame();
			}
			else if (InputHelper.IsNewKeyPress(Input.Exit))
			{
				StateMachine.ExitGame();
			}
		}
	}
}

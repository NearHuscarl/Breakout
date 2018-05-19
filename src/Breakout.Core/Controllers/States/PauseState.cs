using Breakout.Core.Models.IO;
using Breakout.Core.Utilities;
using Breakout.Core.Views.Renderers;

namespace Breakout.Core.Controllers.States
{
	public class PauseState : State
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

		public override void Draw(MonoGameRenderer renderer)
		{
			renderer.DrawGame(EntryPoint.Game.Elapsed);
		}
	}
}

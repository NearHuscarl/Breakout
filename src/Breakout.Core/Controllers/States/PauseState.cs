using Breakout.Models.IO;
using Breakout.Utilities;
using Breakout.Views.Renderers;

namespace Breakout.Controllers.States
{
	public class PauseState : State
	{
		public override void Update()
		{
			base.Update();

			if (InputHelper.IsNewKeyPress(Input.PlayGame))
				StateMachine.PlayGame();

			else if (InputHelper.IsNewKeyPress(Input.Exit))
				StateMachine.ExitGame();
		}

		public override void Draw(MonoGameRenderer renderer)
		{
			renderer.DrawGame(EntryPoint.Game.Elapsed);
		}
	}
}

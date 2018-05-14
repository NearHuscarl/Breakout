using Breakout.Models;
using Breakout.Models.IO;
using Breakout.Models.UIComponents;
using Breakout.Models.Windows;
using Breakout.Utilities;
using Breakout.Views.Renderers;

namespace Breakout.Controllers.States
{
	public class ExitAppState : State
	{
		public override void Update()
		{
			base.Update();

			MessageBox exitPrompt = (MessageBox)WindowManager.CurrentScreen;

			Button yesButton = exitPrompt.YesButton;
			Button noButton = exitPrompt.NoButton;

			if (InputHelper.IsNewKeyPress(Input.Exit))
				StateMachine.ChangeToPreviousState();

			HandleButton(yesButton, StateMachine.Exit);
			HandleButton(noButton, StateMachine.ChangeToPreviousState);

			EntryPoint.Game.Scene.Step(EntryPoint.Game.Elapsed);
		}

		public override void Draw(MonoGameRenderer renderer)
		{
			renderer.DrawExitPrompt();
		}
	}
}

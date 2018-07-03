using Breakout.Core.Controllers.BaseStates;
using Breakout.Core.Models.IO;
using Breakout.Core.Utilities.Helper;
using Breakout.Core.Views;
using Breakout.Core.Views.Renderers;
using Breakout.Core.Views.Screens;
using Breakout.Core.Views.Windows;

namespace Breakout.Core.Controllers.MenuStates
{
	public class ExitAppState : ScreenState
	{
		public override void Update()
		{
			base.Update();

			var messageBox = (MessageBox)WindowManager.CurrentScreen;

			if (InputHelper.IsNewKeyPress(Input.Exit))
			{
				StateMachine.ChangeToPreviousState();
			}

			Button yesButton = messageBox.YesButton;
			Button noButton = messageBox.NoButton;

			HandleButton(yesButton, StateMachine.Exit);
			HandleButton(noButton, StateMachine.ChangeToPreviousState);

			StateMachine.Scene.Step(EntryPoint.Game.Elapsed);
		}

		public override void Draw(MonoGameRenderer renderer)
		{
			renderer.DrawMenu(EntryPoint.Game.Elapsed);
		}
	}
}

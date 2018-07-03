using Breakout.Core.Controllers.BaseStates;
using Breakout.Core.Models;
using Breakout.Core.Models.IO;
using Breakout.Core.Utilities.Helper;
using Breakout.Core.Views;
using Breakout.Core.Views.Renderers;
using Breakout.Core.Views.Screens;
using Breakout.Core.Views.Windows;

namespace Breakout.Core.Controllers.MenuStates
{
	public class AboutState : ScreenState
	{
		public override void Update()
		{
			base.Update();

			var aboutScreen = (AboutScreen)WindowManager.CurrentScreen;

			if (InputHelper.IsNewKeyPress(Input.Exit))
				StateMachine.ChangeToPreviousState();

			Button openCodeButton = aboutScreen.OpenCodeButton;
			Button cancelButton = aboutScreen.CancelButton;

			HandleButton(openCodeButton, OpenSourceCode);
			HandleButton(cancelButton, StateMachine.ChangeToPreviousState);

			StateMachine.Scene.Step(EntryPoint.Game.Elapsed);
		}

		private void OpenSourceCode()
		{
			System.Diagnostics.Process.Start(GlobalData.SourceCodeURL);
		}

		public override void Draw(MonoGameRenderer renderer)
		{
			renderer.DrawMenu(EntryPoint.Game.Elapsed);
		}
	}
}

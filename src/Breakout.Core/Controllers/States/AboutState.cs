using Breakout.Core.Models;
using Breakout.Core.Models.IO;
using Breakout.Core.Utilities;
using Breakout.Core.Views;
using Breakout.Core.Views.Renderers;
using Breakout.Core.Views.Screens;
using Breakout.Core.Views.Windows;

namespace Breakout.Core.Controllers.States
{
	public class AboutState : State
	{
		private AboutScreen aboutScreen;

		public override void AddScreen()
		{
			WindowManager.OpenAbout(out aboutScreen);
		}

		public override void Update()
		{
			base.Update();

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
			System.Diagnostics.Process.Start(GameInfo.SourceCodeURL);
		}

		public override void Draw(MonoGameRenderer renderer)
		{
			renderer.DrawMenu(EntryPoint.Game.Elapsed);
		}
	}
}

using Breakout.Models;
using Breakout.Models.IO;
using Breakout.Utilities;
using Breakout.Views;
using Breakout.Views.Renderers;
using Breakout.Views.Screens;
using Breakout.Views.Windows;

namespace Breakout.Controllers.States
{
	public class AboutState : State
	{
		private AboutScreen aboutScreen;

		public override void AddScreen()
		{
			foreach (var screen in WindowManager.Screens)
			{
				if (screen is AboutScreen)
				{
					aboutScreen = (AboutScreen)screen;
					return;
				}
			}
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

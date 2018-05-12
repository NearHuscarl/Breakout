using Breakout.Models;
using Breakout.Models.UIComponents;
using Breakout.Models.Windows;
using Breakout.Utilities;
using Breakout.Views.Renderers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Controllers.States
{
	public class AboutState : State
	{
		public override void Update()
		{
			base.Update();

			AboutScreen aboutScreen= (AboutScreen)WindowManager.CurrentScreen;

			Button cancelButton = aboutScreen.CancelButton;
			Button openCodeButton = aboutScreen.OpenCodeButton;

			HandleButton(cancelButton, StateMachine.ChangeToPreviousState);
			HandleButton(openCodeButton, OpenSourceCode);

			Scene.Step(EntryPoint.Game.Elapsed);
		}

		private void OpenSourceCode()
		{
			System.Diagnostics.Process.Start(GameInfo.SourceCodeURL);
		}

		public override void Draw(MonoGameRenderer renderer)
		{
			renderer.DrawAbout();
		}
	}
}

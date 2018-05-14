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

			Button openCodeButton = aboutScreen.OpenCodeButton;
			Button cancelButton = aboutScreen.CancelButton;

			HandleButton(openCodeButton, OpenSourceCode);
			HandleButton(cancelButton, StateMachine.ChangeToPreviousState);

			EntryPoint.Game.Scene.Step(EntryPoint.Game.Elapsed);
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

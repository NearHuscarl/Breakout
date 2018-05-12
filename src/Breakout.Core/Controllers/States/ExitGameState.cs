using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Breakout.Models.IO;
using Breakout.Models.UIComponents;
using Breakout.Models.Windows;
using Breakout.Utilities;
using Breakout.Views.Renderers;

namespace Breakout.Controllers.States
{
	public class ExitGameState : State
	{
		public override void Update()
		{
			base.Update();

			MessageBox exitPrompt = (MessageBox)WindowManager.CurrentScreen;

			Button yesButton = exitPrompt.YesButton;
			Button noButton = exitPrompt.NoButton;

			if (InputHelper.IsNewKeyPress(Input.Exit))
				StateMachine.ResumeGame();

			HandleButton(yesButton, StateMachine.ExitToMenu);
			HandleButton(noButton, StateMachine.ResumeGame);
		}

		public override void Draw(MonoGameRenderer renderer)
		{
			renderer.DrawExitPrompt();
		}
	}
}

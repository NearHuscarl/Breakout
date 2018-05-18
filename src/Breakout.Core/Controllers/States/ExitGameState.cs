using Breakout.Models.IO;
using Breakout.Utilities;
using Breakout.Views;
using Breakout.Views.Renderers;
using Breakout.Views.Screens;
using Breakout.Views.Windows;

namespace Breakout.Controllers.States
{
	public class ExitGameState : State
	{
		private MessageBox messageBox;

		public override void AddScreen()
		{
			foreach (var screen in WindowManager.Screens)
			{
				if (screen is MessageBox)
				{
					messageBox = (MessageBox)screen;
					return;
				}
			}
		}

		public override void Update()
		{
			base.Update();

			if (InputHelper.IsNewKeyPress(Input.Exit))
				StateMachine.ChangeToPreviousState();

			Button yesButton = messageBox.YesButton;
			Button noButton = messageBox.NoButton;

			HandleButton(yesButton, StateMachine.OpenMenu);
			HandleButton(noButton, StateMachine.ResumeGame);
		}

		public override void Draw(MonoGameRenderer renderer)
		{
			renderer.DrawGame(EntryPoint.Game.Elapsed);
		}
	}
}

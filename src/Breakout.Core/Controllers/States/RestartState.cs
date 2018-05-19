using Breakout.Core.Models.IO;
using Breakout.Core.Utilities;
using Breakout.Core.Views;
using Breakout.Core.Views.Renderers;
using Breakout.Core.Views.Screens;
using Breakout.Core.Views.Windows;

namespace Breakout.Core.Controllers.States
{
	public class RestartState : State
	{
		private MessageBox messageBox;

		public override void AddScreen()
		{
			WindowManager.OpenRestartWindow(out messageBox);
		}

		public override void Update()
		{
			base.Update();

			Button yesButton = messageBox.YesButton;
			Button noButton = messageBox.NoButton;

			HandleButton(yesButton, StateMachine.LoadGame);
			HandleButton(noButton, StateMachine.OpenMenu);
		}

		public override void Draw(MonoGameRenderer renderer)
		{
			renderer.DrawGame(EntryPoint.Game.Elapsed);
		}
	}
}

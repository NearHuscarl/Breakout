using Breakout.Core.Controllers.BaseStates;
using Breakout.Core.Views;
using Breakout.Core.Views.Renderers;
using Breakout.Core.Views.Screens;
using Breakout.Core.Views.Windows;

namespace Breakout.Core.Controllers.MenuStates
{
	public class RestartState : ScreenState
	{
		public override void Update()
		{
			base.Update();

			var messageBox = (MessageBox)WindowManager.CurrentScreen;

			Button yesButton = messageBox.YesButton;
			Button noButton = messageBox.NoButton;

			HandleButton(yesButton, Restart);
			HandleButton(noButton, StateMachine.OpenMenu);
		}

		private void Restart()
		{
			WindowManager.CloseWindow();
			StateMachine.Restart();
		}

		public override void Draw(MonoGameRenderer renderer)
		{
			renderer.DrawGame(EntryPoint.Game.Elapsed);
		}
	}
}

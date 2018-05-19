using Breakout.Core.Controllers.Levels;
using Breakout.Core.Models.IO;
using Breakout.Core.Utilities;
using Breakout.Core.Views;
using Breakout.Core.Views.Renderers;
using Breakout.Core.Views.Screens;
using Breakout.Core.Views.Windows;
using Breakout.Core.Views.Loaders;

namespace Breakout.Core.Controllers.States
{
	public class WinningState : State
	{
		private WinningScreen winningScreen;

		public override void AddScreen()
		{
			WindowManager.OpenWinningWindow(out winningScreen);
		}

		public override void Update()
		{
			base.Update();

			Button continueButton = winningScreen.NextButton;

			HandleButton(continueButton, StateMachine.NextLevel);

			if (InputHelper.IsNewKeyPress(Input.Confirm))
			{
				StateMachine.NextLevel();
			}
		}

		public override void Draw(MonoGameRenderer renderer)
		{
			renderer.DrawGame(EntryPoint.Game.Elapsed);
		}
	}
}

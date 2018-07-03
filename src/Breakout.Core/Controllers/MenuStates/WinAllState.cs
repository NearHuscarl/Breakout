using Breakout.Core.Controllers.BaseStates;
using Breakout.Core.Utilities.Audio;
using Breakout.Core.Views;
using Breakout.Core.Views.Renderers;
using Breakout.Core.Views.Screens;
using Breakout.Core.Views.Windows;

namespace Breakout.Core.Controllers.MenuStates
{
	/// <summary>
	/// When you passed all levels, open summarize screen
	/// </summary>
	public class WinAllState : ScreenState
	{
		public override void Update()
		{
			base.Update();

			var winAllScreen = (WinAllScreen)WindowManager.CurrentScreen;

			Button saveButton = winAllScreen.SaveButton;

			HandleButton(saveButton, SaveAndGoBackToMenu);
		}

		public void SaveAndGoBackToMenu()
		{
			StateMachine.OpenMenu();
			AudioManager.StopSong();
		}

		public override void Draw(MonoGameRenderer renderer)
		{
			renderer.DrawGame(EntryPoint.Game.Elapsed);
		}
	}
}

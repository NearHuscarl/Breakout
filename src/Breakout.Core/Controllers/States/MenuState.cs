using Breakout.Core.Views;
using Breakout.Core.Views.Renderers;
using Breakout.Core.Views.Screens;
using Breakout.Core.Views.Windows;

namespace Breakout.Core.Controllers.States
{
	public class MenuState : State
	{
		private MenuScreen menuScreen;

		public override void AddScreen()
		{
			WindowManager.OpenMenu(out menuScreen);
		}

		public override void Update()
		{
			base.Update();

			Button startButton = menuScreen.Buttons["Start"];
			Button settingButton = menuScreen.Buttons["Setting"];
			Button aboutButton = menuScreen.Buttons["About"];
			Button exitButton = menuScreen.Buttons["Exit"];

			HandleButton(startButton, StateMachine.LoadGame);
			HandleButton(settingButton, StateMachine.OpenSetting);
			HandleButton(aboutButton, StateMachine.OpenAbout);
			HandleButton(exitButton, StateMachine.ExitApp);

			StateMachine.Scene.Step(EntryPoint.Game.Elapsed);
		}

		public override void Draw(MonoGameRenderer renderer)
		{
			renderer.DrawMenu(EntryPoint.Game.Elapsed);
		}
	}
}

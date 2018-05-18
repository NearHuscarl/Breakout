using Breakout.Views;
using Breakout.Views.Renderers;
using Breakout.Views.Screens;
using Breakout.Views.Windows;

namespace Breakout.Controllers.States
{
	public class MenuState : State
	{
		private MenuScreen menuScreen;

		public override void AddScreen()
		{
			foreach (var screen in WindowManager.Screens)
			{
				if (screen is MenuScreen)
				{
					menuScreen = (MenuScreen)screen;
					return;
				}
			}
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

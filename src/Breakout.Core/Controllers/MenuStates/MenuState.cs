using Breakout.Core.Controllers.BaseStates;
using Breakout.Core.Models;
using Breakout.Core.Models.IO;
using Breakout.Core.Utilities.Helper;
using Breakout.Core.Views;
using Breakout.Core.Views.Renderers;
using Breakout.Core.Views.Screens;
using Breakout.Core.Views.Windows;

namespace Breakout.Core.Controllers.MenuStates
{
	public class MenuState : ScreenState
	{
		public override void Update()
		{
			base.Update();

			var menuScreen = (MenuScreen)WindowManager.CurrentScreen;

			Button newButton = menuScreen.Buttons["New"];
			Button loadButton = menuScreen.Buttons["Load"];
			Button settingButton = menuScreen.Buttons["Setting"];
			Button aboutButton = menuScreen.Buttons["About"];
			Button exitButton = menuScreen.Buttons["Exit"];

			HandleButton(newButton, StateMachine.OpenOverwriteConfirm);
			HandleButton(loadButton, LoadGame);
			HandleButton(settingButton, StateMachine.OpenSetting);
			HandleButton(aboutButton, StateMachine.OpenAbout);
			HandleButton(exitButton, StateMachine.ExitApp);

			if (InputHelper.IsNewKeyPress(Input.Exit))
			{
				StateMachine.ExitApp();
			}

			StateMachine.Scene.Step(EntryPoint.Game.Elapsed);
		}

		public void LoadGame()
		{
			WindowManager.CloseWindow(); // Close menu window

			StateMachine.Scene.InitializeGame(GlobalData.Session);
			StateMachine.PauseGame();
		}

		public override void Draw(MonoGameRenderer renderer)
		{
			renderer.DrawMenu(EntryPoint.Game.Elapsed);
		}
	}
}

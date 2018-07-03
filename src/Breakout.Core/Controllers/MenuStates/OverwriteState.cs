using Breakout.Core.Controllers.BaseStates;
using Breakout.Core.Models;
using Breakout.Core.Models.Data;
using Breakout.Core.Models.IO;
using Breakout.Core.Utilities.Helper;
using Breakout.Core.Views;
using Breakout.Core.Views.Renderers;
using Breakout.Core.Views.Screens;
using Breakout.Core.Views.Windows;

namespace Breakout.Core.Controllers.MenuStates
{
	/// <summary>
	/// Confirm to override old save session when pressing "New game" button
	/// </summary>
	public class OverwriteState : ScreenState
	{
		public override void Update()
		{
			base.Update();

			var messageBox = (MessageBox)WindowManager.CurrentScreen;

			if (InputHelper.IsNewKeyPress(Input.Exit))
			{
				StateMachine.ChangeToPreviousState();
			}

			Button yesButton = messageBox.YesButton;
			Button noButton = messageBox.NoButton;

			HandleButton(yesButton, NewGame);
			HandleButton(noButton, StateMachine.ChangeToPreviousState);

			StateMachine.Scene.Step(EntryPoint.Game.Elapsed);
		}

		public void NewGame()
		{
			WindowManager.CloseAllWindows(); // Close menu window

			GlobalData.Session = Session.Default;
			StateMachine.Scene.InitializeGame(Session.Default);
			StateMachine.PauseGame();
		}

		public override void Draw(MonoGameRenderer renderer)
		{
			renderer.DrawMenu(EntryPoint.Game.Elapsed);
		}
	}
}

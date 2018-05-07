using Breakout.Models;
using Breakout.Models.Buttons;
using Breakout.Utilities;
using Breakout.Views.Renderers;
using Breakout.Views.UI;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Controllers.States
{
	public class MenuState : State
	{
		private delegate void ButtonClickEventHandler();

		private void LoadGame()
		{
			StateMachine.ChangeState("LoadingState");
		}

		private void OpenCredit()
		{

		}

		private void ExitGame()
		{
			Scene.CleanUp();
			EntryPoint.Game.Exit();
		}

		public override void Update()
		{
			InputHelper.GetInput();

			HandleStartGameButton(LoadGame);
			HandleCreditButton(OpenCredit);
			HandleExitButton(ExitGame);

			Scene.Step(EntryPoint.Game.Elapsed, isMenu: true);
		}

		private void HandleStartGameButton(ButtonClickEventHandler eventHandler)
		{
			ButtonUI startButton = EntryPoint.Game.renderer.StartButton;
			Button startButtonModel = Scene.StartButton;
			HandleButton(startButton, startButtonModel, eventHandler);
		}

		private void HandleCreditButton(ButtonClickEventHandler eventHandler)
		{
			ButtonUI creditButton = EntryPoint.Game.renderer.CreditButton;
			Button creditButtonModel = Scene.CreditButton;
			HandleButton(creditButton, creditButtonModel, eventHandler);
		}

		private void HandleExitButton(ButtonClickEventHandler eventHandler)
		{
			ButtonUI exitButton = EntryPoint.Game.renderer.ExitButton;
			Button exitButtonModel = Scene.ExitButton;
			HandleButton(exitButton, exitButtonModel, eventHandler);
		}

		private void HandleButton(ButtonUI button, Button buttonModel, ButtonClickEventHandler eventHandler)
		{
			bool isMouseOverButton = buttonModel.Rectangle.Contains(InputHelper.GetMousePosition());

			if (!isMouseOverButton)
			{
				button.ChangeToInactiveImage();
				return;
			}

			if (InputHelper.IsMouseHold(MouseButtons.LeftButton))
				button.ChangeToClickedImage();

			else if (InputHelper.IsMouseRelease(MouseButtons.LeftButton))
				eventHandler.Invoke();

			else
				button.ChangeToHoverImage();
		}

		public override void Draw(MonoGameRenderer renderer)
		{
			renderer.DrawMenu();
		}
	}
}

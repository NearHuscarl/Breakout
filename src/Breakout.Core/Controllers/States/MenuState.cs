using Breakout.Models;
using Breakout.Models.Bases;
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
			EntryPoint.Game.Exit();
		}

		public override void Update()
		{
			HandleStartGameButton(LoadGame);
			HandleSettingButton(OpenCredit);
			HandleExitButton(ExitGame);
		}

		private void HandleStartGameButton(ButtonClickEventHandler eventHandler)
		{
			ButtonUI startButton = EntryPoint.Game.renderer.StartButton;
			Button startButtonModel = Scene.StartButton;
			HandleButton(startButton, startButtonModel, LoadGame);
		}

		private void HandleSettingButton(ButtonClickEventHandler eventHandler)
		{
			ButtonUI optionButton = EntryPoint.Game.renderer.CreditButton;
			Button optionButtonModel = Scene.CreditButton;
			HandleButton(optionButton, optionButtonModel, OpenCredit);
		}

		private void HandleExitButton(ButtonClickEventHandler eventHandler)
		{
			ButtonUI exitButton = EntryPoint.Game.renderer.ExitButton;
			Button exitButtonModel = Scene.ExitButton;
			HandleButton(exitButton, exitButtonModel, ExitGame);
		}

		private void HandleButton(ButtonUI button, Button buttonModel,  ButtonClickEventHandler eventHandler)
		{
			bool isMouseOverButton = buttonModel.Rectangle.Contains(Mouse.GetState().X, Mouse.GetState().Y);

			if (isMouseOverButton)
			{
				button.ChangeToHoverImage();
			}
			else
			{
				button.ChangeToInactiveImage();
			}

			if (Mouse.GetState().LeftButton == ButtonState.Pressed && isMouseOverButton)
			{
				eventHandler.Invoke();
			}
		}

		public override void Draw(MonoGameRenderer renderer)
		{
			renderer.DrawMenu();
		}
	}
}

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

		private void StartGame()
		{
			StateMachine.ChangeState("InitialState");
		}

		private void OpenSetting()
		{

		}

		private void ExitGame()
		{
			EntryPoint.Game.Exit();
		}

		public override void Update()
		{
			HandleStartGameButton(StartGame);
			HandleSettingButton(OpenSetting);
			HandleExitButton(ExitGame);
		}

		private void HandleStartGameButton(ButtonClickEventHandler eventHandler)
		{
			Button startGameButton = EntryPoint.Game.renderer.StartGameButton;
			HandleButton(startGameButton, StartGame);
		}

		private void HandleSettingButton(ButtonClickEventHandler eventHandler)
		{
			Button optionButton = EntryPoint.Game.renderer.OptionButton;
			HandleButton(optionButton, OpenSetting);
		}

		private void HandleExitButton(ButtonClickEventHandler eventHandler)
		{
			Button exitButton = EntryPoint.Game.renderer.ExitButton;
			HandleButton(exitButton, ExitGame);
		}

		private void HandleButton(Button button, ButtonClickEventHandler eventHandler)
		{
			bool isMouseOverButton = button.Sprite.Rectangle.Contains(Mouse.GetState().X, Mouse.GetState().Y);

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

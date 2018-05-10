using Breakout.Models;
using Breakout.Models.UIComponents;
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
		private delegate void OnClickEventAction();

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

			Button startButton = Scene.StartButton;
			Button creditButton = Scene.CreditButton;
			Button exitButton = Scene.ExitButton;

			HandleButton(startButton, LoadGame);
			HandleButton(creditButton, OpenCredit);
			HandleButton(exitButton, ExitGame);

			Scene.Step(EntryPoint.Game.Elapsed);
		}

		private void HandleButton(Button button, OnClickEventAction action)
		{
			bool isMouseOverButton = button.Rectangle.Contains(InputHelper.GetMousePosition());

			if (isMouseOverButton)
			{
				if (InputHelper.IsMouseHold(MouseButtons.LeftButton))
					button.OnButtonHoldClicked();

				else if (InputHelper.IsMouseRelease(MouseButtons.LeftButton))
					action.Invoke();

				else
					button.OnButtonHovered();
			}
			else
			{
				button.OnButtonInactive();
			}
		}

		public override void Draw(MonoGameRenderer renderer)
		{
			renderer.DrawMenu(EntryPoint.Game.Elapsed);
		}
	}
}

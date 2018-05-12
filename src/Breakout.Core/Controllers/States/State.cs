using Breakout.Models.Enums;
using Breakout.Models.UIComponents;
using Breakout.Utilities;
using Breakout.Views.Renderers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Controllers.States
{
	public abstract class State
	{
		protected delegate void OnClickEventAction();

		public virtual void Update()
		{
			InputHelper.GetInput();
		}

		public virtual void Draw(MonoGameRenderer renderer)
		{

		}

		protected void HandleButton(Button button, OnClickEventAction action)
		{
			bool isMouseOverButton = button.Rectangle.Contains(InputHelper.GetMousePosition());

			if (isMouseOverButton)
			{
				if (InputHelper.IsMouseHold(MouseButtons.LeftButton))
					button.State = ButtonState.Clicked;

				else if (InputHelper.IsMouseRelease(MouseButtons.LeftButton))
					action.Invoke();

				else
					button.State = ButtonState.Hovered;
			}
			else
			{
				button.State = ButtonState.Inactive;
			}
		}
	}
}

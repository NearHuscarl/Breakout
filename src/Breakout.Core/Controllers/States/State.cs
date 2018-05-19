using Breakout.Core.Utilities;
using Breakout.Core.Views;
using Breakout.Core.Views.Renderers;
using Breakout.Core.Views.Screens;
using Breakout.Core.Views.Windows;

namespace Breakout.Core.Controllers.States
{
	public abstract class State
	{
		protected delegate void OnClickEventAction();

		public virtual void Update()
		{
			InputHelper.GetInput();
		}

		public virtual void AddScreen()
		{

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
				{
					button.OnButtonClicked();
				}
				else if (InputHelper.IsMouseRelease(MouseButtons.LeftButton))
				{
					action.Invoke();
				}
				else
				{
					button.OnButtonHovered();
				}
			}
			else
			{
				button.OnButtonInactive();
			}
		}

		protected void HandleCheckBox(CheckBox checkbox)
		{
			bool isMouseOverButton = checkbox.Rectangle.Contains(InputHelper.GetMousePosition());

			if (!isMouseOverButton)
			{
				return;
			}

			if (InputHelper.IsMouseRelease(MouseButtons.LeftButton))
			{
				checkbox.Toggle();
			}
		}

		protected void HandleRadioGroup(RadioGroup radioGroup)
		{
			foreach (var radioButton in radioGroup.RadioButtons)
			{
				if (IsRadioButtonClicked(radioButton))
				{
					radioGroup.Check(radioButton);
					break;
				}
			}
		}

		private bool IsRadioButtonClicked(RadioButton radio)
		{
			bool isMouseOverButton = radio.Rectangle.Contains(InputHelper.GetMousePosition());

			if (isMouseOverButton && InputHelper.IsMouseRelease(MouseButtons.LeftButton))
			{
				return true;
			}

			return false;
		}
	}
}

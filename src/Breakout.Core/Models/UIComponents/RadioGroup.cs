using Breakout.Utilities;
using System.Collections.Generic;

namespace Breakout.Models.UIComponents
{
	public class RadioGroup
	{
		public List<RadioButton> RadioButtons { get; set; }
		private RadioButton activeRadioButton;

		public void HandleInput()
		{
			foreach (var radio in RadioButtons)
			{
				if (!radio.Rectangle.Contains(InputHelper.GetMousePosition()))
					continue;

				if (InputHelper.IsMouseRelease(MouseButtons.LeftButton))
				{
					radio.OnRadioButtonChecked();
					activeRadioButton = radio;
					break;
				}
			}

			foreach(var radio in RadioButtons)
			{
				if (radio != activeRadioButton)
					radio.OnRadioButtonUnchecked();
			}
		}
	}
}

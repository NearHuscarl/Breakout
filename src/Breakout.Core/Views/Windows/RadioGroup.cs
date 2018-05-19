using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Breakout.Core.Views.Windows
{
	public class RadioGroup
	{
		public List<RadioButton> RadioButtons { get; set; }
		
		public RadioGroup(RadioButton[] radios)
		{
			RadioButtons = new List<RadioButton>(radios);
		}

		public void Check(RadioButton checkedRadioButton)
		{
			foreach (var radioButton in RadioButtons)
			{
				if (radioButton == checkedRadioButton)
				{
					radioButton.Check();
				}
				else
				{
					radioButton.Uncheck();
				}
			}
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			foreach (var radioButton in RadioButtons)
			{
				radioButton.Draw(spriteBatch);
			}
		}
	}
}

using Breakout.Utilities;
using System.Collections.Generic;

namespace Breakout.Models.UIComponents
{
	public class RadioGroup
	{
		public Dictionary<string, RadioButton> RadioButtons { get; set; }
		
		public RadioGroup(RadioButton[] radios)
		{
			RadioButtons = new Dictionary<string, RadioButton>();

			foreach (var radio in radios)
				RadioButtons.Add(radio.Text, radio);
		}

		public void Check(string name)
		{
			if (!RadioButtons.ContainsKey(name))
				return;

			foreach (var radio in RadioButtons)
			{
				if (radio.Key == name)
					radio.Value.Check();
				else
					radio.Value.UnCheck();
			}
		}
	}
}

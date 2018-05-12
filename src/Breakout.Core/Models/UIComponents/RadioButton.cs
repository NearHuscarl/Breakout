using Breakout.Models.Bases;
using Microsoft.Xna.Framework;
using System;

namespace Breakout.Models.UIComponents
{
	public class RadioButton : Control
	{
		public delegate void RadioButtonEventHandler(object source, EventArgs args);

		public event RadioButtonEventHandler RadioButtonChecked;
		public event RadioButtonEventHandler RadioButtonUnchecked;

		public string Text { get; set; }

		public RadioButton(int width, int height, Vector2 position, string text)
		{
			Width = width;
			Height = height;
			Position = position;
			Text = text;
		}

		public void OnRadioButtonChecked()
		{
			if (RadioButtonChecked != null)
				RadioButtonChecked(this, EventArgs.Empty);
		}

		public void OnRadioButtonUnchecked()
		{
			if (RadioButtonUnchecked != null)
				RadioButtonUnchecked(this, EventArgs.Empty);
		}
	}
}

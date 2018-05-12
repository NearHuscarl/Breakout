using Breakout.Models.Bases;
using Breakout.Utilities;
using Microsoft.Xna.Framework;
using System;

namespace Breakout.Models.UIComponents
{
	public class CheckBox : Control
	{
		public delegate void CheckBoxEventHandler(object source, EventArgs args);

		public event CheckBoxEventHandler CheckBoxChecked;
		public event CheckBoxEventHandler CheckBoxUnchecked;

		public string Text { get; set; }

		public CheckBox(int width, int height, Vector2 position, string text)
		{
			Width = width;
			Height = height;
			Position = position;
			Text = text;
		}

		public override void HandleInput()
		{
			if (!this.Rectangle.Contains(InputHelper.GetMousePosition()))
				return;

			if (InputHelper.IsMouseRelease(MouseButtons.LeftButton))
				this.OnCheckBoxChecked();
		}

		public void OnCheckBoxChecked()
		{
			if (CheckBoxChecked != null)
				CheckBoxChecked(this, EventArgs.Empty);
		}

		public void OnCheckBoxUnchecked()
		{
			if (CheckBoxUnchecked != null)
				CheckBoxUnchecked(this, EventArgs.Empty);
		}
	}
}

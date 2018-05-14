using Breakout.Models.Bases;
using Microsoft.Xna.Framework;

namespace Breakout.Models.UIComponents
{
	public class CheckBox : CheckBoxButton, IButton
	{

		public CheckBox(int width, int height, Vector2 position, string text, bool initialValue=false)
		{
			Width = width;
			Height = height;
			Position = position;
			Text = text;
			Checked = initialValue;
		}

		public void Toggle()
		{
			Checked = !Checked;
		}
	}
}

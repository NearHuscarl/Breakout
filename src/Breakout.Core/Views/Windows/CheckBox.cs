using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Breakout.Views.Windows
{
	public class CheckBox : CheckBoxButton
	{
		public CheckBox(Texture2D checkedImage, Texture2D uncheckedImage, SpriteFont font, Vector2 position, string text, bool initialValue)
			: base(checkedImage, uncheckedImage, font, position, text, initialValue)
		{

		}

		public void Toggle()
		{
			// AudioManager.PlaySound("ButtonChecked");
			IsChecked = !IsChecked;
		}
	}
}

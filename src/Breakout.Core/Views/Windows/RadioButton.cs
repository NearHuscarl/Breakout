using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Breakout.Views.Windows
{
	public class RadioButton : CheckBoxButton
	{
		public RadioButton(Texture2D checkedImage, Texture2D uncheckedImage, SpriteFont font, Vector2 position, string text, bool initialValue)
			: base(checkedImage, uncheckedImage, font, position, text, initialValue)
		{

		}

		public void Check()
		{
			// AudioManager.PlaySound("ButtonChecked");
			this.IsChecked = true;
		}

		public void Uncheck()
		{
			// AudioManager.PlaySound("ButtonChecked");
			this.IsChecked = false;
		}
	}
}
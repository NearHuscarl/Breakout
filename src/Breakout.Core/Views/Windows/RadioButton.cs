using Breakout.Core.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Breakout.Core.Views.Windows
{
	public class RadioButton : CheckBoxButton
	{
		public RadioButton(Texture2D checkedImage, Texture2D uncheckedImage, SpriteFont font, Vector2 position, string text, bool initialValue)
			: base(checkedImage, uncheckedImage, font, position, text, initialValue)
		{

		}

		public void Check()
		{
			if (this.IsChecked != true)
				AudioManager.PlaySound("RadioButtonToggle");

			this.IsChecked = true;
		}

		public void Uncheck()
		{
			if (this.IsChecked == true)
				AudioManager.PlaySound("RadioButtonToggle");

			this.IsChecked = false;
		}
	}
}
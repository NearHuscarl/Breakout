using Breakout.Core.Utilities.Audio;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Breakout.Core.Views.Windows
{
	public class RadioButton : CheckBoxButton
	{
		public RadioButton(Texture2D checkedImage, Texture2D uncheckedImage, SpriteFont font, string text, bool initialValue)
			: base(checkedImage, uncheckedImage, font, text, initialValue)
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
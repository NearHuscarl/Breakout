using Breakout.Core.Utilities.Audio;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Breakout.Core.Views.Windows
{
	public class CheckBox : CheckBoxButton
	{
		public CheckBox(Texture2D checkedImage, Texture2D uncheckedImage, SpriteFont font, string text, bool initialValue)
			: base(checkedImage, uncheckedImage, font, text, initialValue)
		{

		}

		public void Toggle()
		{
			AudioManager.PlaySound("CheckBoxToggle");
			IsChecked = !IsChecked;
		}
	}
}

using Breakout.Views.Windows;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Breakout.Views
{
	public static class WindowFactory
	{
		public static Button CreateButton(Vector2 position, string text)
		{
			Texture2D inactiveImage = TextureLoader.Load("ButtonInactive");
			Texture2D hoveredImage = TextureLoader.Load("ButtonHovered");
			Texture2D clickedImage = TextureLoader.Load("ButtonClicked");

			SpriteFont buttonFont = FontLoader.Load("MenuFont");

			return new Button(inactiveImage, hoveredImage, clickedImage, buttonFont, position, text);
		}

		public static CheckBox CreateCheckBox(Vector2 position, string text, bool initalValue)
		{
			Texture2D checkedImage = TextureLoader.Load("CheckBoxChecked");
			Texture2D uncheckedImage = TextureLoader.Load("CheckBoxUnchecked");

			SpriteFont checkboxFont = FontLoader.Load("MenuFont");

			return new CheckBox(checkedImage, uncheckedImage, checkboxFont, position, text, initalValue);
		}

		public static RadioButton CreateRadioButton(Vector2 position, string text, bool initalValue)
		{
			Texture2D checkedImage = TextureLoader.Load("RadioButtonChecked");
			Texture2D uncheckedImage = TextureLoader.Load("RadioButtonUnchecked");

			SpriteFont radioButtonFont = FontLoader.Load("MenuFont");

			return new RadioButton(checkedImage, uncheckedImage, radioButtonFont, position, text, initalValue);
		}

		public static Label CreateLabel(Vector2 position, string text)
		{
			SpriteFont labelFont = FontLoader.Load("MenuFont");

			return new Label(labelFont, position, text);
		}
	}
}

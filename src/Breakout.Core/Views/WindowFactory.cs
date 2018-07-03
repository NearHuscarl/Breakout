using Breakout.Core.Views.Loaders;
using Breakout.Core.Views.UIComponents;
using Breakout.Core.Views.Windows;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Breakout.Core.Views
{
	public static class WindowFactory
	{
		public static Button CreateButton(string text)
		{
			Texture2D inactiveImage = TextureLoader.Load("ButtonInactive");
			Texture2D hoveredImage = TextureLoader.Load("ButtonHovered");
			Texture2D clickedImage = TextureLoader.Load("ButtonClicked");

			SpriteFont buttonFont = FontLoader.Load("MenuFont");

			return new Button(inactiveImage, hoveredImage, clickedImage, buttonFont, text);
		}

		public static CheckBox CreateCheckBox(string text, bool initalValue)
		{
			Texture2D checkedImage = TextureLoader.Load("CheckBoxChecked");
			Texture2D uncheckedImage = TextureLoader.Load("CheckBoxUnchecked");

			SpriteFont checkboxFont = FontLoader.Load("MenuFont");

			return new CheckBox(checkedImage, uncheckedImage, checkboxFont, text, initalValue);
		}

		public static RadioButton CreateRadioButton(string text, bool initalValue)
		{
			Texture2D checkedImage = TextureLoader.Load("RadioButtonChecked");
			Texture2D uncheckedImage = TextureLoader.Load("RadioButtonUnchecked");

			SpriteFont radioButtonFont = FontLoader.Load("MenuFont");

			return new RadioButton(checkedImage, uncheckedImage, radioButtonFont, text, initalValue);
		}

		public static Textbox CreateTextbox(string placeholder="")
		{
			Texture2D textboxImage = TextureLoader.Load("Textbox");
			SpriteFont textboxFont = FontLoader.Load("MenuFont");

			return new Textbox(textboxImage, textboxFont, placeholder);
		}

		public static Label CreateLabel(string text)
		{
			SpriteFont labelFont = FontLoader.Load("MenuFont");

			return new Label(labelFont, text);
		}

		public static Star CreateStar()
		{
			Texture2D unstarTexture = TextureLoader.Load("Unstar");
			Texture2D starTexture = TextureLoader.Load("Star");

			return new Star(unstarTexture, starTexture);
		}
	}
}

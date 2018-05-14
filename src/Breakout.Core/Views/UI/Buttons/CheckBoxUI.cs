using Breakout.Models.UIComponents;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Breakout.Views.UI.Buttons
{
	public class CheckBoxUI : Sprite
	{
		private SpriteFont font;
		private Color fgColor;

		private Dictionary<bool, Texture2D> checkboxTextures;

		public CheckBoxUI(Texture2D checkedImage, Texture2D uncheckedImage, SpriteFont font, Color fgColor)
			: base(uncheckedImage)
		{
			this.font = font;
			this.fgColor = fgColor;

			checkboxTextures = new Dictionary<bool, Texture2D>()
			{
				{ false, uncheckedImage },
				{ true, checkedImage},
			};
		}

		public void Draw(SpriteBatch spriteBatch, CheckBoxButton model)
		{
			this.Texture = checkboxTextures[model.Checked];

			spriteBatch.Draw(this.Texture, model.Position, Color.White);
			spriteBatch.DrawString(font, model.Text, GetFontPosition(model), Color.White);
		}

		private Vector2 GetFontPosition(CheckBoxButton checkbox)
		{
			Vector2 textSize = font.MeasureString(checkbox.Text);

			return new Vector2()
			{
				X = checkbox.Position.X + checkbox.Width + font.LineSpacing * 1.5f,
				Y = checkbox.Position.Y + checkbox.Height / 2 - textSize.Y / 2,
			};
		}
	}
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Breakout.Views.Windows
{
	public class CheckBoxButton : Control
	{
		protected Dictionary<bool, Texture2D> checkboxTextures;

		public override int Width { get { return checkboxTextures[true].Width; } }
		public override int Height { get { return checkboxTextures[true].Height; } }

		public override Rectangle Rectangle
		{
			get
			{
				return new Rectangle((int)Position.X, (int)Position.Y, checkboxTextures[true].Width, checkboxTextures[true].Height);
			}
		}

		public bool IsChecked { get; protected set; }

		public CheckBoxButton(Texture2D checkedImage, Texture2D uncheckedImage, SpriteFont font, Vector2 position, string text, bool initialValue)
		{
			this.font = font;
			this.Position = position;
			this.Text = text;
			this.IsChecked = initialValue;

			checkboxTextures = new Dictionary<bool, Texture2D>()
			{
				{ false, uncheckedImage },
				{ true, checkedImage},
			};
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(checkboxTextures[IsChecked], Position, Color.White);
			spriteBatch.DrawString(font, Text, GetFontPosition(), ForegroundColor);
		}

		private Vector2 GetFontPosition()
		{
			Vector2 textSize = font.MeasureString(Text);

			return new Vector2()
			{
				X = Position.X + Width + font.LineSpacing * 1.5f,
				Y = Position.Y + Height / 2 - textSize.Y / 2,
			};
		}
	}
}

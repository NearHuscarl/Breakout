using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Breakout.Core.Views.Windows
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

		public CheckBoxButton(Texture2D checkedImage, Texture2D uncheckedImage, SpriteFont font, string text, bool initialValue)
		{
			this.Font = font;
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
			spriteBatch.DrawString(Font, Text, GetFontPosition(), ForegroundColor);
		}

		private Vector2 GetFontPosition()
		{
			Vector2 textSize = Font.MeasureString(Text);

			return new Vector2()
			{
				X = Position.X + Width + Font.LineSpacing * 1.5f,
				Y = Position.Y + Height / 2 - textSize.Y / 2,
			};
		}
	}
}

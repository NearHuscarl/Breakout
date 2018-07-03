using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

namespace Breakout.Core.Views.Windows
{
	public class Textbox : Control
	{
		private Texture2D textboxTexture;

		public override int Width { get { return textboxTexture.Width; } }
		public override int Height { get { return textboxTexture.Height; } }

		public Textbox(Texture2D textboxImage, SpriteFont textboxFont, string placeholder)
		{
			textboxTexture = textboxImage;
			Font = textboxFont;
			Text = placeholder;
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(textboxTexture, Position, Color.White);
			spriteBatch.DrawString(Font, Text, Position, Color.White);
		}
	}
}

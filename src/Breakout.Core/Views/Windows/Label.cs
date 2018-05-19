using Breakout.Core.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Breakout.Core.Views.Windows
{
	public class Label : Control
	{
		public Label(SpriteFont font, string text)
		{
			this.Font = font;
			this.Text = text;
		}

		public Label(SpriteFont font, string text, Vector2 position)
		{
			this.Font = font;
			this.Position = position;
			this.Text = text;

			ForegroundColor = GameInfo.Theme["White"];
		}

		public Label(SpriteFont font, string text, Color fgColor)
		{
			this.Font = font;
			this.Text = text;

			ForegroundColor = fgColor;
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.DrawString(Font, Text, Position, ForegroundColor);
		}
	}
}

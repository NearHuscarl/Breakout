using Breakout.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Breakout.Views.Windows
{
	public class Label : Control
	{
		public Label(SpriteFont font, string text)
		{
			this.font = font;
			this.Text = text;
		}

		public Label(SpriteFont font, Vector2 position, string text)
		{
			this.font = font;
			this.Position = position;
			this.Text = text;

			ForegroundColor = GameInfo.Theme["White"];
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.DrawString(font, Text, Position, ForegroundColor);
		}
	}
}

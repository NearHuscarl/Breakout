using Breakout.Core.Models;
using Breakout.Core.Models.Data;
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

			ForegroundColor = GlobalData.Theme["White"];
		}

		public Label(SpriteFont font, string text, Color fgColor)
		{
			this.Font = font;
			this.Text = text;

			ForegroundColor = fgColor;
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			var sentences = Text.Split('\n');
			var pivot = Position.X + Font.MeasureString(Text).X / 2;
			var position = Position;

			foreach (var sentence in sentences)
			{
				position.X = pivot - Font.MeasureString(sentence).X / 2;

				spriteBatch.DrawString(Font, sentence, position, ForegroundColor);

				position.Y += Font.LineSpacing;
			}
		}
	}
}

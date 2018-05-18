using Breakout.Models;
using Breakout.Models.Scores;
using Breakout.Views.Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Breakout.Views.UIComponents
{
	public class ScoreUI
	{
		private SpriteFont font;
		private Color color;

		public Vector2 Position;

		public ScoreUI(SpriteFont font, Color color)
		{
			this.font = font;
			this.color = color;
		}

		public void Draw(SpriteBatch spriteBatch, Score score, Alignment alignment, string offsetText = "")
		{
			Position.X = GetPositionFromOffset(alignment, score.FullText, offsetText);

			spriteBatch.DrawString(font, score.FullText, Position, color);
		}

		private float GetPositionFromOffset(Alignment alignment, string text, string offsetText)
		{
			float contentLength = font.MeasureString(text).X;
			float offsetLength = font.MeasureString(offsetText).X;

			if (alignment == Alignment.Left)
				return 5 + offsetLength;

			else if (alignment == Alignment.Right)
				return GameInfo.Screen.Width - contentLength - offsetLength;

			// (alignment == Alignment.Center)
			return GameInfo.Screen.Width / 2 - contentLength / 2;
		}
	}
}

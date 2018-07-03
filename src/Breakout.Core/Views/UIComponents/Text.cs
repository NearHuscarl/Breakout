using Breakout.Core.Models;
using Breakout.Core.Models.Data;
using Breakout.Core.Views.Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Breakout.Core.Views.UIComponents
{
	public class Text
	{
		private SpriteFont font;
		public Color color { get; set; }

		public Vector2 Position;

		public Text(SpriteFont font, Color color, Vector2 position)
		{
			this.font = font;
			this.color = color;
			this.Position = position;
		}

		public void Draw(SpriteBatch spriteBatch, string str, Alignment alignment, string offsetText = "")
		{
			Position.X = GetPositionFromOffset(alignment, str, offsetText);

			spriteBatch.DrawString(font, str, Position, color);
		}

		private float GetPositionFromOffset(Alignment alignment, string text, string offsetText)
		{
			float contentLength = font.MeasureString(text).X;
			float offsetLength = font.MeasureString(offsetText).X;

			if (alignment == Alignment.Left)
			{
				return 5 + offsetLength;
			}

			else if (alignment == Alignment.Right)
			{
				return GlobalData.Screen.Width - 5 - contentLength - offsetLength;
			}

			// (alignment == Alignment.Center)
			return GlobalData.Screen.Width / 2 - contentLength / 2;
		}
	}
}

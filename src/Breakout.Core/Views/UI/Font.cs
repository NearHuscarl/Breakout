using Breakout.Models.Meta;
using Breakout.Models.Texts;
using Breakout.Views.Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Views.UI
{
	public class Font
	{
		private SpriteFont font;
		private Color color;

		public Font(SpriteFont font, Color color)
		{
			this.font = font;
			this.color = color;
		}

		public void Draw(SpriteBatch spriteBatch, Text text, Alignment alignment, string offsetText="")
		{
			float contentLength = font.MeasureString(text.FullText).X;
			float offsetLength = font.MeasureString(offsetText).X;

			if (alignment == Alignment.Left)
				text.Position.X = 5 + offsetLength;

			else if (alignment == Alignment.Right)
				text.Position.X = GameInfo.Screen.Width - contentLength - offsetLength;

			else // (alignment == Alignment.Center)
				text.Position.X = GameInfo.Screen.Width / 2 - contentLength / 2;

			spriteBatch.DrawString(font, text.FullText, text.Position, color);
		}
	}
}

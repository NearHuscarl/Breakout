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
		private Vector2 position;
		private Color color;
		public string Text;

		public Font(SpriteFont font, string text, Vector2 position, Color color)
		{
			this.font = font;
			this.Text = text;
			this.position = position;
			this.color = color;
		}

		public void Draw(SpriteBatch spriteBatch, int content)
		{
			spriteBatch.DrawString(font, string.Format(Text, content.ToString()), position, color);
		}
	}
}

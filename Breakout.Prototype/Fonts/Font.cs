using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Fonts
{
	public class Font
	{
		public string content;

		public Vector2 position;

		private SpriteFont font;

		public Font(SpriteFont font)
		{
			this.font = font;
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.DrawString(font, content, position, Color.White);
		}
	}
}

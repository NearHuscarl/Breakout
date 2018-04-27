using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Views.UI
{
	public class Paddle
	{
		public Sprite Sprite;

		public Paddle(Sprite sprite)
		{
			Sprite = sprite;
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(Sprite.Texture, Sprite.Rectangle, Color.White);
		}
	}
}

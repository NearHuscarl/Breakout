using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Views.UI
{
	public class Ball
	{
		public Sprite Sprite;

		public Ball(Sprite sprite)
		{
			Sprite = sprite;
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(Sprite.Texture, Sprite.Rectangle, Color.White);
		}

		public bool IsOffBottom(int screenHeight)
		{
			if (Sprite.Position.Y + Sprite.Texture.Height > screenHeight)
			{
				return true;
			}
			return false;
		}
	}
}

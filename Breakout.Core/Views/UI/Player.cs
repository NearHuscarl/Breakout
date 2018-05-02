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
		private Sprite sprite;
		public float Position { get; set; } // x axis

		public Player(Sprite sprite, float position)
		{
			this.sprite = sprite;
			this.Position = position;
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(sprite.Texture, sprite.Rectangle, Color.White);
		}
	}
}

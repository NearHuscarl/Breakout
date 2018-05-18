using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Views.UIComponents
{
	public class Background
	{
		private Texture2D texture;

		public Background(Texture2D texture)
		{
			this.texture = texture;
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(texture, Vector2.Zero, Color.White);
		}
	}
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Views.UI
{
	public class Background : Sprite
	{
		public Background(Texture2D texture) : base(texture)
		{

		}

		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(this.Texture, Vector2.Zero, Color.White);
		}
	}
}

using Breakout.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Breakout.Views.UIComponents
{
	public class Cursor
	{
		private Texture2D texture;

		public Cursor(Texture2D texture)
		{
			this.texture = texture;
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(texture, InputHelper.GetMousePosition(), Color.White);
		}
	}
}

using Breakout.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Breakout.Views.UI
{
	public class Cursor : Sprite
	{
		public Cursor(Texture2D texture) : base(texture)
		{

		}

		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(this.Texture, InputHelper.GetMousePosition(), Color.White);
		}
	}
}

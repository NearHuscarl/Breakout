using Breakout.Models.Bases;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Breakout.Views.Sprites
{
	public class GameSprite
	{
		private Texture2D texture;

		public GameSprite(Texture2D texture)
		{
			this.texture = texture;
		}

		public virtual void Draw(SpriteBatch spriteBatch, GameObject model)
		{
			spriteBatch.Draw(texture, model.Position, Color.White);
		}

		public virtual void Draw(SpriteBatch spriteBatch, Rectangle rectangle)
		{
			spriteBatch.Draw(texture, rectangle, Color.White);
		}
	}
}

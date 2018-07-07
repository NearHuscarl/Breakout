using Breakout.Core.Models.Bases;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Breakout.Core.Views.Sprites
{
	public class GameSprite
	{
		private Texture2D texture;
		private Color color;

		public GameSprite(Texture2D texture)
		{
			this.texture = texture;
			this.color = Color.White;
		}

		public GameSprite(Texture2D texture, Color color)
		{
			this.texture = texture;
			this.color = color;
		}

		public virtual void Draw(SpriteBatch spriteBatch, GameObject model)
		{
			spriteBatch.Draw(texture, model.Position, color);
		}

		public virtual void Draw(SpriteBatch spriteBatch, Rectangle rectangle)
		{
			spriteBatch.Draw(texture, rectangle, color);
		}
	}
}

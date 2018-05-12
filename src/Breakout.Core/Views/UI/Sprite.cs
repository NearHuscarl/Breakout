using Breakout.Models.Bases;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Breakout.Views.UI
{
	public class Sprite
	{
		public Texture2D Texture { get; set; }

		public Sprite()
		{

		}

		public Sprite(Texture2D texture)
		{
			Texture = texture;
		}

		public virtual void Draw(SpriteBatch spriteBatch, GameObject model)
		{
			spriteBatch.Draw(this.Texture, model.Position, Color.White);
		}

		public virtual void Draw(SpriteBatch spriteBatch, Rectangle rectangle)
		{
			spriteBatch.Draw(this.Texture, rectangle, Color.White);
		}
	}
}

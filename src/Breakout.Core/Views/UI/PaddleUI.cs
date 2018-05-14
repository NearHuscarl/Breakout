using Breakout.Models.Enums;
using Breakout.Models.Paddles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Breakout.Views.UI
{
	public class PaddleUI : Sprite
	{
		private Dictionary<PaddleLength, Texture2D> texture;

		public PaddleUI(Texture2D extraShortTexture, Texture2D shortTexture, Texture2D mediumTexture, Texture2D longTexture)
		{

			texture = new Dictionary<PaddleLength, Texture2D>()
			{
				{ PaddleLength.ExtraShort, extraShortTexture },
				{ PaddleLength.Short, shortTexture },
				{ PaddleLength.Medium, mediumTexture },
				{ PaddleLength.Long, longTexture },
			};
		}

		public virtual void Draw(SpriteBatch spriteBatch, Paddle paddle)
		{
			this.Texture = texture[paddle.Length];

			spriteBatch.Draw(this.Texture, paddle.Position, Color.White);
		}
	}
}

using Breakout.Models.Enums;
using Breakout.Models.Paddles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Breakout.Views.Sprites
{
	public class PaddleUI
	{
		private Dictionary<PaddleLength, Texture2D> texture;

		public PaddleUI(Texture2D extraShortTexture, Texture2D shortTexture, Texture2D mediumTexture, Texture2D longTexture, Texture2D extraLongTexture)
		{

			texture = new Dictionary<PaddleLength, Texture2D>()
			{
				{ PaddleLength.ExtraShort, extraShortTexture },
				{ PaddleLength.Short, shortTexture },
				{ PaddleLength.Medium, mediumTexture },
				{ PaddleLength.Long, longTexture },
				{ PaddleLength.ExtraLong, extraLongTexture },
			};
		}

		public virtual void Draw(SpriteBatch spriteBatch, Paddle paddle)
		{
			spriteBatch.Draw(texture[paddle.Length], paddle.Position, Color.White);
		}
	}
}

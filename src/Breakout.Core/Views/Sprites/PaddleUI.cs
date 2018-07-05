using Breakout.Core.Models.Enums;
using Breakout.Core.Models.Paddles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Breakout.Core.Views.Sprites
{
	public class PaddleUI
	{
		private Dictionary<PaddleLength, Texture2D> normalTextures;
		private Dictionary<PaddleLength, Texture2D> magnetTextures;

		public PaddleUI(Dictionary<PaddleLength, Texture2D> normalTextures, Dictionary<PaddleLength, Texture2D> magnetTextures)
		{
			this.normalTextures = normalTextures;
			this.magnetTextures = magnetTextures;
		}

		public virtual void Draw(SpriteBatch spriteBatch, Paddle paddle)
		{
			if (paddle.GetType() == typeof(MagnetizedPaddle))
				spriteBatch.Draw(magnetTextures[paddle.Length], paddle.Position, Color.White);
			else
				spriteBatch.Draw(normalTextures[paddle.Length], paddle.Position, Color.White);
		}
	}
}

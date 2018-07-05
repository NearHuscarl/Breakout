using Breakout.Core.Models;
using Breakout.Core.Models.Balls;
using Breakout.Core.Models.Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Breakout.Core.Views.Sprites
{
	public class BallUI
	{
		private Dictionary<BallSize, Texture2D> textures;

		public BallUI(Dictionary<BallSize, Texture2D> textures)
		{
			this.textures = textures;
		}

		public virtual void Draw(SpriteBatch spriteBatch, Ball ball)
		{
			Color ballColor = Color.White;

			switch (ball.Strength)
			{
				case BallStrength.Weak:
					ballColor = GlobalData.Theme["Blue"];
					break;

				case BallStrength.Normal:
					ballColor = GlobalData.Theme["Yellow"];
					break;

				case BallStrength.Strong:
					ballColor = GlobalData.Theme["Red"];
					break;
			}

			spriteBatch.Draw(textures[ball.Size], ball.Position, ballColor);
		}
	}
}

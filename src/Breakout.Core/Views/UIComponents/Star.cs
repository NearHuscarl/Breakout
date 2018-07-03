using Breakout.Core.Utilities.Audio;
using Breakout.Core.Views.Windows;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Breakout.Core.Views.UIComponents
{
	public class Star : Control
	{
		private Dictionary<bool, Texture2D> textures;

		public override int Width { get { return textures[false].Width; } }
		public override int Height { get { return textures[false].Height; } }

		public bool IsShine { get; private set; }

		public Star(Texture2D unStarTexture, Texture2D starTexture)
		{
			textures = new Dictionary<bool, Texture2D>()
			{
				{ false, unStarTexture },
				{ true, starTexture },
			};
		}

		public void Shine()
		{
			AudioManager.PlaySound("GetStar");
			IsShine = true;
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(textures[IsShine], Position, Color.White);
		}
	}
}

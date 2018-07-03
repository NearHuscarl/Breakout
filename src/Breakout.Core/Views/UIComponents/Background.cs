using Breakout.Core.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Breakout.Core.Views.UIComponents
{
	public class Background
	{
		private Scene scene;
		private Dictionary<string, Texture2D> textures;

		public Background(Scene scene, Dictionary<string, Texture2D> textures)
		{
			this.scene = scene;
			this.textures = textures;
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(textures[scene.MapName], Vector2.Zero, Color.White);
		}
	}
}

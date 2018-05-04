using Breakout.Models.Blocks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Views.UI
{
	public class BlockUI : Sprite
	{
		private Texture2D[] textures;

		public BlockUI(params Texture2D[] textures)
		{
			this.textures = textures;
			this.Texture = textures[textures.Length - 1];
		}

		public void Draw(SpriteBatch spriteBatch, Block block)
		{
			if (block.Health > 40)
				this.Texture = textures[4];
			else if (block.Health > 30)
				this.Texture = textures[3];
			else if (block.Health > 20)
				this.Texture = textures[2];
			else if (block.Health > 10)
				this.Texture = textures[1];
			else // <= 10
				this.Texture = textures[0];

			spriteBatch.Draw(this.Texture, block.Position, Color.White);
		}
	}
}

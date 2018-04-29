using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Sprites
{
	enum BlockColor
	{
		Cyan,
		Green,
		Blue,
		Magenta,
		Yellow,
		Orange,
		Red,
	}

	public class Blocks
	{
		private List<Block> blocks;
		private List<Texture2D> blockTextures;

		public Blocks(List<Texture2D> blockTextures)
		{
			this.blockTextures = blockTextures;
			blocks = new List<Block>();
		}

		public void ResetPosition()
		{
			blocks.Clear();

			var blockWidth = blockTextures[0].Width;
			var blockHeight = blockTextures[0].Height;

			for (int w = 0; w * blockWidth < Game1.screenWidth; w++)
			{
				for (int h = 0; h * blockHeight < Game1.screenHeight / 2; h++)
				{
					var texture = blockTextures[Game1.random.Next(0, 7)];
					Block newBlock = new Block(texture, new Vector2(texture.Width * w, texture.Height * h));

					blocks.Add(newBlock);
				}
			}
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			foreach (var block in blocks)
			{
				block.Draw(spriteBatch);
			}
		}

		public IEnumerable<Block> Get()
		{
			for (int i = 0; i <= blocks.Count - 1; i++)
				yield return blocks[i];
		}

		public void BrickHit(Block block)
		{
			blocks.Remove(block);
		}
	}
}

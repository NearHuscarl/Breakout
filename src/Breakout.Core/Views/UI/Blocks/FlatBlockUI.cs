using Breakout.Models.Blocks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Views.UI.Blocks
{
	public class FlatBlockUI : Sprite
	{
		private Color fullColor;
		private Color emptyColor;

		public FlatBlockUI(Texture2D texture, Color fullColor, Color emptyColor) : base(texture)
		{
			this.fullColor = fullColor;
			this.emptyColor = emptyColor;
		}

		public void Draw(SpriteBatch spriteBatch, Block block)
		{
			DrawBlockBasedOnHealth(spriteBatch, block);
		}

		private void DrawBlockBasedOnHealth(SpriteBatch spriteBatch, Block block)
		{
			Color color = GetColorBasedOnHealth(block);

			spriteBatch.Draw(this.Texture, block.Position, color);
		}

		private Color GetColorBasedOnHealth(Block block)
		{
			float colorAmount = block.Health * 1f / block.MaxHealth;

			return Color.Lerp(emptyColor, fullColor, colorAmount);
		}
	}
}

using Breakout.Models.Blocks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Breakout.Views.Sprites.Blocks
{
	public class BlockUI
	{
		private FlatBlockUI flatBlockUI;
		private FlashingBlockUI flashingBlockUI;

		public BlockUI(Texture2D texture, Color startColor, Color endColor)
		{
			flatBlockUI = new FlatBlockUI(texture, startColor, endColor);
			flashingBlockUI = new FlashingBlockUI(texture, startColor, endColor);
		}

		public void UpdateColor(float elapsed)
		{
			flashingBlockUI.UpdateFlashingColorAmount(elapsed);
		}

		public void Draw(SpriteBatch spriteBatch, Block model)
		{
			if (model.GetType() == typeof(FlashingBlock))
				flashingBlockUI.Draw(spriteBatch, model);

			else
				flatBlockUI.Draw(spriteBatch, model);
		}
	}
}

using Breakout.Core.Models.Blocks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Breakout.Core.Views.Sprites.Blocks
{
	public class BlockUI
	{
		private NormalBlockUI normalBlockUI;
		private GameSprite lightBlockUI;
		private FlashingBlockUI flashingBlockUI;

		public BlockUI(Texture2D texture, Color startColor, Color endColor)
		{
			normalBlockUI = new NormalBlockUI(texture, startColor, endColor);
			lightBlockUI = new GameSprite(texture, endColor);
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
			else if (model.GetType() == typeof(LightBlock))
				lightBlockUI.Draw(spriteBatch, model);
			else
				normalBlockUI.Draw(spriteBatch, model);
		}
	}
}

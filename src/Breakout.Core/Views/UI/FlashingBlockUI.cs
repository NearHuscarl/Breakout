using Breakout.Models.Bases;
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
	public class FlashingBlockUI : Sprite
	{
		private Color startColor;
		private Color endColor;

		private float colorAmount = 0;
		private bool start2end = true;

		public FlashingBlockUI(Texture2D texture, Color startColor, Color endColor)
		{
			this.Texture = texture;
			this.startColor = startColor;
			this.endColor = endColor;
		}

		public void Draw(SpriteBatch spriteBatch, Block model, float deltaTime)
		{
			spriteBatch.Draw(this.Texture, model.Position, TransformColor(deltaTime));
		}

		/// <summary>
		/// Transform color gradually from startColor to endColor and go backward
		/// </summary>
		private Color TransformColor(float deltaTime)
		{
			if (start2end)
				colorAmount += deltaTime;
			else
				colorAmount -= deltaTime;

			if (colorAmount > 1f)
				start2end = false;

			if (colorAmount < 0)
				start2end = true;

			return Color.Lerp(startColor, endColor, colorAmount);
		}
	}
}

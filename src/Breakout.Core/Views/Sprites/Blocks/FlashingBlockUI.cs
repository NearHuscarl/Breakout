using Breakout.Core.Models.Bases;
using Breakout.Core.Models.Blocks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Core.Views.Sprites.Blocks
{
	public class FlashingBlockUI
	{
		private Texture2D texture;

		private Color startColor;
		private Color endColor;

		private float colorAmount = 0;
		private float flashingSpeed = 3;
		private bool start2end = true;

		public FlashingBlockUI(Texture2D texture, Color startColor, Color endColor)
		{
			this.texture = texture;
			this.startColor = startColor;
			this.endColor = endColor;
		}

		public void Draw(SpriteBatch spriteBatch, Block model)
		{
			spriteBatch.Draw(texture, model.Position, TransformColor());
		}

		private Color TransformColor()
		{
			return Color.Lerp(startColor, endColor, colorAmount);
		}

		/// <summary>
		/// Transform color gradually from startColor to endColor and go backward
		/// </summary>
		public void UpdateFlashingColorAmount(float deltaTime)
		{
			if (start2end)
				colorAmount += deltaTime * flashingSpeed;
			else
				colorAmount -= deltaTime * flashingSpeed;

			if (colorAmount > 1f)
				start2end = false;

			if (colorAmount < 0)
				start2end = true;
		}
	}
}

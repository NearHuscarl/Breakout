using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Views.UI
{
	public class Button
	{
		public Sprite Sprite { get; set; }
		private Texture2D hoverImage;
		private Texture2D clickedImage;
		private Texture2D inactiveImage;

		public Button(Sprite sprite, Texture2D hoverImage, Texture2D clickedImage, Texture2D inactiveImage)
		{
			this.Sprite = sprite;
			this.hoverImage = hoverImage;
			this.clickedImage = clickedImage;
			this.inactiveImage = inactiveImage;
		}

		public void ChangeToHoverImage()
		{
			Sprite.Texture = hoverImage;
		}

		public void ChangeToClickedImage()
		{
			Sprite.Texture = clickedImage;
		}

		public void ChangeToInactiveImage()
		{
			Sprite.Texture = inactiveImage;
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(Sprite.Texture, Sprite.Rectangle, Color.White);
		}
	}
}

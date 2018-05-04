using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Views.UI
{
	public class ButtonUI : Sprite
	{
		private Texture2D hoverImage;
		private Texture2D clickedImage;
		private Texture2D inactiveImage;

		public ButtonUI(Texture2D inactiveImage, Texture2D hoverImage, Texture2D clickedImage) : base(inactiveImage)
		{
			this.hoverImage = hoverImage;
			this.clickedImage = clickedImage;
			this.inactiveImage = inactiveImage;
		}

		public void ChangeToHoverImage()
		{
			this.Texture = hoverImage;
		}

		public void ChangeToClickedImage()
		{
			this.Texture = clickedImage;
		}

		public void ChangeToInactiveImage()
		{
			this.Texture = inactiveImage;
		}
	}
}

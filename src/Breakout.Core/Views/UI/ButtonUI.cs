using Breakout.Models.UIComponents;
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
		private SpriteFont font;
		private Color fgColor;

		private Texture2D hoverImage;
		private Texture2D clickedImage;
		private Texture2D inactiveImage;

		public ButtonUI(SpriteFont font, Texture2D inactiveImage, Texture2D hoverImage, Texture2D clickedImage, Color fgColor)
			: base(inactiveImage)
		{
			this.font = font;
			this.fgColor = fgColor;

			this.hoverImage = hoverImage;
			this.clickedImage = clickedImage;
			this.inactiveImage = inactiveImage;
		}

		public void Draw(SpriteBatch spriteBatch, Button model)
		{
			spriteBatch.Draw(this.Texture, model.Position, Color.White);
			spriteBatch.DrawString(font, model.Text, GetFontPosition(model), Color.White);
		}

		private Vector2 GetFontPosition(Button button)
		{
			Vector2 textSize = font.MeasureString(button.Text);

			return new Vector2()
			{
				X = button.Position.X + button.Width / 2 - textSize.X / 2,
				Y = button.Position.Y + button.Height / 2 - textSize.Y / 2,
			};
		}

		public void OnButtonHovered(object source, EventArgs e)
		{
			ChangeToHoverImage();
		}

		public void OnButtonHoldClicked(object source, EventArgs e)
		{
			ChangeToClickedImage();
		}

		public void OnButtonInactive(object source, EventArgs e)
		{
			ChangeToInactiveImage();
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

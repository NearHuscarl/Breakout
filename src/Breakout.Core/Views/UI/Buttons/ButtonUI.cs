using Breakout.Models.Enums;
using Breakout.Models.UIComponents;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Views.UI.Buttons
{
	public class ButtonUI : Sprite
	{
		private SpriteFont font;
		private Color fgColor;

		private Dictionary<ButtonState, Texture2D> buttonTextures;

		public ButtonUI(Texture2D inactiveImage, Texture2D hoverImage, Texture2D clickedImage, SpriteFont font, Color fgColor)
			: base(inactiveImage)
		{
			this.font = font;
			this.fgColor = fgColor;

			buttonTextures = new Dictionary<ButtonState, Texture2D>()
			{
				{ ButtonState.Hovered, hoverImage },
				{ ButtonState.Clicked, clickedImage },
				{ ButtonState.Inactive, inactiveImage },
			};
		}

		public void Draw(SpriteBatch spriteBatch, Button model)
		{
			this.Texture = buttonTextures[model.State];

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
	}
}

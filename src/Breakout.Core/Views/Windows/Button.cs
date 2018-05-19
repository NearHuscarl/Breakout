using Breakout.Core.Models.Enums;
using Breakout.Core.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Breakout.Core.Views.Windows
{
	public class Button : Control
	{
		private Dictionary<ButtonState, Texture2D> buttonTextures;

		public override int Width { get { return buttonTextures[ButtonState.Inactive].Width;  } }
		public override int Height { get { return buttonTextures[ButtonState.Inactive].Height; } }

		public override Rectangle Rectangle
		{
			get
			{
				return new Rectangle((int)Position.X, (int)Position.Y, buttonTextures[ButtonState.Inactive].Width, buttonTextures[ButtonState.Inactive].Height);
			}
		}

		public ButtonState State { get; private set; }

		public Button(Texture2D inactiveImage, Texture2D hoverImage, Texture2D clickedImage, SpriteFont font, Vector2 position, string text)
		{
			this.Font = font;
			this.Position = position;
			this.Text = text;

			buttonTextures = new Dictionary<ButtonState, Texture2D>()
			{
				{ ButtonState.Hovered, hoverImage },
				{ ButtonState.Clicked, clickedImage },
				{ ButtonState.Inactive, inactiveImage },
			};
		}

		public void OnButtonHovered()
		{
			if (State == ButtonState.Hovered)
				return;

			State = ButtonState.Hovered;
			AudioManager.PlaySound("ButtonHovered");
		}

		public void OnButtonClicked()
		{
			if (State == ButtonState.Clicked)
				return;

			State = ButtonState.Clicked;
			AudioManager.PlaySound("ButtonClicked");
		}

		public void OnButtonInactive()
		{
			if (State == ButtonState.Inactive)
				return;

			State = ButtonState.Inactive;
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(buttonTextures[State], Position, Color.White);
			spriteBatch.DrawString(Font, Text, GetFontPosition(), ForegroundColor);
		}

		private Vector2 GetFontPosition()
		{
			Vector2 textSize = Font.MeasureString(Text);

			return new Vector2()
			{
				X = Position.X + Width / 2 - textSize.X / 2,
				Y = Position.Y + Height / 2 - textSize.Y / 2,
			};
		}
	}
}

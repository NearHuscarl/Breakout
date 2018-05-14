using Breakout.Models.Bases;
using Breakout.Models.Enums;
using Breakout.Utilities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Models.UIComponents
{
	public class Button : RectangleObject, IButton
	{
		private ButtonState state;

		public ButtonState State
		{
			get { return state; }

			set
			{
				if (state == value)
					return;

				switch (state)
				{
					case ButtonState.Hovered:
						State = ButtonState.Hovered;
						AudioManager.PlaySound("ButtonHovered");
						break;

					case ButtonState.Clicked:
						State = ButtonState.Clicked;
						AudioManager.PlaySound("ButtonClicked");
						break;

					case ButtonState.Inactive:
						State = ButtonState.Inactive;
						break;
				}
			}
		}

		public string Text { get; private set; }

		public Button(int width, int height, float xRatio, float yRatio, string text)
		{
			Width = width;
			Height = height;

			Position = new Vector2()
			{
				X = GameInfo.Screen.Width * xRatio - Width * xRatio,
				Y = GameInfo.Screen.Height * yRatio - Height * yRatio,
			};

			Text = text;
		}

		public Button(int width, int height, Vector2 position, string text)
		{
			Width = width;
			Height = height;

			Position = position;
			Text = text;
		}
	}
}

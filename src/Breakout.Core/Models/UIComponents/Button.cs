using Breakout.Models.Bases;
using Breakout.Models.Enums;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Models.UIComponents
{
	public class Button : RectangleObject
	{
		public ButtonState State { get; set; }
		public string Text { get; set; }

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

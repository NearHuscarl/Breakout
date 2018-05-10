using Breakout.Models.Bases;
using Breakout.Models.Enums;
using Breakout.Models.Meta;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Models.UIComponents
{
	public class Button : GameObject
	{
		public delegate void ButtonEventHandler(object source, EventArgs args);

		public event ButtonEventHandler ButtonHovered;
		public event ButtonEventHandler ButtonHoldClicked;
		public event ButtonEventHandler ButtonInactive;

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

		public void OnButtonHovered()
		{
			if (ButtonHovered != null)
				ButtonHovered(this, EventArgs.Empty);
		}

		public void OnButtonHoldClicked()
		{
			if (ButtonHovered != null)
				ButtonHoldClicked(this, EventArgs.Empty);
		}

		public void OnButtonInactive()
		{
			if (ButtonHovered != null)
				ButtonInactive(this, EventArgs.Empty);
		}

		public void HandleButton()
		{

		}
	}
}

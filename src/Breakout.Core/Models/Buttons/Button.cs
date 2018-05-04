using Breakout.Models.Bases;
using Breakout.Models.Meta;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Models.Buttons
{
	public class Button : GameObject
	{
		public Button(float xRatio, float yRatio)
		{
			Width = 150;
			Height = 40;
			Position = new Vector2()
			{
				X = GameInfo.Screen.Width * xRatio - Width * xRatio,
				Y = GameInfo.Screen.Height * yRatio - Height * yRatio,
			};
		}
	}
}

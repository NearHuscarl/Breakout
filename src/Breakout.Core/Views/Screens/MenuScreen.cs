using Breakout.Core.Models;
using Breakout.Core.Views.Windows;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Breakout.Core.Views.Screens
{
	public class MenuScreen : Screen
	{
		public Dictionary<string, Button> Buttons;

		public MenuScreen()
		{
			Buttons = new Dictionary<string, Button>()
			{
				{ "Start", WindowFactory.CreateButton(new Vector2(), "Start Game") },
				{ "Setting", WindowFactory.CreateButton(new Vector2(), "Setting") },
				{ "About", WindowFactory.CreateButton(new Vector2(), "About") },
				{ "Exit", WindowFactory.CreateButton(new Vector2(), "Exit Game") },
			};

			Button butt = Buttons["Start"];

			Buttons["Start"].Position   = new Vector2(GameInfo.Screen.Width / 2 - butt.Width / 2, 300f);
			Buttons["Setting"].Position = new Vector2(GameInfo.Screen.Width / 2 - butt.Width / 2, 350f);
			Buttons["About"].Position   = new Vector2(GameInfo.Screen.Width / 2 - butt.Width / 2, 400f);
			Buttons["Exit"].Position    = new Vector2(GameInfo.Screen.Width / 2 - butt.Width / 2, 450f);
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			foreach (var button in Buttons.Values)
			{
				button.Draw(spriteBatch);
			}
		}
	}
}

using Breakout.Core.Models;
using Breakout.Core.Models.Data;
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
				{ "New", WindowFactory.CreateButton("New Game") },
				{ "Load", WindowFactory.CreateButton("Load Game") },
				{ "Setting", WindowFactory.CreateButton("Setting") },
				{ "About", WindowFactory.CreateButton("About") },
				{ "Exit", WindowFactory.CreateButton("Exit Game") },
			};

			Button butt = Buttons["New"];

			Buttons["New"].Position     = new Vector2(GlobalData.Screen.Width / 2 - butt.Width / 2, 250f);
			Buttons["Load"].Position    = new Vector2(GlobalData.Screen.Width / 2 - butt.Width / 2, 300f);
			Buttons["Setting"].Position = new Vector2(GlobalData.Screen.Width / 2 - butt.Width / 2, 350f);
			Buttons["About"].Position   = new Vector2(GlobalData.Screen.Width / 2 - butt.Width / 2, 400f);
			Buttons["Exit"].Position    = new Vector2(GlobalData.Screen.Width / 2 - butt.Width / 2, 450f);
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

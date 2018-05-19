using Breakout.Core.Controllers.Levels;
using Breakout.Core.Models;
using Breakout.Core.Views.Loaders;
using Breakout.Core.Views.Sprites;
using Breakout.Core.Views.UIComponents;
using Breakout.Core.Views.Windows;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Text;

namespace Breakout.Core.Views.Screens
{
	public class WinningScreen : BigScreen
	{
		public Label LevelText { get; set; }
		public Label WinningText { get; set; }
		public Button NextButton { get; set; }

		public Star Star1 { get; set; }
		public Star Star2 { get; set; }
		public Star Star3 { get; set; }

		public WinningScreen()
		{
			Title.Text = "Victory";

			NextButton = WindowFactory.CreateButton(new Vector2(), "Next");

			NextButton.Position = new Vector2()
			{
				X = GetControlXPosition(NextButton, 1, 1),
				Y = Position.Y + Height * 0.75f,
			};

			LevelText = new Label(defaultFont, "Level " + LevelPicker.CurrentLevelNumber.ToString());
			WinningText = new Label(FontLoader.Load("HeadlineFont"), "You Won!", GameInfo.Theme["Blue"]);

			Star1 = WindowFactory.CreateStar(new Vector2());
			Star2 = WindowFactory.CreateStar(new Vector2());
			Star3 = WindowFactory.CreateStar(new Vector2());

			Star2.Position = new Vector2()
			{
				X = Position.X + Width / 2 - Star1.Width / 2,
				Y = Position.Y + Height * 0.4f,
			};

			Star1.Position = new Vector2()
			{
				X = Position.X + Width / 2 - Star1.Width / 2 - Star1.Width * 1.25f,
				Y = Star2.Position.Y + 20,
			};


			Star3.Position = new Vector2()
			{
				X = Position.X + Width / 2 - Star1.Width / 2 + Star1.Width * 1.25f,
				Y = Star2.Position.Y + 20,
			};
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			base.Draw(spriteBatch);

			SetTextPosition(LevelText, 30);
			SetTextPosition(WinningText, 65);

			LevelText.Draw(spriteBatch);
			WinningText.Draw(spriteBatch);
			NextButton.Draw(spriteBatch);

			Star1.Draw(spriteBatch);
			Star2.Draw(spriteBatch);
			Star3.Draw(spriteBatch);
		}
	}
}

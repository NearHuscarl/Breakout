using Breakout.Core.Models;
using Breakout.Core.Views.Enums;
using Breakout.Core.Views.Loaders;
using Breakout.Core.Views.Windows;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Breakout.Core.Views.Screens
{
	public class WinAllScreen : BigScreen
	{
		public Label WinAllText { get; set; }
		public Textbox TextBox { get; set; }
		public Label HighScoreText { get; set; }
		public Button SaveButton { get; set; }

		public WinAllScreen()
		{
			Title.Text = "Congratulation!";

			WinAllText = new Label(FontLoader.Load("HeaderFont"), "You have passed all levels!", GlobalData.Theme["Silver"]);
			HighScoreText = new Label(FontLoader.Load("HeaderFont"), "High Score: " + GlobalData.Session.CurrentScore.ToString("N0"), GlobalData.Theme["Yellow"]);

			TextBox = WindowFactory.CreateTextbox();
			SaveButton = WindowFactory.CreateButton("Back to menu");

			TextBox.Position = new Vector2()
			{
				X = GetControlXPosition(TextBox, 1, 1),
				Y = this.Position.Y + 210f,
			};

			SaveButton.Position = new Vector2()
			{
				X = GetControlXPosition(SaveButton, 1, 1),
				Y = this.Position.Y + 300f,
			};
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			base.Draw(spriteBatch);

			AlignText(WinAllText, Alignment.Center, 75);
			AlignText(HighScoreText, Alignment.Center, 140);

			//AlignText(WinAllText, Alignment.Center, 25);
			//AlignText(HighScoreText, Alignment.Center, 90);

			WinAllText.Draw(spriteBatch);
			HighScoreText.Draw(spriteBatch);

			// TODO: deadline :(
			//TextBox.Draw(spriteBatch);
			SaveButton.Draw(spriteBatch);
		}
	}
}

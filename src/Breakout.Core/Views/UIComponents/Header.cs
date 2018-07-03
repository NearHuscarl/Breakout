using Breakout.Core.Models;
using Breakout.Core.Utilities.Map;
using Breakout.Core.Views.Enums;
using Breakout.Core.Views.Loaders;
using Breakout.Core.Views.Windows;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Breakout.Core.Views.UIComponents
{
	/// <summary>
	/// header is the top area of the game screen containing
	/// info about score, current level and current combo
	/// </summary>
	public class Header : Statusline
	{
		private Dictionary<string, Texture2D> textures;

		public SpriteFont TitleFont { get; set; } = FontLoader.Load("TitleFont");
		public SpriteFont BoldTitleFont { get; set; } = FontLoader.Load("BoldTitleFont");
		public SpriteFont HeaderFont { get; set; } = FontLoader.Load("HeaderFont");

		private int margin = 15;

		public Label LevelText { get; set; }
		public Label ScoreText { get; set; }
		public Label ComboText { get; set; }
		public Label MaxComboText { get; set; }

		public Header(Scene scene, Dictionary<string, Texture2D> textures) : base(scene, textures["Background"])
		{
			Position = Vector2.Zero;

			this.textures = textures;

			LevelText = new Label(TitleFont, "", GlobalData.Theme["Silver"]);
			ScoreText = new Label(HeaderFont, "", GlobalData.Theme["Yellow"]);
			ComboText = new Label(TitleFont, "", GlobalData.Theme["Silver"]);
			MaxComboText = new Label(BoldTitleFont, "", GlobalData.Theme["LightYellow"]);
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			LevelText.Text = "Lvl " + GlobalData.Session.CurrentLevel;
			ScoreText.Text = scene.Player.Score.Score.ToString();
			ComboText.Text = "x" + scene.Player.CurrentCombo.ToString();
			MaxComboText.Text = "x" + scene.Player.HighestCombo.ToString();

			int levelLength = (int)TitleFont.MeasureString(LevelText.Text).X + margin;
			int comboLength = (int)TitleFont.MeasureString(ComboText.Text).X + margin;
			int maxComboLength = (int)TitleFont.MeasureString(MaxComboText.Text).X + margin;
			int maxComboVerticalPos = TitleFont.LineSpacing + margin;

			Rectangle leftSourceRectangle = new Rectangle(0, 0, background.Width, background.Height);
			Rectangle leftDestinationRectangle = new Rectangle(0, 0, levelLength, background.Height);

			Rectangle rightSourceRectangle = new Rectangle(
				GlobalData.Screen.Width - comboLength, 0,
				background.Width, background.Height);

			Rectangle rightDestinationRectangle = new Rectangle(
				GlobalData.Screen.Width - comboLength, 0,
				comboLength, background.Height);

			Rectangle rightBottomSourceRectangle = new Rectangle(
				GlobalData.Screen.Width - maxComboLength, maxComboVerticalPos,
				background.Width, background.Height);

			Rectangle rightBottomDestinationRectangle = new Rectangle(
				GlobalData.Screen.Width - maxComboLength, maxComboVerticalPos,
				maxComboLength, background.Height);

			spriteBatch.Draw(background, leftDestinationRectangle, leftSourceRectangle, Color.White);
			spriteBatch.Draw(textures["LeftEdge"], new Vector2(levelLength, 0), Color.White);

			spriteBatch.Draw(background, rightDestinationRectangle, rightSourceRectangle, Color.White);
			spriteBatch.Draw(textures["RightEdge"], new Vector2(GlobalData.Screen.Width - comboLength - textures["RightEdge"].Width, 0), Color.White);

			spriteBatch.Draw(textures["GoldenBackground"], rightBottomDestinationRectangle, rightBottomSourceRectangle, Color.White);
			spriteBatch.Draw(textures["GoldenRightEdge"], new Vector2(GlobalData.Screen.Width - comboLength - textures["GoldenRightEdge"].Width, maxComboVerticalPos), Color.White);

			AlignText(LevelText, Alignment.Left);
			AlignText(ScoreText, Alignment.Center);
			AlignText(ComboText, Alignment.Right);
			AlignText(MaxComboText, Alignment.Right, verticalOffset: maxComboVerticalPos);

			LevelText.Draw(spriteBatch);
			ScoreText.Draw(spriteBatch);
			ComboText.Draw(spriteBatch);
			MaxComboText.Draw(spriteBatch);
		}
	}
}

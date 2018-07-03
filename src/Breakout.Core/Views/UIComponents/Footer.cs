using Breakout.Core.Models;
using Breakout.Core.Models.Data;
using Breakout.Core.Views.Enums;
using Breakout.Core.Views.Loaders;
using Breakout.Core.Views.Windows;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Breakout.Core.Views.UIComponents
{
	/// <summary>
	/// Footer is the bottom area of the game screen containing
	/// info about elapsed game time, live and block left
	/// </summary>
	public class Footer : Statusline
	{
		public SpriteFont ScoreFont { get; set; } = FontLoader.Load("ScoreFont");

		public Label TimerText { get; set; }
		public Label LivesText { get; set; }
		public Label BlockLeftText { get; set; }

		public Footer(Scene scene, Texture2D background) : base(scene, background)
		{
			Position = new Vector2(0, GlobalData.Screen.Height - ScoreFont.LineSpacing);

			TimerText = new Label(ScoreFont, "", GlobalData.Theme["Silver"]);
			LivesText = new Label(ScoreFont, "", GlobalData.Theme["Green"]);
			BlockLeftText = new Label(ScoreFont, "", GlobalData.Theme["LightRed"]);
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(background, Position, Color.White);

			string seconds = TimeSpan.FromSeconds(scene.Timer.Counter).Seconds.ToString("00");
			string minutes = TimeSpan.FromSeconds(scene.Timer.Counter).Minutes.ToString("00");

			TimerText.Text = minutes + ":" + seconds;
			LivesText.Text = "Lives: " + scene.Player.Live.ToString();
			BlockLeftText.Text = "Block Left: " + scene.BlockLeft.ToString();

			AlignText(TimerText, Alignment.Center);
			AlignText(LivesText, Alignment.Left);
			AlignText(BlockLeftText, Alignment.Right);

			TimerText.Draw(spriteBatch);
			LivesText.Draw(spriteBatch);
			BlockLeftText.Draw(spriteBatch);
		}
	}
}

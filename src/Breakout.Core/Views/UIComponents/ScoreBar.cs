using Breakout.Core.Models;
using Breakout.Core.Views.Enums;
using Breakout.Core.Views.Loaders;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Breakout.Core.Views.UIComponents
{
	public class ScoreBar
	{
		private Texture2D background;
		private Scene scene;

		public Vector2 Position;
		public int Width { get { return background.Width; } }
		public int Height { get { return background.Height; } }

		public Text Score;
		public Text Timer;
		public Text Live;
		public Text BlockLeft;

		public ScoreBar(Scene scene)
		{
			SpriteFont scoreFont = FontLoader.Load("ScoreFont");
			SpriteFont headlineFont = FontLoader.Load("HeadlineFont");

			this.scene = scene;
			this.background = TextureLoader.Load("ScoreBar");

			Position = new Vector2()
			{
				X = 0,
				Y = GameInfo.Screen.Height - scoreFont.LineSpacing,
			};

			Score = new Text(headlineFont, GameInfo.Theme["Yellow"], new Vector2());
			Timer = new Text(scoreFont, GameInfo.Theme["White"], new Vector2(0, this.Position.Y));
			Live = new Text(scoreFont, GameInfo.Theme["Green"], new Vector2(0, this.Position.Y));
			BlockLeft = new Text(scoreFont, GameInfo.Theme["LightRed"], new Vector2(0, this.Position.Y));
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(background, Position, Color.White);

			string score = scene.Player.Score.Score.ToString();

			string seconds = TimeSpan.FromSeconds(scene.Timer.Counter).Seconds.ToString("00");
			string minutes = TimeSpan.FromSeconds(scene.Timer.Counter).Minutes.ToString("00");
			string timer = minutes + ":" + seconds;

			string lives = "Lives: " + scene.Player.Live.ToString();
			string blockLeft = "Block Left: " + scene.BlockLeft.ToString();

			Score.Draw(spriteBatch, score, Alignment.Center);
			Timer.Draw(spriteBatch, timer, Alignment.Center);
			Live.Draw(spriteBatch, lives, Alignment.Left);
			BlockLeft.Draw(spriteBatch, blockLeft, Alignment.Right);
		}
	}
}

using Breakout.Models;
using Breakout.Views.Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Breakout.Views.UIComponents
{
	public class ScoreBar
	{
		private Texture2D background;
		private Scene scene;
		private float margin = 5f;

		public Vector2 Position;
		public int Width { get { return background.Width; } }
		public int Height { get { return background.Height; } }

		public ScoreUI Score;
		public ScoreUI Live;
		public ScoreUI BlockLeft;

		public ScoreBar(Scene scene)
		{
			SpriteFont scoreFont = FontLoader.Load("ScoreFont");

			this.scene = scene;
			this.background = TextureLoader.Load("ScoreBar");

			Position = new Vector2()
			{
				X = 0,
				Y = GameInfo.Screen.Height - scoreFont.LineSpacing,
			};


			Score = new ScoreUI(scoreFont, GameInfo.Theme["Yellow"]);
			Live = new ScoreUI(scoreFont, GameInfo.Theme["Green"]);
			BlockLeft = new ScoreUI(scoreFont, GameInfo.Theme["LightRed"]);

			Score.Position = new Vector2(0, this.Position.Y);
			Live.Position = new Vector2(0, this.Position.Y);
			BlockLeft.Position = new Vector2(0, this.Position.Y);
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(background, Position, Color.White);

			Score.Draw(spriteBatch, scene.Player.Score, Alignment.Center);
			Live.Draw(spriteBatch, scene.Player.Live, Alignment.Left);
			Live.Draw(spriteBatch, scene.BlockLeft, Alignment.Right);
		}
	}
}

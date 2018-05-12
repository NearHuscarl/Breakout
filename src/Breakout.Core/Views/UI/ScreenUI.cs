using Breakout.Models.Windows;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Breakout.Views.UI
{
	public class ScreenUI : Sprite
	{
		protected SpriteFont font;
		protected Color fgColor;

		protected float margin;


		public ScreenUI(Texture2D texture, SpriteFont font, Color fgColor) : base(texture)
		{
			this.font = font;
			this.fgColor = fgColor;
			this.margin = 5f;
		}

		public void Draw(SpriteBatch spriteBatch, GameScreen screen)
		{
			spriteBatch.Draw(this.Texture, screen.Position, Color.White);
			spriteBatch.DrawString(font, screen.Title, GetTitlePosition(screen), fgColor);
			spriteBatch.DrawString(font, screen.Text, GetTextPosition(screen), fgColor);
		}

		protected Vector2 GetTitlePosition(GameScreen screen)
		{
			return new Vector2()
			{
				X = screen.Position.X + screen.Width / 2 - font.MeasureString(screen.Title).X / 2,
				Y = screen.Position.Y + font.MeasureString(screen.Title).Y * 0.1f,
			};
		}

		protected virtual Vector2 GetTextPosition(GameScreen screen)
		{
			return new Vector2()
			{
				X = screen.Position.X + screen.Width / 2 - font.MeasureString(screen.Text).X / 2,
				Y = screen.Position.Y + margin + GetTitlePosition(screen).Y,
			};
		}
	}
}

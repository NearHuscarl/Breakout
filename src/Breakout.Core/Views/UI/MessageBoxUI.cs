using Breakout.Models;
using Breakout.Models.Windows;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Breakout.Views.UI
{
	public class MessageBoxUI : ScreenUI
	{
		public MessageBoxUI(Texture2D texture, SpriteFont font, Color fgColor)
			: base(texture, font, fgColor)
		{

		}

		protected override Vector2 GetTextPosition(GameScreen screen)
		{
			return new Vector2()
			{
				X = screen.Position.X + screen.Width / 2 - font.MeasureString(screen.Text).X / 2,
				Y = screen.Position.Y + margin + font.MeasureString(screen.Text).Y * 5,
			};
		}
	}
}

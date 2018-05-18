using Breakout.Views.Windows;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Breakout.Views.Screens
{
	public class MessageBox : WindowScreen
	{
		private Label prompt;

		public Button YesButton { get; set; }
		public Button NoButton { get; set; }

		public MessageBox(string title, string text)
		{
			background = TextureLoader.Load("MessageBox");

			Title.Text = title;
			prompt = new Label(spriteFont, text);

			YesButton = WindowFactory.CreateButton(new Vector2(), "Yes");
			NoButton = WindowFactory.CreateButton(new Vector2(), "No");

			YesButton.Position = new Vector2()
			{
				X = GetControlXPosition(YesButton, 1, 2),
				Y = Position.Y + Height * 0.75f,
			};

			NoButton.Position = new Vector2()
			{
				X = GetControlXPosition(NoButton, 2, 2),
				Y = Position.Y + Height * 0.75f,
			};
		}

		private Vector2 GetPromptPosition()
		{
			return new Vector2()
			{
				X = Position.X + Width / 2 - spriteFont.MeasureString(prompt.Text).X / 2,
				Y = Position.Y + Margin + spriteFont.MeasureString(prompt.Text).Y * 5,
			};
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			base.Draw(spriteBatch);

			prompt.Position = GetPromptPosition();
			prompt.Draw(spriteBatch);

			YesButton.Draw(spriteBatch);
			NoButton.Draw(spriteBatch);
		}
	}
}

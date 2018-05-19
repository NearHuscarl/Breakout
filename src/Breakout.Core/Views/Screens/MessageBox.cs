using Breakout.Core.Views.Loaders;
using Breakout.Core.Views.Windows;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Breakout.Core.Views.Screens
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
			prompt = new Label(defaultFont, text);

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

		public override void Draw(SpriteBatch spriteBatch)
		{
			base.Draw(spriteBatch);

			SetTextPosition(prompt, 75f);
			prompt.Draw(spriteBatch);

			YesButton.Draw(spriteBatch);
			NoButton.Draw(spriteBatch);
		}
	}
}

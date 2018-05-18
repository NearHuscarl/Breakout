using Breakout.Models;
using Breakout.Views.Windows;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Text;

namespace Breakout.Views.Screens
{
	public class AboutScreen : BigScreen
	{
		public Button OpenCodeButton { get; set; }
		public Button CancelButton { get; set; }
		public Label AboutInfo { get; set; }

		public AboutScreen()
		{
			Title.Text = "About";

			AboutInfo = new Label(spriteFont, GetAboutInfo());

			AboutInfo.Position = new Vector2()
			{
				X = Position.X + Width / 2 - spriteFont.MeasureString(AboutInfo.Text).X / 2,
				Y = Position.Y + Margin + GetTitlePosition().Y,
			};


			//float margin = (this.Width - 2 * SpriteInfo.ButtonWidth) / 3;

			//Vector2 cancelPosition = new Vector2()
			//{
			//	X = Position.X + margin,
			//	Y = Position.Y + Height * 0.75f,
			//};

			//Vector2 openCodePosition = new Vector2()
			//{
			//	X = Position.X + margin + SpriteInfo.ButtonWidth + margin,
			//	Y = Position.Y + Height * 0.75f,
			//};

			OpenCodeButton = WindowFactory.CreateButton(new Vector2(), "Source Code");
			CancelButton = WindowFactory.CreateButton(new Vector2(), "Cancel");

			OpenCodeButton.Position = new Vector2()
			{
				X = GetControlXPosition(OpenCodeButton, 1, 2),
				Y = Position.Y + Height * 0.75f,
			};

			CancelButton.Position = new Vector2()
			{
				X = GetControlXPosition(CancelButton, 2, 2),
				Y = Position.Y + Height * 0.75f,
			};
		}

		private string GetAboutInfo()
		{
			StringBuilder builder = new StringBuilder();

			builder.AppendLine($"Author: {GameInfo.Author}");
			builder.AppendLine();
			builder.AppendLine($"License: {GameInfo.License}");
			builder.AppendLine();
			builder.AppendLine($"Version: {GameInfo.CurrentVersion}");

			return builder.ToString();
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			base.Draw(spriteBatch);

			AboutInfo.Draw(spriteBatch);

			OpenCodeButton.Draw(spriteBatch);
			CancelButton.Draw(spriteBatch);
		}
	}
}

using Breakout.Core.Models;
using Breakout.Core.Models.Data;
using Breakout.Core.Views.Windows;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Text;

namespace Breakout.Core.Views.Screens
{
	public class AboutScreen : BigScreen
	{
		public Button OpenCodeButton { get; set; }
		public Button CancelButton { get; set; }
		public Label AboutInfo { get; set; }

		public AboutScreen()
		{
			Title.Text = "About";

			AboutInfo = new Label(defaultFont, GetAboutInfo());

			AboutInfo.Position = new Vector2()
			{
				X = Position.X + Width / 2 - defaultFont.MeasureString(AboutInfo.Text).X / 2,
				Y = Position.Y + Margin + GetTitlePosition().Y,
			};

			OpenCodeButton = WindowFactory.CreateButton("Source Code");
			CancelButton = WindowFactory.CreateButton("Cancel");

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

			builder.AppendLine($"Author: {GlobalData.Author}");
			builder.AppendLine();
			builder.AppendLine($"License: {GlobalData.License}");
			builder.AppendLine();
			builder.AppendLine($"Version: {GlobalData.CurrentVersion}");

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

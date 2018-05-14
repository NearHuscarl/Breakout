using Breakout.Models.UIComponents;
using Microsoft.Xna.Framework;
using System.Text;

namespace Breakout.Models.Windows
{
	public class AboutScreen : GameScreen
	{
		public Button OpenCodeButton { get; set; }
		public Button CancelButton { get; set; }

		public AboutScreen()
		{
			Title = "About";

			StringBuilder builder = new StringBuilder();

			builder.AppendLine("Author: Near Huscarl");
			builder.AppendLine();
			builder.AppendLine("License: BSD 3-Clauses");
			builder.AppendLine();
			builder.AppendLine($"Version: {GameInfo.CurrentVersion}");

			Text = builder.ToString();


			float margin = (this.Width - 2 * GameInfo.ButtonWidth) / 3;

			Vector2 cancelPosition = new Vector2()
			{
				X = Position.X + margin,
				Y = Position.Y + Height * 0.75f,
			};

			Vector2 openCodePosition = new Vector2()
			{
				X = Position.X + margin + GameInfo.ButtonWidth + margin,
				Y = Position.Y + Height * 0.75f,
			};

			OpenCodeButton = WindowFactory.CreateButton(openCodePosition, "Source Code");
			CancelButton = WindowFactory.CreateButton(cancelPosition, "Cancel");
		}
	}
}

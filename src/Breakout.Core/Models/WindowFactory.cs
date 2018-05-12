using Breakout.Models.UIComponents;
using Breakout.Models.Windows;
using Microsoft.Xna.Framework;

namespace Breakout.Models
{
	public static class WindowFactory
	{
		public static Button CreateStartButton()
		{
			return new Button(width: GameInfo.ButtonWidth, height: GameInfo.ButtonHeight, xRatio: 0.5f, yRatio: 0.5f, text: "Start Game");
		}

		public static Button CreateAboutButton()
		{
			return new Button(width: GameInfo.ButtonWidth, height: GameInfo.ButtonHeight, xRatio: 0.5f, yRatio: 0.6f, text: "About");
		}

		public static Button CreateExitButton()
		{
			return new Button(width: GameInfo.ButtonWidth, height: GameInfo.ButtonHeight, xRatio: 0.5f, yRatio: 0.7f, text: "Exit Game");
		}

		public static Button CreateYesButton(MessageBox msgBox)
		{
			float margin = (msgBox.Width - 2 * GameInfo.ButtonWidth) / 3;

			Vector2 position = new Vector2()
			{
				X = msgBox.Position.X + margin,
				Y = msgBox.Position.Y + msgBox.Height * 0.75f,
			};

			return new Button(width: GameInfo.ButtonWidth, height: GameInfo.ButtonHeight, position: position, text: "Yes");
		}
		public static Button CreateNoButton(MessageBox msgBox)
		{
			float margin = (msgBox.Width - 2 * GameInfo.ButtonWidth) / 3;

			Vector2 position = new Vector2()
			{
				X = msgBox.Position.X + margin + GameInfo.ButtonWidth + margin,
				Y = msgBox.Position.Y + msgBox.Height * 0.75f,
			};

			return new Button(width: GameInfo.ButtonWidth, height: GameInfo.ButtonHeight, position: position, text: "No");
		}

		public static Button CreateButton(Vector2 position, string text)
		{
			return new Button(width: GameInfo.ButtonWidth, height: GameInfo.ButtonHeight, position: position, text: text);
		}
	}
}

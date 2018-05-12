using Breakout.Models.UIComponents;
using Microsoft.Xna.Framework;

namespace Breakout.Models.Windows
{
	public class MessageBox : GameScreen
	{
		public Button YesButton { get; set; }
		public Button NoButton { get; set; }

		public MessageBox(string title, string text)
		{
			Title = title;
			Text = text;

			Resize(width: 500, height: 300);

			YesButton = WindowFactory.CreateYesButton(this);
			NoButton = WindowFactory.CreateNoButton(this);
		}
	}
}

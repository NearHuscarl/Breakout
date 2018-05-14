using Breakout.Models.Bases;
using Microsoft.Xna.Framework;

namespace Breakout.Models.Windows
{
	/// <summary>
	/// A screen is a Rectangle to group buttons and text. It's bigger than
	/// MessageBox and used in game screen like settings screen, about screen...
	/// </summary>
	public class GameScreen : GameObject
	{
		public string Title { get; set; } = "";
		public string Text { get; set; } = "";

		public GameScreen()
		{
			Resize(width: 550, height: 400);
		}

		protected void Resize(int width, int height)
		{
			Width = width;
			Height = height;

			Position = new Vector2()
			{
				X = GameInfo.Screen.Width / 2 - Width / 2,
				Y = GameInfo.Screen.Height / 2 - Height / 2,
			};
		}
	}
}

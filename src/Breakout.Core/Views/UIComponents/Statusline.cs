using Breakout.Core.Models;
using Breakout.Core.Views.Enums;
using Breakout.Core.Views.Windows;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Breakout.Core.Views.UIComponents
{
	public abstract class Statusline
	{
		protected Texture2D background;
		protected Scene scene;

		public Vector2 Position;

		public Statusline(Scene scene, Texture2D background)
		{
			this.scene = scene;
			this.background = background;
		}

		public void AlignText(Label label, Alignment alignment, string offsetText = "", int verticalOffset=0)
		{
			float x;
			float contentLength = label.Font.MeasureString(label.Text).X;
			float offsetLength = label.Font.MeasureString(offsetText).X;

			if (alignment == Alignment.Left)
			{
				x = 5 + offsetLength;
			}
			else if (alignment == Alignment.Right)
			{
				x = GlobalData.Screen.Width - 5 - contentLength - offsetLength;
			}
			else // (alignment == Alignment.Center)
			{
				x = GlobalData.Screen.Width / 2 - contentLength / 2;
			}

			label.Position = new Vector2(x, Position.Y + verticalOffset);
		}
	}
}

using Breakout.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Breakout.Views.Windows
{
	public abstract class Control
	{
		protected SpriteFont font;

		public Vector2 Position;
		public virtual int Width { get; set; }
		public virtual int Height { get; set; }

		public virtual string Text { get; set; }

		public Color ForegroundColor { get; set; } = GameInfo.Theme["White"];
		public Color BackgroundColor { get; set; } = GameInfo.Theme["Black"];

		public virtual Rectangle Rectangle { get; }

		public abstract void Draw(SpriteBatch spriteBatch);
	}
}

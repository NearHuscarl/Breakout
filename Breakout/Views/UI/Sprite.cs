using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Views.UI
{
	public class Sprite
	{
		public Texture2D Texture { get; set; }
		public Vector2 Position { get; set; }

		public Rectangle Rectangle
		{
			get
			{
				return new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);
			}
		}

		public Sprite(Texture2D texture, Vector2 position)
		{
			Texture = texture;
			Position = position;
		}
	}
}

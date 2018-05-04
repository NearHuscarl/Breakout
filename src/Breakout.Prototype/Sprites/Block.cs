using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Breakout.Sprites
{
	public class Block : Sprite
	{
		public Block(Texture2D texture, Vector2 position) : base(texture)
		{
			this.position = position;
		}

		public void Update(GameTime gameTime)
		{

		}
	}
}

using Breakout.Models.Bases;
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

		public Sprite()
		{

		}

		public Sprite(Texture2D texture)
		{
			Texture = texture;
		}

		public void Draw(SpriteBatch spriteBatch, GameObject model)
		{
			spriteBatch.Draw(this.Texture, model.Position, Color.White);
		}
	}
}

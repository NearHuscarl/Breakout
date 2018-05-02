using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace Breakout.Fonts
{
	public class Live : Font
	{
		public Live(SpriteFont font) : base(font)
		{
			content = "3";
		}

		public void Take(int amount=1)
		{
			int lives = Int32.Parse(content);

			content = (lives - amount).ToString();
		}

		public void Get(int amount=1)
		{
			int lives = Int32.Parse(content);

			content = (lives + amount).ToString();
		}

		public int Amount()
		{
			return Int32.Parse(content);
		}
	}
}

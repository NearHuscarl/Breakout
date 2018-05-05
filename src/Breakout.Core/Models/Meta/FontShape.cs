using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Models.Meta
{
	public class FontShape : Shape
	{
		private int fontWidth
		{
			get
			{
				return Width;
			}
		}

		public FontShape(int width, int height) : base(width, height)
		{
			
		}

		public int GetLength(string str)
		{
			return fontWidth * str.Length;
		}
	}
}

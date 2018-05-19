namespace Breakout.Core.Models.Shapes
{
	public struct FontShape
	{
		public int Width { get; set; }
		public int Height { get; set; }

		private int fontWidth
		{
			get
			{
				return Width;
			}
		}

		public FontShape(int width, int height)
		{
			Width = width;
			Height = height;
		}

		public int GetLength(string str)
		{
			return fontWidth * str.Length;
		}
	}
}

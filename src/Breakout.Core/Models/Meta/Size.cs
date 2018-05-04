﻿using Breakout.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Models.Meta
{
	public struct Size
	{
		public int Width { get; set; }
		public int Height { get; set; }

		public Size(int width, int height)
		{
			Width = width;
			Height = height;
		}
	}
}
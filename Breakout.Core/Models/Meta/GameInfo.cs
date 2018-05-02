using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Models.Meta
{
	public static class GameInfo
	{
		public static Size Screen { get; set; }

		public static void Initialize(Size screenSize)
		{
			Screen = screenSize;
		}
	}
}

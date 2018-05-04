using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout
{
	public static class EntryPoint
	{
		public static BreakoutGame Game;
		static void Main()
		{
			using (Game = new BreakoutGame())
				Game.Run();
		}
	}
}

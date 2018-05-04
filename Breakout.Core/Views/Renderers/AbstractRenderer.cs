using Breakout.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Views.Renderers
{
	public abstract class AbstractRenderer
	{
		public abstract void DrawGame();
		public abstract void DrawMenu();
	}
}

using Breakout.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Core.Views.Renderers
{
	public abstract class AbstractRenderer
	{
		public abstract void DrawGame(float elapsed);
		public abstract void DrawMenu(float elapsed);
		public abstract void DrawScreens();
	}
}
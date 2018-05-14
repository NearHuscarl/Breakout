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
		public abstract void DrawGame(float elapsed);
		public abstract void DrawMenu(float elapsed);
		public abstract void DrawExitPrompt();
		public abstract void DrawSetting();
		public abstract void DrawAbout();
	}
}

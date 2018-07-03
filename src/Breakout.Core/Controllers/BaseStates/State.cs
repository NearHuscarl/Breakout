using Breakout.Core.Utilities.Helper;
using Breakout.Core.Views.Renderers;

namespace Breakout.Core.Controllers.BaseStates
{
	public abstract class State
	{
		public virtual void Update()
		{
			InputHelper.GetInput();
		}

		public virtual void Draw(MonoGameRenderer renderer)
		{

		}
	}
}

using Breakout.Core.Views.Renderers;

namespace Breakout.Core.Controllers.BaseStates
{
	public abstract class GameState : State
	{
		public override void Draw(MonoGameRenderer renderer)
		{
			renderer.DrawGame(EntryPoint.Game.Elapsed);
		}
	}
}

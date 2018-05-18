using Breakout.Models.IO;
using Breakout.Utilities;
using Breakout.Views.Renderers;

namespace Breakout.Controllers.States
{
	public class WinningState : State
	{
		public override void Update()
		{
			base.Update();

			if (InputHelper.IsNewKeyPress(Input.Confirm))
			{
				//StateMachine.NextLevel();
			}
		}

		public override void Draw(MonoGameRenderer renderer)
		{
			renderer.DrawGame(EntryPoint.Game.Elapsed);
		}
	}
}

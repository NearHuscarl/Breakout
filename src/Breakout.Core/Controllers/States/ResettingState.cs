using Breakout.Models;
using Breakout.Views.Renderers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Controllers.States
{
	public class ResettingState : State
	{
		public override void Update()
		{
			base.Update();

			Scene.Reset();
			StateMachine.StartGame();
		}

		public override void Draw(MonoGameRenderer renderer)
		{
			renderer.DrawGame(EntryPoint.Game.Elapsed);
		}
	}
}

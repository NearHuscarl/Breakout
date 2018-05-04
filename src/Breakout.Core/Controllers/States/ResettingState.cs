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
			Scene.Reset();
			StartGame();
		}

		private static void StartGame()
		{
			EntryPoint.Game.IsMouseVisible = false;
			StateMachine.ChangeState("PauseState");
		}

		public override void Draw(MonoGameRenderer renderer)
		{
			renderer.DrawGame();
		}
	}
}

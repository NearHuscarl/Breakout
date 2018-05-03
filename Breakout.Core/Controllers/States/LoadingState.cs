using Breakout.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Controllers.States
{
	public class LoadingState : State
	{
		public override void Update()
		{
			Scene.InitializeGame();
			StartGame();
		}

		private static void StartGame()
		{
			EntryPoint.Game.IsMouseVisible = false;
			StateMachine.ChangeState("ReadyState");
		}
	}
}

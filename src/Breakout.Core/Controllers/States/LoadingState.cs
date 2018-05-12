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
			base.Update();

			Scene.InitializeGame();
			StateMachine.StartGame();
		}
	}
}

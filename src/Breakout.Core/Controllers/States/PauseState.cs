using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Breakout.Models;
using Breakout.Views.Renderers;
using Microsoft.Xna.Framework.Input;

namespace Breakout.Controllers.States
{
	public class PauseState : State
	{
		public override void Update()
		{
			if (Keyboard.GetState().IsKeyDown(Keys.Space))
			{
				PlayGame();
			}
		}

		private static void PlayGame()
		{
			StateMachine.ChangeState("GameState");
		}

		public override void Draw(MonoGameRenderer renderer)
		{
			renderer.DrawGame();
		}
	}
}

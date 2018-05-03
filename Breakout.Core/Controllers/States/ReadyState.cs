using Breakout.Models;
using Breakout.Views.Renderers;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Controllers.States
{
	class ReadyState : State
	{
		public override void Update()
		{
			if (Keyboard.GetState().IsKeyDown(Keys.Space))
			{
				Scene.Balls.ForEach(ball => ball.ResetPosition());
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

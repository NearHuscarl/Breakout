using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Breakout.Models;
using Breakout.Models.IO;
using Breakout.Utilities;
using Breakout.Views.Renderers;
using Microsoft.Xna.Framework.Input;

namespace Breakout.Controllers.States
{
	public class PauseState : State
	{
		public override void Update()
		{
			InputHelper.GetInput();

			if (InputHelper.IsKeyDown(Input.PlayGame))
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

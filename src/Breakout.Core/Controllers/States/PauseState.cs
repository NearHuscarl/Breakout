using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Breakout.Models;
using Breakout.Models.IO;
using Breakout.Models.Windows;
using Breakout.Utilities;
using Breakout.Views.Renderers;
using Microsoft.Xna.Framework.Input;

namespace Breakout.Controllers.States
{
	public class PauseState : State
	{
		public override void Update()
		{
			base.Update();

			if (InputHelper.IsNewKeyPress(Input.PlayGame))
			{
				StateMachine.PlayGame();
			}
			else if (InputHelper.IsNewKeyPress(Input.Exit))
				StateMachine.ExitGame();
		}

		public override void Draw(MonoGameRenderer renderer)
		{
			renderer.DrawGame(EntryPoint.Game.Elapsed);
		}
	}
}

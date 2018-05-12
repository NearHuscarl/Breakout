using Breakout.Models;
using Breakout.Models.UIComponents;
using Breakout.Utilities;
using Breakout.Views.Renderers;
using Breakout.Views.UI;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Controllers.States
{
	public class MenuState : State
	{
		public override void Update()
		{
			base.Update();

			Button startButton = Scene.Buttons["Start"];
			Button aboutButton = Scene.Buttons["About"];
			Button exitButton = Scene.Buttons["Exit"];

			HandleButton(startButton, StateMachine.LoadGame);
			HandleButton(aboutButton, StateMachine.OpenAbout);
			HandleButton(exitButton, StateMachine.ExitApp);

			Scene.Step(EntryPoint.Game.Elapsed);
		}

		public override void Draw(MonoGameRenderer renderer)
		{
			renderer.DrawMenu(EntryPoint.Game.Elapsed);
		}
	}
}

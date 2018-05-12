using Breakout.Models;
using Breakout.Models.Balls;
using Breakout.Models.IO;
using Breakout.Models.Windows;
using Breakout.Utilities;
using Breakout.Views.Renderers;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Controllers.States
{
	public class GameState : State
	{
		public override void Update()
		{
			base.Update();

			if (InputHelper.IsKeyDown(Input.PauseGame))
				StateMachine.PauseGame();

			else if (InputHelper.IsNewKeyPress(Input.MovePaddleLeft))
				Scene.Paddle.DriftLeft(EntryPoint.Game.Elapsed);

			else if (InputHelper.IsNewKeyPress(Input.MovePaddleRight))
				Scene.Paddle.DriftRight(EntryPoint.Game.Elapsed);

			else if (InputHelper.IsKeyDown(Input.MovePaddleLeft))
				Scene.Paddle.MoveLeft(EntryPoint.Game.Elapsed);

			else if (InputHelper.IsKeyDown(Input.MovePaddleRight))
				Scene.Paddle.MoveRight(EntryPoint.Game.Elapsed);

			else if (InputHelper.IsNewKeyPress(Input.Exit))
				StateMachine.ExitGame();

			Scene.Step(EntryPoint.Game.Elapsed);

			if (Scene.Balls.Count == 0)
			{
				if (Scene.Player.Live == 0)
					StateMachine.GameOver();
				else
					StateMachine.ResetGame();
			}
		}

		public override void Draw(MonoGameRenderer renderer)
		{
			renderer.DrawGame(EntryPoint.Game.Elapsed);
		}
	}
}

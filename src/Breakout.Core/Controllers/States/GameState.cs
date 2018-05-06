using Breakout.Models;
using Breakout.Models.Balls;
using Breakout.Models.IO;
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
			InputHelper.GetInput();

			if (InputHelper.IsKeyDown(Input.PauseGame))
				PauseGame();

			else if (InputHelper.IsNewKeyPress(Input.MovePaddleLeft))
				Scene.Paddle.DriftLeft(EntryPoint.Game.Elapsed);

			else if (InputHelper.IsNewKeyPress(Input.MovePaddleRight))
				Scene.Paddle.DriftRight(EntryPoint.Game.Elapsed);

			else if (InputHelper.IsKeyDown(Input.MovePaddleLeft))
				Scene.Paddle.MoveLeft(EntryPoint.Game.Elapsed);

			else if (InputHelper.IsKeyDown(Input.MovePaddleRight))
				Scene.Paddle.MoveRight(EntryPoint.Game.Elapsed);

			Scene.Step(EntryPoint.Game.Elapsed);

			if (Scene.Balls.Count == 0)
			{
				if (Scene.Player.Live == 0)
					GameOver();
				else
					ResetGame();
			}
		}

		private static void PauseGame()
		{
			StateMachine.ChangeState("PauseState");
		}

		private static void ResetGame()
		{
			Scene.Player.Live.Take(1);
			Scene.Reset();
			StateMachine.ChangeState("PauseState");
		}

		private static void GameOver()
		{
			StateMachine.ChangeState("MenuState"); // TODO: Prompt asking to continue or not
		}

		public override void Draw(MonoGameRenderer renderer)
		{
			renderer.DrawGame();
		}
	}
}

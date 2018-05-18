﻿using Breakout.Models.IO;
using Breakout.Utilities;
using Breakout.Views.Renderers;

namespace Breakout.Controllers.States
{
	public class GameState : State
	{
		public override void Update()
		{
			base.Update();

			if (InputHelper.IsKeyDown(Input.PauseGame))
			{
				StateMachine.PauseGame();
			}

			else if (InputHelper.IsNewKeyPress(Input.MovePaddleLeft))
			{
				StateMachine.Scene.Paddle.DriftLeft(EntryPoint.Game.Elapsed);
			}

			else if (InputHelper.IsNewKeyPress(Input.MovePaddleRight))
			{
				StateMachine.Scene.Paddle.DriftRight(EntryPoint.Game.Elapsed);
			}

			else if (InputHelper.IsKeyDown(Input.MovePaddleLeft))
			{
				StateMachine.Scene.Paddle.MoveLeft(EntryPoint.Game.Elapsed);
			}

			else if (InputHelper.IsKeyDown(Input.MovePaddleRight))
			{
				StateMachine.Scene.Paddle.MoveRight(EntryPoint.Game.Elapsed);
			}

			else if (InputHelper.IsNewKeyPress(Input.Exit))
			{
				StateMachine.ExitGame();
			}

			StateMachine.Scene.Step(EntryPoint.Game.Elapsed);

			if (StateMachine.Scene.Balls.Count == 0)
			{
				if (StateMachine.Scene.Player.Live.Count == 0)
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

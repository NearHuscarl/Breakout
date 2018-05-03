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
	public class GameState : State
	{
		public override void Update()
		{
			if (Keyboard.GetState().IsKeyDown(Keys.P))
				PauseGame();

			if (Keyboard.GetState().IsKeyDown(Keys.Left))
				Scene.Paddle.MoveLeft(EntryPoint.Game.Elapsed);

			else if (Keyboard.GetState().IsKeyDown(Keys.Right))
				Scene.Paddle.MoveRight(EntryPoint.Game.Elapsed);

			foreach (var ball in Scene.Balls)
			{
				if (ball.IsOffBottom())
					GameOver();

				ball.HandleWallCollision();
				ball.HandleCollision(Scene.Paddle);

				Scene.Blocks.ForEach(block => ball.HandleCollision(block));
				ball.UpdateMovement(EntryPoint.Game.Elapsed);
			}
		}

		private static void PauseGame()
		{
			StateMachine.ChangeState("PauseState");
		}

		private static void GameOver()
		{
			StateMachine.ChangeState("ReadyState");
		}

		public override void Draw(MonoGameRenderer renderer)
		{
			renderer.DrawGame();
		}
	}
}

using Breakout.Models;
using Breakout.Views.Renderers;
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
			foreach (var ball in Scene.Balls)
			{
				if (ball.IsHittingLeftWall() || ball.IsHittingRightWall())
					ball.Direction.X = -ball.Direction.X;

				if (ball.IsHittingRoof())
					ball.Direction.Y = -ball.Direction.Y;

				if (ball.IsOffBottom())
				{
					Scene.IsPlaying = false;
					GameOver();
				}

				foreach (var block in Scene.Blocks)
				{

				}
			}
		}

		private static void GameOver()
		{
			StateMachine.ChangeState("PauseState");
		}

		public override void Draw(MonoGameRenderer renderer)
		{
			renderer.DrawGame();
		}

		// private void MoveBall()
		// {
		// 	// if ball hit block. reduce health, if block's health is 0
		// 	// delete block and have a chance to spawn PowerUp
		// 	if (BallUI.IsOffBottom(screenHeight))
		// 	{

		// 	}
		// }
	}
}

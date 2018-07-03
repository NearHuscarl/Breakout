using Breakout.Core.Controllers.BaseStates;
using Breakout.Core.Models;
using Breakout.Core.Models.IO;
using Breakout.Core.Utilities.Helper;
using Breakout.Core.Utilities.Map;
using Breakout.Core.Views.Renderers;
using Microsoft.Xna.Framework.Input;

namespace Breakout.Core.Controllers.GameStates
{
	public class PlayState : GameState
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

			else if (InputHelper.IsNewKeyPress(Keys.Delete)) // TODO: remove dubgging code
			{
				StateMachine.Scene.BlockLeft = 0;
			}

			StateMachine.Scene.Step(EntryPoint.Game.Elapsed);

			if (StateMachine.Scene.Balls.Count == 0)
			{
				if (StateMachine.Scene.Player.Live == 0)
				{
					StateMachine.GameOver();
				}
				else
				{
					StateMachine.ResetGame();
				}
			}

			if (StateMachine.Scene.BlockLeft == 0)
			{
				FinishGame();
			}
		}

		private void FinishGame()
		{
			if (MapManager.CanNextLevel(GlobalData.Session.CurrentLevel))
			{
				StateMachine.WinGame();
			}
			else
			{
				StateMachine.WinAll();
			}
		}
	}
}

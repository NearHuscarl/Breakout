using Breakout.Core.Models.IO;
using Breakout.Core.Views;
using Breakout.Core.Views.Renderers;
using Breakout.Core.Views.Screens;
using Breakout.Core.Views.Windows;
using Breakout.Core.Models.Data;
using Breakout.Core.Models;
using Breakout.Core.Utilities.Helper;
using Breakout.Core.Controllers.BaseStates;
using Breakout.Core.Utilities.Audio;

namespace Breakout.Core.Controllers.MenuStates
{
	public class WinningState : ScreenState
	{
		public override void Update()
		{
			base.Update();

			var winningScreen = (WinningScreen)WindowManager.CurrentScreen;

			Button restartButton = winningScreen.RestartButton;
			Button nextButton = winningScreen.NextButton;

			HandleButton(restartButton, Restart);
			HandleButton(nextButton, NextLevel);

			if (InputHelper.IsNewKeyPress(Input.Confirm))
			{
				NextLevel();
			}

			if (winningScreen.Stage == SummerizedStage.Score)
			{
				SummerizeScore();
			}
			else if (winningScreen.Stage == SummerizedStage.Star)
			{
				winningScreen.AddStar(EntryPoint.Game.Elapsed);
			}
			// SummerizedStage.Done
		}

		private void SummerizeScore()
		{
			var winningScreen = (WinningScreen)WindowManager.CurrentScreen;

			if (StateMachine.Scene.Player.Score.Score > 0)
			{
				AudioManager.PlaySound("AddScore");
				winningScreen.DisplayedScore += 4;
				StateMachine.Scene.Player.Score.Score -= 4;
				return;
			}

			if (StateMachine.Scene.Player.HighestCombo > 0)
			{
				AudioManager.PlaySound("AddScore");
				winningScreen.DisplayedScore += 5;
				StateMachine.Scene.Player.HighestCombo--;
				return;
			}

			if (StateMachine.Scene.Timer.Counter > 0)
			{
				AudioManager.PlaySound("AddScore");
				winningScreen.DisplayedScore += winningScreen.TimeBonusUpdateAmount;
				StateMachine.Scene.Timer.Counter--;
				return;
			}

			winningScreen.StarCount = GetStars();
			winningScreen.Stage = SummerizedStage.Star;
		}

		private int GetStars()
		{
			if (StateMachine.Scene.FinalScore > 3800)
				return 3;
			else if (StateMachine.Scene.FinalScore > 3500)
				return 2;
			else
				return 1;
		}

		private void Restart()
		{
			WindowManager.CloseWindow();
			StateMachine.Restart();
		}

		private void NextLevel()
		{
			WindowManager.CloseWindow();
						
			Session session = new Session()
			{
				CurrentLevel = GlobalData.Session.CurrentLevel + 1,
				CurrentLives = StateMachine.Scene.Player.Live,
				CurrentScore = StateMachine.Scene.HighScore + StateMachine.Scene.FinalScore,
			};

			GlobalData.Session = session;

			StateMachine.Scene.InitializeGame(session);
			StateMachine.PauseGame();
		}

		public override void Draw(MonoGameRenderer renderer)
		{
			renderer.DrawGame(EntryPoint.Game.Elapsed);
		}
	}
}

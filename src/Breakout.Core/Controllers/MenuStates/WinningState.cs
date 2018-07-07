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
using System;
using System.Linq;

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

			if (winningScreen == null)
			{
				return;
			}

			if (winningScreen.Stage == SummerizedStage.Score)
			{
				SummerizeScore(winningScreen);
			}
			else if (winningScreen.Stage == SummerizedStage.Star)
			{
				winningScreen.AddStar(EntryPoint.Game.Elapsed);
			}
			// SummerizedStage.Done
		}

		private void SummerizeScore(WinningScreen winningScreen)
		{
			var player = StateMachine.Scene.Player;

			if (player.Score.Value > 0)
			{
				var updateAmount = (int)Math.Ceiling(winningScreen.ScoreUpdateAmount);

				winningScreen.DisplayedScore += updateAmount;
				player.Score.Value -= updateAmount;
				player.Score.Value = Math.Max(0, player.Score.Value);

				AudioManager.PlaySound("AddScore");
				return;
			}

			if (player.HighestCombo > 0)
			{
				var updateAmount = (int)Math.Ceiling(winningScreen.ComboUpdateAmount);

				winningScreen.DisplayedScore += updateAmount;
				player.HighestCombo -= updateAmount;
				player.HighestCombo = Math.Max(0, player.HighestCombo);

				AudioManager.PlaySound("AddScore");
				return;
			}

			if (StateMachine.Scene.Timer.Counter > 0)
			{
				var updateAmount = (int)Math.Ceiling(winningScreen.TimeBonusUpdateAmount);

				winningScreen.DisplayedScore += updateAmount;
				StateMachine.Scene.Timer.Counter -= winningScreen.TimerUpdateAmount;
				StateMachine.Scene.Timer.Counter = Math.Max(0, StateMachine.Scene.Timer.Counter);

				AudioManager.PlaySound("AddScore");
				return;
			}

			winningScreen.DisplayedScore = StateMachine.Scene.FinalScore;

			winningScreen.StarCount = GetStars();
			winningScreen.Stage = SummerizedStage.Star;
		}

		private int GetStars()
		{
			var scoreFor2Star = MapManager.Maps.Where(m => m.Name == StateMachine.Scene.MapName).Select(m => m.ScoreFor2Star).First();
			var scoreFor3Star = MapManager.Maps.Where(m => m.Name == StateMachine.Scene.MapName).Select(m => m.ScoreFor3Star).First();

			if (StateMachine.Scene.FinalScore >= scoreFor3Star)
				return 3;
			else if (StateMachine.Scene.FinalScore >= scoreFor2Star)
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

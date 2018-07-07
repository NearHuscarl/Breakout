using Breakout.Core.Models;
using Breakout.Core.Utilities;
using Breakout.Core.Views.Enums;
using Breakout.Core.Views.Loaders;
using Breakout.Core.Views.UIComponents;
using Breakout.Core.Views.Windows;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Threading;

namespace Breakout.Core.Views.Screens
{
	public enum SummerizedStage
	{
		Score,
		Star,
		Done,
	}

	public class WinningScreen : BigScreen
	{
		public Label WinningText { get; set; }
		public Label ScoreText { get; set; }

		public Button RestartButton { get; set; }
		public Button NextButton { get; set; }

		public int StarCount { get; set; }

		public Star Star1 { get; set; }
		public Star Star2 { get; set; }
		public Star Star3 { get; set; }

		private DelayedAction addStar1;
		private DelayedAction addStar2;
		private DelayedAction addStar3;

		public int DisplayedScore { get; set; } = 0;

		public float ScoreUpdateAmount { get; set; }
		public float TimeBonusUpdateAmount { get; set; }
		public float TimerUpdateAmount { get; set; }
		public float ComboUpdateAmount { get; set; }

		public SummerizedStage Stage { get; set; }

		public WinningScreen()
		{
			Stage = SummerizedStage.Score;

			RestartButton = WindowFactory.CreateButton("Restart");
			NextButton = WindowFactory.CreateButton("Next");

			RestartButton.Position = new Vector2()
			{
				X = GetControlXPosition(NextButton, 1, 2),
				Y = Position.Y + Height * 0.75f,
			};

			NextButton.Position = new Vector2()
			{
				X = GetControlXPosition(NextButton, 2, 2),
				Y = Position.Y + Height * 0.75f,
			};

			WinningText = new Label(FontLoader.Load("HeaderFont"), "You Win!", GlobalData.Theme["Blue"]);
			ScoreText = new Label(FontLoader.Load("HeaderFont"), "", GlobalData.Theme["LightMagenta"]);

			Star1 = WindowFactory.CreateStar();
			Star2 = WindowFactory.CreateStar();
			Star3 = WindowFactory.CreateStar();

			Star2.Position = new Vector2()
			{
				X = Position.X + Width / 2 - Star1.Width / 2,
				Y = Position.Y + Height * 0.30f,
			};

			Star1.Position = new Vector2()
			{
				X = Position.X + Width / 2 - Star1.Width / 2 - Star1.Width * 1.25f,
				Y = Star2.Position.Y + 20,
			};

			Star3.Position = new Vector2()
			{
				X = Position.X + Width / 2 - Star1.Width / 2 + Star1.Width * 1.25f,
				Y = Star2.Position.Y + 20,
			};

			addStar1 = new DelayedAction(Star1.Shine, 0.5f);
			addStar2 = new DelayedAction(Star2.Shine, 1.0f);
			addStar3 = new DelayedAction(Star3.Shine, 1.5f);
		}

		public void AddStar(float deltaTime)
		{
			if (IsDone())
				Stage = SummerizedStage.Done;

			addStar1.Update(deltaTime);

			if (StarCount == 1)
				return;

			addStar2.Update(deltaTime);

			if (StarCount == 2)
				return;

			addStar3.Update(deltaTime);
		}

		private bool IsDone()
		{
			if (StarCount == 1 && Star1.IsShine)
				return true;

			if (StarCount == 2 && Star1.IsShine && Star2.IsShine)
				return true;

			if (StarCount == 3 && Star1.IsShine && Star2.IsShine && Star3.IsShine)
				return true;

			return false;
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			base.Draw(spriteBatch);

			AlignText(WinningText, Alignment.Center, 25);
			AlignText(ScoreText, Alignment.Center, 175);

			ScoreText.Text = DisplayedScore.ToString("N0");

			WinningText.Draw(spriteBatch);
			ScoreText.Draw(spriteBatch);

			RestartButton.Draw(spriteBatch);
			NextButton.Draw(spriteBatch);

			Star1.Draw(spriteBatch);
			Star2.Draw(spriteBatch);
			Star3.Draw(spriteBatch);
		}
	}
}

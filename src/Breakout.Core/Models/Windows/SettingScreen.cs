using Breakout.Models.Enums;
using Breakout.Models.UIComponents;
using Microsoft.Xna.Framework;

namespace Breakout.Models.Windows
{
	public class SettingScreen : GameScreen
	{
		public Button ApplyButton { get; set; }
		public Button CancelButton { get; set; }
		public CheckBox Mute { get; set; }
		public RadioGroup Difficulties { get; set; }

		public SettingScreen()
		{
			Title = "Setting";

			float margin = (this.Width - 2 * GameInfo.ButtonWidth) / 3;

			Vector2 cancelPosition = new Vector2()
			{
				X = Position.X + margin,
				Y = Position.Y + Height * 0.75f,
			};

			Vector2 openCodePosition = new Vector2()
			{
				X = Position.X + margin + GameInfo.ButtonWidth + margin,
				Y = Position.Y + Height * 0.75f,
			};

			ApplyButton = WindowFactory.CreateButton(openCodePosition, "Apply");
			CancelButton = WindowFactory.CreateButton(cancelPosition, "Cancel");

			Mute = WindowFactory.CreateCheckBox(new Vector2(Position.X + 200f, Position.Y + 60), "Mute", GameInfo.IsMute);

			Difficulties = new RadioGroup(new RadioButton[]
			{
				WindowFactory.CreateRadioButton(new Vector2(Position.X + 200f, Position.Y + 130f), "Easy", GameInfo.Difficulty == Difficulty.Easy),
				WindowFactory.CreateRadioButton(new Vector2(Position.X + 200f, Position.Y + 180f), "Normal", GameInfo.Difficulty == Difficulty.Normal),
				WindowFactory.CreateRadioButton(new Vector2(Position.X + 200f, Position.Y + 230f), "Hard", GameInfo.Difficulty == Difficulty.Hard),
			});
		}
	}
}

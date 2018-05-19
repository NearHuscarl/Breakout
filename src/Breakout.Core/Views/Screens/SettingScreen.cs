using Breakout.Core.Models;
using Breakout.Core.Models.Enums;
using Breakout.Core.Utilities;
using Breakout.Core.Views.Windows;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Breakout.Core.Views.Screens
{
	public class SettingScreen : BigScreen
	{
		public Label SoundText { get; set; }
		public Label DifficultyText { get; set; }
		public CheckBox MuteCheckbox { get; set; }
		public RadioGroup DifficultiesRadioGroup { get; set; }

		public Button ApplyButton { get; set; }
		public Button CancelButton { get; set; }

		public SettingScreen()
		{
			Title.Text = "Setting";

			ApplyButton = WindowFactory.CreateButton(new Vector2(), "Apply");
			CancelButton = WindowFactory.CreateButton(new Vector2(), "Cancel");

			ApplyButton.Position = new Vector2()
			{
				X = GetControlXPosition(ApplyButton, 1, 2),
				Y = Position.Y + Height * 0.75f,
			};

			CancelButton.Position = new Vector2()
			{
				X = GetControlXPosition(CancelButton, 2, 2),
				Y = Position.Y + Height * 0.75f,
			};


			Vector2 soundTextPosition =      new Vector2(Position.X + 100f, Position.Y + 70f);
			Vector2 difficultyTextPosition = new Vector2(Position.X + 100f, Position.Y + 140f);

			Vector2 muteCheckboxPosition =   new Vector2(Position.X + 200f, Position.Y + 60f);

			Vector2 easyRadioBtnPosition =   new Vector2(Position.X + 200f, Position.Y + 130f);
			Vector2 normalRadioBtnPosition = new Vector2(Position.X + 200f, Position.Y + 180f);
			Vector2 hardRadioBtnPosition =   new Vector2(Position.X + 200f, Position.Y + 230f);


			SoundText = WindowFactory.CreateLabel(soundTextPosition, "Sound");
			DifficultyText = WindowFactory.CreateLabel(difficultyTextPosition, "Difficulty");

			MuteCheckbox = WindowFactory.CreateCheckBox(muteCheckboxPosition, "Mute", AudioManager.IsMute);

			DifficultiesRadioGroup = new RadioGroup(new RadioButton[]
			{
				WindowFactory.CreateRadioButton(easyRadioBtnPosition, "Easy", GameInfo.Difficulty == Difficulty.Easy),
				WindowFactory.CreateRadioButton(normalRadioBtnPosition, "Normal", GameInfo.Difficulty == Difficulty.Normal),
				WindowFactory.CreateRadioButton(hardRadioBtnPosition, "Hard", GameInfo.Difficulty == Difficulty.Hard),
			});
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			base.Draw(spriteBatch);

			SoundText.Draw(spriteBatch);
			DifficultyText.Draw(spriteBatch);

			MuteCheckbox.Draw(spriteBatch);
			DifficultiesRadioGroup.Draw(spriteBatch);

			ApplyButton.Draw(spriteBatch);
			CancelButton.Draw(spriteBatch);
		}
	}
}

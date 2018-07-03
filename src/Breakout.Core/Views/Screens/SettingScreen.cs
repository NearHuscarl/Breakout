using Breakout.Core.Models;
using Breakout.Core.Models.Enums;
using Breakout.Core.Utilities.Audio;
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

			ApplyButton = WindowFactory.CreateButton("Apply");
			CancelButton = WindowFactory.CreateButton("Cancel");

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

			SoundText = WindowFactory.CreateLabel("Sound");
			DifficultyText = WindowFactory.CreateLabel("Difficulty");

			MuteCheckbox = WindowFactory.CreateCheckBox("Mute", AudioManager.IsMute);

			DifficultiesRadioGroup = new RadioGroup(new RadioButton[]
			{
				WindowFactory.CreateRadioButton("Easy",   GlobalData.Settings.Difficulty == Difficulty.Easy),
				WindowFactory.CreateRadioButton("Normal", GlobalData.Settings.Difficulty == Difficulty.Normal),
				WindowFactory.CreateRadioButton("Hard",   GlobalData.Settings.Difficulty == Difficulty.Hard),
			});

			SoundText.Position =      new Vector2(Position.X + 100f, Position.Y + 70f);
			DifficultyText.Position = new Vector2(Position.X + 100f, Position.Y + 140f);

			MuteCheckbox.Position = new Vector2(Position.X + 200f, Position.Y + 60f);

			DifficultiesRadioGroup.RadioButtons[0].Position = new Vector2(Position.X + 200f, Position.Y + 130f);
			DifficultiesRadioGroup.RadioButtons[1].Position = new Vector2(Position.X + 200f, Position.Y + 180f);
			DifficultiesRadioGroup.RadioButtons[2].Position = new Vector2(Position.X + 200f, Position.Y + 230f);
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

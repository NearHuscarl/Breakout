using Breakout.Extensions;
using Breakout.Models;
using Breakout.Models.Enums;
using Breakout.Models.IO;
using Breakout.Utilities;
using Breakout.Views;
using Breakout.Views.Renderers;
using Breakout.Views.Screens;
using Breakout.Views.Windows;
using System.Linq;

namespace Breakout.Controllers.States
{
	public class SettingState : State
	{
		private SettingScreen settingScreen;

		public override void AddScreen()
		{
			foreach (var screen in WindowManager.Screens)
			{
				if (screen is SettingScreen)
				{
					settingScreen = (SettingScreen)screen;
					return;
				}
			}
		}

		public override void Update()
		{
			base.Update();

			if (InputHelper.IsNewKeyPress(Input.Exit))
				StateMachine.ChangeToPreviousState();

			Button applyButton = settingScreen.ApplyButton;
			Button cancelButton = settingScreen.CancelButton;
			CheckBox muteCheckBox = settingScreen.MuteCheckbox;
			RadioGroup difficultyRadios = settingScreen.DifficultiesRadioGroup;

			HandleButton(applyButton, ApplyChange);
			HandleButton(cancelButton, StateMachine.ChangeToPreviousState);
			HandleCheckBox(muteCheckBox);
			HandleRadioGroup(difficultyRadios);

			StateMachine.Scene.Step(EntryPoint.Game.Elapsed);
		}

		private void ApplyChange()
		{
			var difficulty = (from option in settingScreen.DifficultiesRadioGroup.RadioButtons
								  where option.IsChecked
								  select option.Text).FirstOrDefault();

			GameInfo.Difficulty = EnumExtension.ParseEnum<Difficulty>(difficulty);
			AudioManager.IsMute = settingScreen.MuteCheckbox.IsChecked;

			StateMachine.ChangeToPreviousState();
		}

		public override void Draw(MonoGameRenderer renderer)
		{
			renderer.DrawMenu(EntryPoint.Game.Elapsed);
		}
	}
}

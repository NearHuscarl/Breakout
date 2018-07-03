using Breakout.Extensions;
using Breakout.Core.Models;
using Breakout.Core.Models.Enums;
using Breakout.Core.Models.IO;
using Breakout.Core.Views;
using Breakout.Core.Views.Renderers;
using Breakout.Core.Views.Screens;
using Breakout.Core.Views.Windows;
using System.Linq;
using Breakout.Core.Models.Data;
using Breakout.Core.Utilities.Audio;
using Breakout.Core.Utilities.Helper;
using Breakout.Core.Controllers.BaseStates;

namespace Breakout.Core.Controllers.MenuStates
{
	public class SettingState : ScreenState
	{
		public override void Update()
		{
			base.Update();

			var settingScreen = (SettingScreen)WindowManager.CurrentScreen;

			if (InputHelper.IsNewKeyPress(Input.Exit))
			{
				StateMachine.ChangeToPreviousState();
			}

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
			var settingScreen = (SettingScreen)WindowManager.CurrentScreen;

			var difficulty = (from option in settingScreen.DifficultiesRadioGroup.RadioButtons
								  where option.IsChecked
								  select option.Text).FirstOrDefault();

			Settings settings = new Settings()
			{
				Difficulty = EnumExtension.ParseEnum<Difficulty>(difficulty),
				IsMute = settingScreen.MuteCheckbox.IsChecked,
			};

			GlobalData.Settings = settings;
			AudioManager.IsMute = settings.IsMute;

			StateMachine.ChangeToPreviousState();
		}

		public override void Draw(MonoGameRenderer renderer)
		{
			renderer.DrawMenu(EntryPoint.Game.Elapsed);
		}
	}
}

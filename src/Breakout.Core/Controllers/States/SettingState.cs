using Breakout.Extensions;
using Breakout.Core.Models;
using Breakout.Core.Models.Enums;
using Breakout.Core.Models.IO;
using Breakout.Core.Utilities;
using Breakout.Core.Views;
using Breakout.Core.Views.Renderers;
using Breakout.Core.Views.Screens;
using Breakout.Core.Views.Windows;
using System.Linq;

namespace Breakout.Core.Controllers.States
{
	public class SettingState : State
	{
		private SettingScreen settingScreen;

		public override void AddScreen()
		{
			WindowManager.OpenSetting(out settingScreen);
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

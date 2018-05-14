using Breakout.Extensions;
using Breakout.Models;
using Breakout.Models.Enums;
using Breakout.Models.UIComponents;
using Breakout.Models.Windows;
using Breakout.Views.Renderers;
using System;
using System.Linq;

namespace Breakout.Controllers.States
{
	public class SettingState : State
	{
		public override void Update()
		{
			base.Update();

			SettingScreen settingScreen = (SettingScreen)WindowManager.CurrentScreen;

			Button applyButton = settingScreen.ApplyButton;
			Button cancelButton = settingScreen.CancelButton;
			CheckBox muteCheckBox = settingScreen.Mute;
			RadioGroup difficultyRadios = settingScreen.Difficulties;

			HandleButton(applyButton, ApplyChange);
			HandleButton(cancelButton, StateMachine.ChangeToPreviousState);
			HandleCheckBox(muteCheckBox);
			HandleRadioGroup(difficultyRadios);

			EntryPoint.Game.Scene.Step(EntryPoint.Game.Elapsed);
		}

		private void ApplyChange()
		{
			SettingScreen settingScreen = (SettingScreen)WindowManager.CurrentScreen;

			var difficulty = (from option in settingScreen.Difficulties.RadioButtons.Values
								  where option.Checked
								  select option.Text).FirstOrDefault();

			GameInfo.Difficulty = EnumExtension.ParseEnum<Difficulty>(difficulty);
			GameInfo.IsMute = settingScreen.Mute.Checked;

			StateMachine.ChangeToPreviousState();
		}

		public override void Draw(MonoGameRenderer renderer)
		{
			renderer.DrawSetting();
		}
	}
}

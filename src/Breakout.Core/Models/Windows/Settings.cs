using Breakout.Models.UIComponents;

namespace Breakout.Models.Windows
{
	public class Settings : GameScreen
	{
		public CheckBox MuteCheckbox { get; set; }
		public RadioGroup Difficulties { get; set; }

		public void HandleInput()
		{
			MuteCheckbox.HandleInput();
			Difficulties.HandleInput();
		}
	}
}

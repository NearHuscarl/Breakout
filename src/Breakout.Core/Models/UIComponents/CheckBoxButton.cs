using Breakout.Models.Bases;

namespace Breakout.Models.UIComponents
{
	public class CheckBoxButton : RectangleObject, IButton
	{
		private bool isChecked;

		public bool Checked
		{
			get { return isChecked; }

			set
			{
				if (isChecked == value)
					return;

				// AudioManager.PlaySound("ButtonChecked");
				isChecked = value;
			}
		}

		public string Text { get; protected set; }
	}
}

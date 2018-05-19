using Breakout.Core.Utilities;

namespace Breakout.Core.Models.Scores
{
	public class Timer
	{
		public int Counter { get; set; }
		public DelayedAction Count { get; private set; }

		public Timer()
		{
			Count = new DelayedAction(UpdateTimer, 1);
		}

		private void UpdateTimer()
		{
			Counter++;
		}
	}
}

using System;

namespace Breakout.Core.Utilities
{
	/// <summary>
	/// A class to execute an Action after an interval by calling Update method
	/// </summary>
	public class DelayedAction
	{
		public DelayedAction(Action action, float interval)
		{
			TimeRemaining = interval;
			Action = action;
			Interval = interval;
		}

		public Action Action { get; private set; }
		public float Interval { get; private set; }
		public float TimeRemaining { get; private set; }

		public void Update(float deltaTime)
		{
			TimeRemaining -= deltaTime;

			if (TimeRemaining <= 0)
			{
				Action();
				TimeRemaining = Interval;
			}
		}
	}
}

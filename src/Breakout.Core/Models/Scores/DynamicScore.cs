using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Breakout.Core.Models.Scores
{
	/// <summary>
	/// Score that increase gradually through time :D
	/// </summary>
	public class DynamicScore
	{
		/// <summary>
		/// The total time to increase each new score
		/// </summary>
		private static readonly float updateTime = 100f; // in milisecond

		private int currentScore = 0;
		private int scoreToUpdate = 0;

		private Stack<int> stack;

		private Thread t1;
		private bool isDone = false;

		public int Value
		{
			get { return scoreToUpdate; }
			set { scoreToUpdate = value; }
		}

		public DynamicScore()
		{
			Awake();
		}

		public DynamicScore(Vector2 position)
		{
			Awake();
		}

		public void Awake()
		{
			stack = new Stack<int>();
			t1 = new Thread(UpdateScore);
			t1.Start();
		}

		private void UpdateScore()
		{
			while (true)
			{
				if (stack.Count > 0)
				{
					int addedScore = stack.Pop();
					int newScore = addedScore + currentScore;
					float updateAmount = addedScore / updateTime;

					for (float i = currentScore; i <= newScore; i += updateAmount)
					{
						scoreToUpdate = (int)i;
						Thread.Sleep(1);
					}

					scoreToUpdate = currentScore + addedScore;
					currentScore = scoreToUpdate;
				}

				if (isDone)
					return;
			}
		}

		public void AddScore(int point)
		{
			stack.Push(point);
		}

		public void StopRecording()
		{
			isDone = true;
			t1.Abort();
		}
	}
}

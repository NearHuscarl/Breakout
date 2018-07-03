using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Threading;

namespace Breakout.Core.Models.Scores
{
	/// <summary>
	/// Score that increase gradually through time :D
	/// </summary>
	public class DynamicScore
	{
		private int currentScore = 0;
		private int scoreToUpdate = 0;

		private Stack<int> stack;

		private Thread t1;
		private bool isDone = false;

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
					int newScore = stack.Pop() + currentScore;

					for (int i = currentScore; i <= newScore; i++)
					{
						scoreToUpdate = i;
						Thread.Sleep(1);
					}

					currentScore = scoreToUpdate;
				}

				if (isDone)
					return;
			}
		}

		public int Score
		{
			get
			{
				return scoreToUpdate;
			}
			set
			{
				scoreToUpdate = value;
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

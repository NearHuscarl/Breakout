using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Breakout.Models.Texts
{
	public class ScoreManager : Text
	{
		private int currentScore { get; set; } = 0;
		private int scoreToUpdate { get; set; } = 0;

		private Stack<int> stack;

		private Thread t1;
		private bool isDone = false;

		public ScoreManager() : base(0, "Score: ")
		{
			Awake();
		}

		public ScoreManager(Vector2 position) : base(0, "Score: ", position)
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

		public override string Content
		{
			get
			{
				return scoreToUpdate.ToString();
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

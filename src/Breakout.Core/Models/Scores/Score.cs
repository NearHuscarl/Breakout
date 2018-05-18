using Microsoft.Xna.Framework;
using System;

namespace Breakout.Models.Scores
{
	public class Score
	{
		public virtual int Count { get; private set; }

		public string Prompt { get; private set; } = "";

		/// Prompt + Content + Margin
		public string FullText
		{
			get
			{
				return " " + Prompt + Count + " ";
			}
		}

		public Score()
		{

		}

		public Score(string prompt)
		{
			Prompt = prompt;
		}

		public Score(string prompt, int initialScore)
		{
			Prompt = prompt;
			Count = initialScore;
		}

		public void Take(int amount)
		{
			Count -= amount;
		}

		public void Add(int amount)
		{
			Count += amount;
		}

		public void Set(int num)
		{
			Count = num;
		}

		public static bool operator > (Score score1, Score score2)
		{
			if (score1.Count > score2.Count)
			{
				return true;
			}

			return false;
		}

		public static bool operator < (Score score1, Score score2)
		{
			if (score1.Count < score2.Count)
			{
				return true;
			}

			return false;
		}

		public static bool operator == (Score score1, Score score2)
		{
			if (score1.Count == score2.Count)
			{
				return true;
			}

			return false;
		}

		public static bool operator != (Score score1, Score score2)
		{
			if (score1.Count != score2.Count)
			{
				return true;
			}

			return false;
		}

		public override bool Equals(Object obj)
		{
			Score score = obj as Score;

			if (score == null)
			{
				return false;
			}

			if (this == score)
			{
				return true;
			}

			return false;
		}

		public override int GetHashCode()
		{
			return FullText.GetHashCode();
		}
	}
}

using Breakout.Models.Scores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Models.Players
{
	public class Player : IPlayer
	{
		public int Live { get; set; }
		public ScoreManager Score { get; set; }
		public int CurrentCombo { get; set; }
		public int HighestCombo { get; set; }

		public Player()
		{
			Score = new ScoreManager();
			Live = 3;
			CurrentCombo = 0;
			HighestCombo = 0;
		}

		public void IncreaseScore(int amount)
		{

		}
	}
}

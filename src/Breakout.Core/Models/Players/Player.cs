using Breakout.Models.Texts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Models.Players
{
	public class Player : IPlayer
	{
		public Text Live { get; set; }
		public ScoreManager Score { get; set; }
		public Text CurrentCombo { get; set; }
		public Text HighestCombo { get; set; }

		public Player()
		{
			//Score = new ScoreManager();
			//Live = new Text(3);
			//CurrentCombo = new Text(0);
			//HighestCombo = new Text(0);
		}

		public void IncreaseScore(int amount)
		{

		}
	}
}

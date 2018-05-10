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

		}
	}
}

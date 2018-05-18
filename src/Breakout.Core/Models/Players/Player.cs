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
		public Score Live { get; set; }
		public DynamicScore Score { get; set; }
		public Score CurrentCombo { get; set; }
		public Score HighestCombo { get; set; }

		public Player()
		{

		}
	}
}

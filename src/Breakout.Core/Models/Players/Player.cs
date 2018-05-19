using Breakout.Core.Models.Scores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Core.Models.Players
{
	public class Player : IPlayer
	{
		public int Live { get; set; }
		public DynamicScore Score { get; set; }
		public int CurrentCombo { get; set; }
		public int HighestCombo { get; set; }

		public Player()
		{

		}
	}
}

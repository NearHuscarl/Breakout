using Breakout.Models.Interfaces;
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
		public int Score { get; set; }
		public int CurrentCombo { get; set; }
		public int HighestCombo { get; set; }

		public Player()
		{
			Score = 0;
			Live = 3;
			CurrentCombo = 0;
			HighestCombo = 0;
		}
	}
}

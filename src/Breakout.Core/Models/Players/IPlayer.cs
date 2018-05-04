using Breakout.Models.Scores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Models.Players
{
	public interface IPlayer
	{
		int Live { get; set; }
		ScoreManager Score { get; set; }
		int CurrentCombo { get; set; }
		int HighestCombo { get; set; }
	}
}

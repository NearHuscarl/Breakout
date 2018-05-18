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
		Score Live { get; set; }
		DynamicScore Score { get; set; }
		Score CurrentCombo { get; set; }
		Score HighestCombo { get; set; }
	}
}

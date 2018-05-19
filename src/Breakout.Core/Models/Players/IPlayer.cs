using Breakout.Core.Models.Scores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Core.Models.Players
{
	public interface IPlayer
	{
		int Live { get; set; }
		DynamicScore Score { get; set; }
		int CurrentCombo { get; set; }
		int HighestCombo { get; set; }
	}
}

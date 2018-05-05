using Breakout.Models.Texts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Models.Players
{
	public interface IPlayer
	{
		Text Live { get; set; }
		ScoreManager Score { get; set; }
		Text CurrentCombo { get; set; }
		Text HighestCombo { get; set; }
	}
}

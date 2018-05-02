using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Models.Interfaces
{
	public interface IPlayer
	{
		int Live { get; set; }
		int Score { get; set; }
		int CurrentCombo { get; set; }
		int HighestCombo { get; set; }
	}
}

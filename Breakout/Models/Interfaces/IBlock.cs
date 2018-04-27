using Breakout.Models.PowerUps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Models.Interfaces
{
	public interface IBlock
	{
		PowerUp SpawnPowerUp();
	}
}

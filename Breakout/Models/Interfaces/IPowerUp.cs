using Breakout.Models.Balls;
using Breakout.Models.Paddles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Models.Interfaces
{
	public interface IPowerUp
	{
		void ModifyAbility(Paddle paddle, List<Ball> balls);
	}
}

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Models.Interfaces
{
	public interface IPaddle
	{
		void MoveLeft(int speed);
		void MoveRight(int speed);
		// void TakeLive(int lives);
		// void AddLive(int lives);
	}
}

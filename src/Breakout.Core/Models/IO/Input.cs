using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Models.IO
{
	public static class Input
	{
		public static Keys MovePaddleLeft;
		public static Keys MovePaddleRight;
		public static Keys Fire;
		public static Keys PauseGame;
		public static Keys PlayGame;
		public static Keys Exit;

		public static void SetDefaultInput()
		{
			MovePaddleLeft = Keys.Left;
			MovePaddleRight = Keys.Right;
			Fire = Keys.Space;
			PauseGame = Keys.P;
			PlayGame = Keys.Space;
			Exit = Keys.Escape;
		}
	}
}

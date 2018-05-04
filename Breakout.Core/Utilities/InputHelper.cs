using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Utilities
{
	public static class InputHelper
	{
		private static KeyboardState newKeyboardState;
		private static KeyboardState oldKeyboardState;

		public static void GetInput()
		{
			oldKeyboardState = newKeyboardState;
			newKeyboardState = Keyboard.GetState();
		}

		public static bool IsNewKeyPress(Keys key)
		{
			return newKeyboardState.IsKeyDown(key) && oldKeyboardState.IsKeyUp(key);
		}

		public static bool IsKeyDown(Keys key)
		{
			return newKeyboardState.IsKeyDown(key);
		}

		public static bool IsKeyUp(Keys key)
		{
			return newKeyboardState.IsKeyUp(key);
		}
	}
}

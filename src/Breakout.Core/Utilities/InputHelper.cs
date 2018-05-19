using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Core.Utilities
{
	internal enum MouseButtons
	{
		LeftButton,
		MiddleButton,
		RightButton,
		ExtraButton1,
		ExtraButton2
	}

	internal static class InputHelper
	{
		private static KeyboardState newKeyboardState;
		private static KeyboardState oldKeyboardState;

		private static MouseState newMouseState;
		private static MouseState oldMouseState;

		public static void GetInput()
		{
			oldKeyboardState = newKeyboardState;
			newKeyboardState = Keyboard.GetState();

			oldMouseState = newMouseState;
			newMouseState = Mouse.GetState();
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

		public static bool IsMouseHold(MouseButtons button)
		{
			switch (button)
			{
				case MouseButtons.LeftButton:
					return (oldMouseState.LeftButton == ButtonState.Pressed &&
							newMouseState.LeftButton == ButtonState.Pressed);

				case MouseButtons.RightButton:
					return (oldMouseState.RightButton == ButtonState.Pressed &&
							newMouseState.RightButton == ButtonState.Pressed);

				case MouseButtons.MiddleButton:
					return (oldMouseState.MiddleButton == ButtonState.Pressed &&
							newMouseState.MiddleButton == ButtonState.Pressed);

				case MouseButtons.ExtraButton1:
					return (oldMouseState.XButton1 == ButtonState.Pressed &&
							newMouseState.XButton1 == ButtonState.Pressed);

				case MouseButtons.ExtraButton2:
					return (oldMouseState.XButton2 == ButtonState.Pressed &&
							newMouseState.XButton2 == ButtonState.Pressed);

				default:
					return false;
			}
		}

		public static bool IsMouseRelease(MouseButtons button)
		{
			switch (button)
			{
				case MouseButtons.LeftButton:
					return (oldMouseState.LeftButton == ButtonState.Pressed &&
							newMouseState.LeftButton == ButtonState.Released);

				case MouseButtons.RightButton:
					return (oldMouseState.RightButton == ButtonState.Pressed &&
							newMouseState.RightButton == ButtonState.Released);

				case MouseButtons.MiddleButton:
					return (oldMouseState.MiddleButton == ButtonState.Pressed &&
							newMouseState.MiddleButton == ButtonState.Released);

				case MouseButtons.ExtraButton1:
					return (oldMouseState.XButton1 == ButtonState.Pressed &&
							newMouseState.XButton1 == ButtonState.Released);

				case MouseButtons.ExtraButton2:
					return (oldMouseState.XButton2 == ButtonState.Pressed &&
							newMouseState.XButton2 == ButtonState.Released);

				default:
					return false;
			}
		}

		public static Vector2 GetMousePosition()
		{
			return new Vector2(newMouseState.X, newMouseState.Y);
		}
	}
}

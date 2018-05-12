using Breakout.Models;
using Breakout.Models.IO;
using Breakout.Views;
using Breakout.Views.Renderers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Controllers.States
{
	public class InitialState : State
	{
		public override void Update()
		{
			base.Update();

			GameInfo.Screen = new Rectangle()
			{
				Width = EntryPoint.Game.graphics.PreferredBackBufferWidth,
				Height = EntryPoint.Game.graphics.PreferredBackBufferHeight,
			};

			GameInfo.Initialize();
			Input.SetDefaultInput();

			ChangeBackgroundColor(GameInfo.Theme["Dark"]);

			StateMachine.OpenMenu();
		}

		private static void ChangeBackgroundColor(Color color)
		{
			EntryPoint.Game.GraphicsDevice.Clear(color);
		}
	}
}

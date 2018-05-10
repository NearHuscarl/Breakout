﻿using Breakout.Models;
using Breakout.Models.IO;
using Breakout.Models.Meta;
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
			GameInfo.Screen = new Shape()
			{
				Width = EntryPoint.Game.graphics.PreferredBackBufferWidth,
				Height = EntryPoint.Game.graphics.PreferredBackBufferHeight,
			};

			GameInfo.Initialize();
			ModelFactory.Initialize();

			Input.SetDefaultInput();

			ChangeBackgroundColor(GameInfo.Theme["Dark"]);
			Scene.InitializeMenu();

			OpenMenu();
		}

		private static void OpenMenu()
		{
			StateMachine.ChangeState("MenuState");
		}

		private static void ChangeBackgroundColor(Color color)
		{
			EntryPoint.Game.GraphicsDevice.Clear(color);
		}
	}
}

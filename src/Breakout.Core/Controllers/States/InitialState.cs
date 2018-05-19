using Breakout.Core.Models;
using Breakout.Core.Models.IO;
using Breakout.Core.Utilities;
using Breakout.Core.Views;
using Breakout.Core.Views.Renderers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Core.Controllers.States
{
	public class InitialState : State
	{
		public override void Update()
		{
			base.Update();

			GameInfo.Screen = new Rectangle()
			{
				Width = EntryPoint.Game.Graphics.PreferredBackBufferWidth,
				Height = EntryPoint.Game.Graphics.PreferredBackBufferHeight,
			};

			GameInfo.Initialize();

			Input.SetDefaultInput();

			AudioManager.LoadSound(EntryPoint.Game.Content, GameInfo.Sounds);

			ChangeBackgroundColor(GameInfo.Theme["Dark"]);

			StateMachine.OpenMenu();
		}

		private static void ChangeBackgroundColor(Color color)
		{
			EntryPoint.Game.GraphicsDevice.Clear(color);
		}
	}
}

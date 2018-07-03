using Breakout.Core.Controllers.BaseStates;
using Breakout.Core.Models;
using Breakout.Core.Models.IO;
using Breakout.Core.Utilities.Audio;
using Breakout.Core.Utilities.Map;
using Microsoft.Xna.Framework;

namespace Breakout.Core.Controllers.TransitionStates
{
	public class InitialState
	{
		public override void Update()
		{
			GlobalData.Screen = new Rectangle()
			{
				Width = EntryPoint.Game.Graphics.PreferredBackBufferWidth,
				Height = EntryPoint.Game.Graphics.PreferredBackBufferHeight,
			};

			GlobalData.Initialize();

			AudioManager.LoadSound(EntryPoint.Game.Content);
			AudioManager.IsMute = GlobalData.Settings.IsMute;

			MapManager.Initialize(EntryPoint.Game.Content);

			Input.SetDefaultInput();

			ChangeBackgroundColor(GlobalData.Theme["Dark"]);

			StateMachine.OpenMenu();
		}

		private static void ChangeBackgroundColor(Color color)
		{
			EntryPoint.Game.GraphicsDevice.Clear(color);
		}
	}
}

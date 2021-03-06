﻿using Breakout.Core.Views.Loaders;

namespace Breakout.Core.Views.Screens
{
	/// <summary>
	/// A big screen is a Rectangle to group buttons and text. It's bigger than
	/// MessageBox and used in game screen like settings screen, about screen...
	/// </summary>
	public abstract class BigScreen : WindowScreen
	{
		public BigScreen()
		{
			this.background = TextureLoader.Load("Screen");
		}
	}
}

using Breakout.Models;
using Breakout.Views.Windows;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Breakout.Views.Screens
{
	/// <summary>
	/// A screen is a Rectangle to group buttons and text. It's bigger than
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

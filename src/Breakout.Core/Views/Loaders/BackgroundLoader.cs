using Breakout.Core.Views.UIComponents;
using Microsoft.Xna.Framework.Graphics;

namespace Breakout.Core.Views.Loaders
{
	public class BackgroundLoader
	{
		private static readonly string bgPath = "Backgrounds/";

		public static Texture2D Load(string backgroundName)
		{
			return EntryPoint.Game.Content.Load<Texture2D>(bgPath + backgroundName);
		}
	}
}

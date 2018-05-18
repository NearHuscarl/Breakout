using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Breakout.Views
{
	public static class FontLoader
	{
		private static Dictionary<string, SpriteFont> fonts = new Dictionary<string, SpriteFont>()
		{
			{ "ScoreFont", EntryPoint.Game.Content.Load<SpriteFont>("Fonts/ScoreFont") },
			{ "MenuFont", EntryPoint.Game.Content.Load<SpriteFont>("Fonts/ButtonFont") },
		};

		public static SpriteFont Load(string fontName)
		{
			return fonts[fontName];
		}
	}
}

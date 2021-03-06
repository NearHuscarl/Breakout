﻿using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Breakout.Core.Views.Loaders
{
	public static class FontLoader
	{
		private static Dictionary<string, SpriteFont> fonts = new Dictionary<string, SpriteFont>()
		{
			{ "ScoreFont", EntryPoint.Game.Content.Load<SpriteFont>("Fonts/ScoreFont") },
			{ "MenuFont", EntryPoint.Game.Content.Load<SpriteFont>("Fonts/MenuFont") },
			{ "HeaderFont", EntryPoint.Game.Content.Load<SpriteFont>("Fonts/HeaderFont") },
			{ "TitleFont", EntryPoint.Game.Content.Load<SpriteFont>("Fonts/TitleFont") },
			{ "BoldTitleFont", EntryPoint.Game.Content.Load<SpriteFont>("Fonts/BoldTitleFont") },
		};

		public static SpriteFont Load(string fontName)
		{
			return fonts[fontName];
		}
	}
}

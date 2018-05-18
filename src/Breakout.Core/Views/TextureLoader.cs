using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Breakout.Views
{
	public static class TextureLoader
	{
		private static Dictionary<string, Texture2D> textures = new Dictionary<string, Texture2D>()
		{
			{ "ButtonInactive",       EntryPoint.Game.Content.Load<Texture2D>("Buttons/Button") },
			{ "ButtonHovered",        EntryPoint.Game.Content.Load<Texture2D>("Buttons/ButtonHover") },
			{ "ButtonClicked",        EntryPoint.Game.Content.Load<Texture2D>("Buttons/ButtonClicked") },
			{ "CheckBoxChecked",      EntryPoint.Game.Content.Load<Texture2D>("Buttons/CheckBoxChecked") },
			{ "CheckBoxUnchecked",    EntryPoint.Game.Content.Load<Texture2D>("Buttons/CheckBoxUnchecked") },
			{ "RadioButtonChecked",   EntryPoint.Game.Content.Load<Texture2D>("Buttons/RadioButtonChecked") },
			{ "RadioButtonUnchecked", EntryPoint.Game.Content.Load<Texture2D>("Buttons/RadioButtonUnchecked") },
			{ "MessageBox",           EntryPoint.Game.Content.Load<Texture2D>("Windows/MessageBox") },
			{ "Screen",               EntryPoint.Game.Content.Load<Texture2D>("Windows/Screen") },
			{ "ScoreBar",				  EntryPoint.Game.Content.Load<Texture2D>("Backgrounds/Footer") },
			// { "", EntryPoint.Game.Content.Load<Texture2D>("") },
			// { "", EntryPoint.Game.Content.Load<Texture2D>("") },
			// { "", EntryPoint.Game.Content.Load<Texture2D>("") },
			// { "", EntryPoint.Game.Content.Load<Texture2D>("") },
			// { "", EntryPoint.Game.Content.Load<Texture2D>("") },
			// { "", EntryPoint.Game.Content.Load<Texture2D>("") },
			// { "", EntryPoint.Game.Content.Load<Texture2D>("") },
			// { "", EntryPoint.Game.Content.Load<Texture2D>("") },
			// { "", EntryPoint.Game.Content.Load<Texture2D>("") },
			// { "", EntryPoint.Game.Content.Load<Texture2D>("") },
			// { "", EntryPoint.Game.Content.Load<Texture2D>("") },
		};

		public static Texture2D Load(string textureName)
		{
			return textures[textureName];
		}
	}
}

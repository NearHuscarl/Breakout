using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Breakout.Core.Views.Loaders
{
	public static class TextureLoader
	{
		private static Dictionary<string, Texture2D> textures = new Dictionary<string, Texture2D>()
		{
			{ "ButtonInactive",        EntryPoint.Game.Content.Load<Texture2D>("Controls/Button") },
			{ "ButtonHovered",         EntryPoint.Game.Content.Load<Texture2D>("Controls/ButtonHover") },
			{ "ButtonClicked",         EntryPoint.Game.Content.Load<Texture2D>("Controls/ButtonClicked") },
			{ "CheckBoxChecked",       EntryPoint.Game.Content.Load<Texture2D>("Controls/CheckBoxChecked") },
			{ "CheckBoxUnchecked",     EntryPoint.Game.Content.Load<Texture2D>("Controls/CheckBoxUnchecked") },
			{ "RadioButtonChecked",    EntryPoint.Game.Content.Load<Texture2D>("Controls/RadioButtonChecked") },
			{ "RadioButtonUnchecked",  EntryPoint.Game.Content.Load<Texture2D>("Controls/RadioButtonUnchecked") },
			{ "Textbox",					EntryPoint.Game.Content.Load<Texture2D>("Controls/Textbox") },
			{ "MessageBox",            EntryPoint.Game.Content.Load<Texture2D>("Windows/MessageBox") },
			{ "Screen",                EntryPoint.Game.Content.Load<Texture2D>("Windows/Screen") },
			{ "Header",                EntryPoint.Game.Content.Load<Texture2D>("Backgrounds/Header") },
			{ "HeaderEdgeLeft",        EntryPoint.Game.Content.Load<Texture2D>("Backgrounds/HeaderEdgeLeft") },
			{ "HeaderEdgeRight",       EntryPoint.Game.Content.Load<Texture2D>("Backgrounds/HeaderEdgeRight") },
			{ "GoldenHeader",          EntryPoint.Game.Content.Load<Texture2D>("Backgrounds/GoldenHeader") },
			{ "GoldenHeaderEdgeRight", EntryPoint.Game.Content.Load<Texture2D>("Backgrounds/GoldenHeaderEdgeRight") },
			{ "Footer",				      EntryPoint.Game.Content.Load<Texture2D>("Backgrounds/Footer") },
			{ "Unstar",                EntryPoint.Game.Content.Load<Texture2D>("Stars/Unstar") },
			{ "Star",					   EntryPoint.Game.Content.Load<Texture2D>("Stars/Star") },
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

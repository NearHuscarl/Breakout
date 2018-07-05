using Breakout.Extensions;
using Breakout.Core.Models.Enums;
using Breakout.Core.Models.Shapes;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Reflection;
using Breakout.Core.Data;
using Breakout.Core.Utilities;
using Breakout.Core.Models.Data;

namespace Breakout.Core.Models
{
	/// <summary>
	/// Encapsulate global game data
	/// </summary>
	public static class GlobalData
	{
		private static Session session;
		private static Settings settings;

		private static SessionAccess sessionAccess;
		private static SettingsAccess settingsAccess;

		public static Session Session
		{
			get { return session; }

			set
			{
				sessionAccess.SaveSession(value);
				session = value;
			}
		}
		public static Settings Settings
		{
			get { return settings; }

			set
			{
				settingsAccess.SaveSettings(value);
				settings = value;
			}
		}

		public static string Author { get; private set; }
		public static string License { get; private set; }
		public static string SourceCodeURL { get; private set; }

		public static Rectangle Screen;

		public static FontShape ScoreFont;
		public static FontShape MenuFont;

		public static Dictionary<string, Color> Theme;

		public static string CurrentVersion
		{
			get
			{
				Version version = Assembly.GetExecutingAssembly().GetName().Version;
				return $"{version.Major}.{version.Minor}.{version.Build}";
			}
		}

		public static SpriteData SpriteData { get; private set; }

		public static int ExplosiveRadius { get; private set; }

		public static void Initialize()
		{
			sessionAccess = new SessionAccess();
			settingsAccess = new SettingsAccess();

			var sessionResult = sessionAccess.LoadSession();
			var settingsResult = settingsAccess.LoadSettings();

			if (sessionResult.Status != Status.Success)
				sessionResult.Print();

			if (settingsResult.Status != Status.Success)
				settingsResult.Print();

			Session = sessionResult.Data;
			Settings = settingsResult.Data;


			Author = "Near Huscarl";
			License = "BSD 3-Clauses";
			SourceCodeURL = "https://github.com/NearHuscarl/Breakout";

			ScoreFont = new FontShape(width: 6, height: 18);
			MenuFont = new FontShape(width: 9, height: 20);

			SpriteData = new SpriteData();

			Theme = new Dictionary<string, Color>()
			{
				{ "Red",          "#c0392b".ToColor() },
				{ "Orange",       "#d35400".ToColor() },
				{ "Yellow",       "#f39c12".ToColor() },
				{ "Green",        "#27ae60".ToColor() },
				{ "Blue",         "#2980b9".ToColor() },
				{ "Cyan",         "#16a085".ToColor() },
				{ "Magenta",      "#8e44ad".ToColor() },
				{ "Gray",         "#7f8c8d".ToColor() },
				{ "Black",        "#2c3e50".ToColor() },

				{ "LightRed",     "#e74c3c".ToColor() },
				{ "LightOrange",  "#e67e22".ToColor() },
				{ "LightYellow",  "#f1c40f".ToColor() },
				{ "LightGreen",   "#2ecc71".ToColor() },
				{ "LightBlue",    "#3498db".ToColor() },
				{ "LightCyan",    "#1abc9c".ToColor() },
				{ "LightMagenta", "#9b59b6".ToColor() },
				{ "LightGray",    "#95a5a6".ToColor() },
				{ "Dark",         "#34495e".ToColor() },

				{ "Silver",       "#bdc3c7".ToColor() },
				{ "White",        "#ecf0f1".ToColor() },
			};

			ExplosiveRadius = 40;
		}
	}
}

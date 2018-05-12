using Breakout.Extensions;
using Breakout.Models.Shapes;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Models
{
	public static class GameInfo
	{
		public static Rectangle Screen;

		public static FontShape ScoreFont;
		public static FontShape MenuFont;

		public static Dictionary<string, Color> Theme;

		public static string SourceCodeURL { get; private set; }

		public static string ScoreText { get; private set; }
		public static string LiveText { get; private set; }
		public static string CurrentComboText { get; private set; }
		public static string HighestComboText { get; private set; }
		public static string BlockLeftText { get; private set; }

		public static int ButtonWidth { get; private set; }
		public static int ButtonHeight { get; private set; }

		public static int PaddleWidth { get; private set; }
		public static int PaddleHeight { get; private set; }

		public static int BallRadius { get; private set; }
		public static int BallStrength { get; private set; }
		public static float BallVelocity { get; private set; }

		public static int BlockWidth { get; private set; }
		public static int BlockHeight { get; private set; }

		public static int PackageWidth { get; private set; }
		public static int PackageHeight { get; private set; }

		public static int ExplosiveRadius { get; private set; }

		public static void Initialize()
		{
			ScoreFont = new FontShape(width: 6, height: 18);
			MenuFont = new FontShape(width: 9, height: 20);

			ScoreText = "Score: ";
			LiveText = "Lives: ";
			CurrentComboText = "Combo: ";
			HighestComboText = "Max Combo: ";
			BlockLeftText = "Block Left: ";

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

			SourceCodeURL = "https://github.com/NearHuscarl/Breakout";

			ButtonWidth = 150;
			ButtonHeight = 40;

			PaddleWidth = 100;
			PaddleHeight = 17;

			BallRadius = 8;
			BallStrength = 5;
			BallVelocity = 6f;

			BlockWidth = 20;
			BlockHeight = 20;

			PackageWidth = 20;
			PackageHeight = 20;

			ExplosiveRadius = 40;
		}
	}
}

using Breakout.Extensions;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Models.Meta
{
	public static class GameInfo
	{
		public static Shape Screen;
		public static Shape Footer;
		public static FontShape Font;
		public static Dictionary<string, Color> Theme;

		public static string ScoreText { get; set; }
		public static string LiveText { get; set; }
		public static string CurrentComboText { get; set; }
		public static string HighestComboText { get; set; }
		public static string BlockLeftText { get; set; }

		public static void Initialize(Shape screenSize)
		{
			Screen = screenSize;

			Font = new FontShape(width: 8, height: 20);

			Footer = new Shape(width: Screen.Width, height: Font.Height)
			{
				Position = new Vector2(0, Screen.Height - Font.Height),
			};

			ScoreText = "Score: ";
			LiveText = "Lives: ";
			CurrentComboText = "Combo: ";
			HighestComboText = "Max Combo: ";
			BlockLeftText = "Block Left: ";

			Theme = new Dictionary<string, Color>()
			{
				{ "Black",        "#2c3e50".ToColor() },
				{ "Dark",         "#34495e".ToColor() },
				{ "DarkGray",     "#7f8c8d".ToColor() },
				{ "Gray",         "#95a5a6".ToColor() },
				{ "LightGray",    "#bdc3c7".ToColor() },
				{ "White",        "#ecf0f1".ToColor() },
				{ "Cyan",         "#16a085".ToColor() },
				{ "LightCyan",    "#1abc9c".ToColor() },
				{ "Green",        "#27ae60".ToColor() },
				{ "LightGreen",   "#2ecc71".ToColor() },
				{ "Blue",         "#2980b9".ToColor() },
				{ "LightBlue",    "#3498db".ToColor() },
				{ "Magenta",      "#8e44ad".ToColor() },
				{ "LightMagenta", "#9b59b6".ToColor() },
				{ "Yellow",       "#f39c12".ToColor() },
				{ "LightYellow",  "#f1c40f".ToColor() },
				{ "Orange",       "#d35400".ToColor() },
				{ "LightOrange",  "#e67e22".ToColor() },
				{ "Red",          "#c0392b".ToColor() },
				{ "LightRed",     "#e74c3c".ToColor() },
			};
		}
	}
}

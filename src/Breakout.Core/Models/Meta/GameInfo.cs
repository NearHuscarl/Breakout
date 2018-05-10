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
		public static FontShape Font;
		public static Dictionary<string, Color> Theme;

		public static string ScoreText { get; set; }
		public static string LiveText { get; set; }
		public static string CurrentComboText { get; set; }
		public static string HighestComboText { get; set; }
		public static string BlockLeftText { get; set; }

		public static void Initialize()
		{
			Font = new FontShape(width: 6, height: 18);

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
		}
	}
}

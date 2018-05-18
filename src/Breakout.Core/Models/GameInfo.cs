﻿using Breakout.Extensions;
using Breakout.Models.Enums;
using Breakout.Models.Shapes;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Models
{
	public static class GameInfo
	{
		public static string Author { get; private set; }
		public static string License { get; private set; }
		public static string SourceCodeURL { get; private set; }

		public static Rectangle Screen;

		public static FontShape ScoreFont;
		public static FontShape MenuFont;

		public static Difficulty Difficulty { get; set; }

		public static Dictionary<string, Color> Theme;
		public static string[] Sounds { get; private set; }

		public static string CurrentVersion
		{
			get
			{
				Version version = Assembly.GetExecutingAssembly().GetName().Version;
				return $"{version.Major}.{version.Minor}.{version.Build}";
			}
		}

		public static SpriteInfo SpriteInfo { get; private set; }

		public static string ScoreText { get; private set; }
		public static string LiveText { get; private set; }
		public static string CurrentComboText { get; private set; }
		public static string HighestComboText { get; private set; }
		public static string BlockLeftText { get; private set; }

		public static float PaddleVelocity
		{
			get
			{
				if (Difficulty == Difficulty.Hard)
					return 1000f;

				return 800f;
			}
		}

		public static PaddleLength PaddleLength
		{
			get
			{
				if (Difficulty == Difficulty.Easy)
					return PaddleLength.Long;

				if (Difficulty == Difficulty.Normal)
					return PaddleLength.Medium;

				return PaddleLength.Short;
			}
		}

		public static int BallStrength { get; private set; }
		public static float BallVelocity
		{
			get
			{
				if (Difficulty == Difficulty.Hard)
					return 400f;

				return 320f;
			}
		}

		public static int ExplosiveRadius { get; private set; }

		public static void Initialize()
		{
			Author = "Near Huscarl";
			License = "BSD 3-Clauses";
			SourceCodeURL = "https://github.com/NearHuscarl/Breakout";

			ScoreFont = new FontShape(width: 6, height: 18);
			MenuFont = new FontShape(width: 9, height: 20);

			Difficulty = Difficulty.Normal;

			SpriteInfo = new SpriteInfo();

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

			Sounds = new string[]
			{
				"ButtonHovered",
				"ButtonClicked",
				"ButtonChecked",

				"HitFlashingBlock",
				"HitLightBlock",
				"HitNormalBlock",
				"HitPowerUp",
				"HitWall",
				"HitPaddle",
				"PaddleHitWall",
				"AddScore",
				"LoseLive",
				"Win",

				"Interrupt",
			};

			BallStrength = 5;

			ExplosiveRadius = 40;
		}
	}
}

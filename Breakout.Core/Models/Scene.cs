using Breakout.Models.Balls;
using Breakout.Models.Bases;
using Breakout.Models.Blocks;
using Breakout.Models.Enums;
using Breakout.Models.Meta;
using Breakout.Models.Paddles;
using Breakout.Utilities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Models
{
	public static class Scene
	{
		public static bool IsPlaying { get; set; }

		public static Button StartButton;
		public static Button CreditButton;
		public static Button ExitButton;

		public static Paddle Paddle { get; set; }
		public static List<Ball> Balls { get; set; }
		public static List<Block> Blocks { get; set; }

		public static void Initialize()
		{
			InitializeMenu();
			InitializeGame();
		}

		public static void InitializeMenu()
		{
			StartButton = new Button(xRatio: 0.5f, yRatio: 0.4f);
			CreditButton = new Button(xRatio: 0.5f, yRatio: 0.5f);
			ExitButton = new Button(xRatio: 0.5f, yRatio: 0.6f);
		}

		public static void InitializeGame()
		{
			Paddle = new Paddle(width: 100, height: 17);
			Balls = new List<Ball>()
			{
				new Ball(radius: 8, strength: 5, velocity: 6f),
			};

			InitializeBlocks();
		}

		public static void InitializeBlocks()
		{
			int blockWidth = 30;
			int blockHeight = 30;
			Blocks = new List<Block>();

			// TODO: design level
			for (int w = 0; w * blockWidth < GameInfo.Screen.Width; w++)
			{
				for (int h = 0; h * blockHeight < GameInfo.Screen.Height / 2; h++)
				{
					int x = blockWidth * w;
					int y = blockHeight* h;
					BlockType blockType = RandomMath.RandomEnum<BlockType>();

					Block newBlock = new Block(blockType, width: 30, height: 30, position: new Vector2(x, y));

					Blocks.Add(newBlock);
				}
			}
		}
	}
}

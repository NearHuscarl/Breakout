using Breakout.Models.Balls;
using Breakout.Models.Blocks;
using Breakout.Models.Buttons;
using Breakout.Models.Enums;
using Breakout.Models.Maps;
using Breakout.Models.Meta;
using Breakout.Models.Paddles;
using Breakout.Models.Players;
using Breakout.Models.PowerUps;
using Breakout.Models.Texts;
using Breakout.Utilities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Models
{
	public static class ModelFactory
	{
		public static Button CreateStartButton()
		{
			return new Button(xRatio: 0.5f, yRatio: 0.4f);
		}

		public static Button CreateCreditButton()
		{
			return new Button(xRatio: 0.5f, yRatio: 0.5f);
		}

		public static Button CreateExitButton()
		{
			return new Button(xRatio: 0.5f, yRatio: 0.6f);
		}

		public static Paddle CreatePaddle()
		{
			return new Paddle(width: 100, height: 17);
		}

		public static List<Ball> CreateBall()
		{
			Ball ball = new Ball(radius: 8, strength: 5, velocity: 6f);
			ball.ResetPosition();

			return new List<Ball>()
			{
				ball,
			};
		}

		public static Player CreatePlayer()
		{
			Player player = new Player()
			{
				Score = new ScoreManager(),
				Live = new Text(text: 3, prompt: GameInfo.LiveText),
				CurrentCombo = new Text(text: 0, prompt: GameInfo.CurrentComboText),
				HighestCombo = new Text(text: 0, prompt: GameInfo.HighestComboText),
			};

			player.Score.Position = new Vector2()
			{
				X = (GameInfo.Footer.Width / 2 - GameInfo.Font.GetLength(player.Score.FullText) / 2),
				Y = GameInfo.Footer.Y,
			};

			player.Live.Position = new Vector2()
			{
				X = 5,
				Y = GameInfo.Footer.Y,
			};

			player.CurrentCombo.Position = new Vector2()
			{
				X = GameInfo.Font.GetLength(player.Live.FullText),
				Y = GameInfo.Footer.Y,
			};

			player.HighestCombo.Position = new Vector2()
			{
				X = GameInfo.Font.GetLength(player.Live.FullText) + GameInfo.Font.GetLength(player.CurrentCombo.FullText),
				Y = GameInfo.Footer.Y,
			};

			return player;
		}

		public static Text CreateBlockLeftText(int numOfBlocks)
		{
			Text blockLeftText = new Text(text: numOfBlocks, prompt: GameInfo.BlockLeftText);

			blockLeftText.Position = new Vector2()
			{
				X = GameInfo.Screen.Width - GameInfo.Font.GetLength(blockLeftText.FullText),
				Y = GameInfo.Footer.Y,
			};

			return blockLeftText;
		}

		public static PowerUpPackage CreatePowerUpPackage(PowerUp powerUp, Vector2 position)
		{
			return new PowerUpPackage(powerUp, width: 20, height: 20, position: position);
		}

		public static List<Block> CreateBlocks()
		{
			MapManager.LoadMap("mario");

			int blockWidth = 20;
			int blockHeight = 20;

			int mapWidth = MapManager.CurrentMap.Matrix[0].Count * blockWidth;
			int mapHeight = MapManager.CurrentMap.Matrix.Count * blockHeight;

			Vector2 mapEntryPosition = new Vector2()
			{
				X = GameInfo.Screen.Width / 2 - mapWidth / 2,
				Y = blockWidth * 1,
			};

			List<Block> blocks = new List<Block>();

			for (int r = 1; mapEntryPosition.Y + r * blockHeight <= mapEntryPosition.Y + mapHeight; r++)
			{
				for (int c = 1; mapEntryPosition.X + c * blockWidth <= mapEntryPosition.X + mapWidth; c++)
				{
					BlockType blockType = MapManager.BlockMap[MapManager.CurrentMap.Matrix[r-1][c-1]];

					if (blockType == BlockType.None)
						continue;

					float x = mapEntryPosition.X + c * blockWidth - c; // Make border of blocks overlap each other
					float y = mapEntryPosition.Y + r * blockHeight - r;

					Block newBlock = new Block(blockType,
						width: blockWidth,
						height: blockHeight,
						position: new Vector2(x, y));

					blocks.Add(newBlock);
				}
			}

			return blocks;
		}
	}
}

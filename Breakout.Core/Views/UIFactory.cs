using Breakout.Models.Enums;
using Breakout.Views.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Views
{
	public static class UIFactory
	{
		public static Background CreateBackground(ContentManager content)
		{
			Texture2D backgroundTexture = content.Load<Texture2D>("Background");
			Background background = new Background(backgroundTexture);

			return background;
		}

		public static ButtonUI CreateStartButton(ContentManager content)
		{
			Texture2D startTexture = content.Load<Texture2D>("Start");
			Texture2D startHoverTexture = content.Load<Texture2D>("StartHover");
			Texture2D startClickedTexture = content.Load<Texture2D>("StartClicked");

			ButtonUI button = new ButtonUI(startTexture, startHoverTexture, startClickedTexture);
			return button;
		}

		public static ButtonUI CreateCreditButton(ContentManager content)
		{
			Texture2D optionTexture = content.Load<Texture2D>("Credit");
			Texture2D optionHoverTexture = content.Load<Texture2D>("CreditHover");
			Texture2D optionClickedTexture = content.Load<Texture2D>("CreditClicked");

			ButtonUI button = new ButtonUI(optionTexture, optionHoverTexture, optionClickedTexture);
			return button;
		}

		public static ButtonUI CreateExitButton(ContentManager content)
		{
			Texture2D exitTexture = content.Load<Texture2D>("Exit");
			Texture2D exitHoverTexture = content.Load<Texture2D>("ExitHover");
			Texture2D exitClickedTexture = content.Load<Texture2D>("ExitClicked");

			ButtonUI button = new ButtonUI(exitTexture, exitHoverTexture, exitClickedTexture);
			return button;
		}

		public static Sprite CreatePaddle(ContentManager content)
		{
			Texture2D paddleTexture = content.Load<Texture2D>("Paddle");
			Sprite paddle = new Sprite(paddleTexture);

			return paddle;
		}

		public static Sprite CreateBall(ContentManager content)
		{
			Texture2D ballTexture = content.Load<Texture2D>("Ball");
			Sprite ball = new Sprite(ballTexture);

			return ball;
		}

		public static Sprite CreateBlock(ContentManager content, int number=1)
		{
			Texture2D blockTexture = content.Load<Texture2D>("Block" + number.ToString());

			Sprite block = new Sprite(blockTexture);
			return block;
		}

		public static Dictionary<BlockType, Sprite> CreateBlocks(ContentManager content)
		{
			Dictionary<BlockType, Sprite> blocks = new Dictionary<BlockType, Sprite>();

			foreach (BlockType blockType in Enum.GetValues(typeof(BlockType)))
			{
				int blockNumber = ((int)blockType);
				Texture2D blockSprite = content.Load<Texture2D>("Block" + blockNumber.ToString());
				Sprite block = new Sprite(blockSprite);

				blocks.Add(blockType, block);
			}

			return blocks;
		}

		public static Font CreateScoreFont(SpriteFont font)
		{
			string initialScore = "0";
			Vector2 position = new Vector2(10, 10); // TODO: use screenWidth and screenHeight

			Font scoreFont = new Font(font, initialScore, position, Color.Red);
			return scoreFont;
		}

		public static Font CreateLiveFont(SpriteFont font)
		{
			string initialLives = "3";
			Vector2 position = new Vector2(10, 30); // TODO: use screenWidth and screenHeight

			Font scoreFont = new Font(font, initialLives, position, Color.Green);
			return scoreFont;
		}

		public static Font CreateComboFont(SpriteFont font)
		{
			string initialCombo = "0";
			Vector2 position = new Vector2(10, 50); // TODO: use screenWidth and screenHeight

			Font scoreFont = new Font(font, initialCombo, position, Color.Red);
			return scoreFont;
		}

		public static Font CreateMaxComboFont(SpriteFont font)
		{
			string initialMaxCombo = "0";
			Vector2 position = new Vector2(10, 70); // TODO: use screenWidth and screenHeight

			Font scoreFont = new Font(font, initialMaxCombo, position, Color.Red);
			return scoreFont;
		}

		public static Font CreateBlockLeftFont(SpriteFont font)
		{
			string initialBlocks = "0";
			Vector2 position = new Vector2(10, 90); // TODO: use screenWidth and screenHeight

			Font scoreFont = new Font(font, initialBlocks, position, Color.Red);
			return scoreFont;
		}
	}
}

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
	public class UIFactory
	{
		private int screenWidth;
		private int screenHeight;

		public UIFactory(int screenWidth, int screenHeight)
		{
			this.screenWidth = screenWidth;
			this.screenHeight = screenHeight;
		}

		public Background CreateBackground(ContentManager content)
		{
			Texture2D backgroundTexture = content.Load<Texture2D>("Background");
			Background background = new Background(backgroundTexture);

			return background;
		}

		/// <summary>
		/// return x position to have the texture vertical aligned
		///     x
		/// |   |       |
		/// |   | | |   |
		/// |           |
		/// </summary>
		private float GetSymmetricXPos(Texture2D texture)
		{
			return screenWidth / 2 - texture.Width / 2;
		}

		public Button CreateStartGameButton(ContentManager content)
		{
			Texture2D startTexture = content.Load<Texture2D>("Start");
			Texture2D startHoverTexture = content.Load<Texture2D>("StartHover");
			Texture2D startClickedTexture = content.Load<Texture2D>("StartClicked");
			Vector2 position = new Vector2(GetSymmetricXPos(startTexture), 240);

			Sprite buttonSprite = new Sprite(startTexture, position);

			Button startGameButton = new Button(buttonSprite,
					startHoverTexture,
					startClickedTexture,
					startTexture);

			return startGameButton;
		}

		public Button CreateOptionButton(ContentManager content)
		{
			Texture2D optionTexture = content.Load<Texture2D>("Option");
			Texture2D optionHoverTexture = content.Load<Texture2D>("OptionHover");
			Texture2D optionClickedTexture = content.Load<Texture2D>("OptionClicked");
			Vector2 position = new Vector2(GetSymmetricXPos(optionTexture), 300);

			Sprite buttonSprite = new Sprite(optionTexture, position);

			Button optionButton = new Button(buttonSprite,
					optionHoverTexture,
					optionClickedTexture,
					optionTexture);

			return optionButton;
		}

		public Button CreateExitButton(ContentManager content)
		{
			Texture2D exitTexture = content.Load<Texture2D>("Exit");
			Texture2D exitHoverTexture = content.Load<Texture2D>("ExitHover");
			Texture2D exitClickedTexture = content.Load<Texture2D>("ExitClicked");
			Vector2 position = new Vector2(GetSymmetricXPos(exitTexture), 360);

			Sprite buttonSprite = new Sprite(exitTexture, position);

			Button exitButton = new Button(buttonSprite,
					exitHoverTexture,
					exitClickedTexture,
					exitTexture);

			return exitButton;
		}

		public Paddle CreatePaddle(ContentManager content)
		{
			Texture2D paddleTexture = content.Load<Texture2D>("Paddle");
			Vector2 position = new Vector2(
					GetSymmetricXPos(paddleTexture),
					screenHeight - paddleTexture.Height - 10);

			Sprite paddleSprite = new Sprite(paddleTexture, position);
			Paddle paddle = new Paddle(paddleSprite);

			return paddle;
		}

		public Ball CreateBall(ContentManager content, Paddle paddle)
		{
			Texture2D ballTexture = content.Load<Texture2D>("Ball");

			Vector2 position = new Vector2(
					paddle.Sprite.Position.X + paddle.Sprite.Rectangle.Width / 2 - ballTexture.Width / 2,
					paddle.Sprite.Position.Y - ballTexture.Height);

			Sprite ballSprite = new Sprite(ballTexture, position);
			Ball ball = new Ball(ballSprite);

			return ball;
		}

		public List<Block> CreateBlocks(ContentManager content)
		{
			const int NUM_OF_BLOCK_TYPES = 7;

			Texture2D[] blockTextures = new Texture2D[NUM_OF_BLOCK_TYPES];
			for (int i = 0; i < NUM_OF_BLOCK_TYPES; i++)
			{
				blockTextures[i] = content.Load<Texture2D>("Block" + (i+1).ToString());
			}

			Random random = new Random();

			var blockWidth = blockTextures[0].Width;
			var blockHeight = blockTextures[0].Height;

			List<Block> blocks = new List<Block>();
			for (int w = 0; w * blockWidth < screenWidth; w++)
			{
				for (int h = 0; h * blockHeight < screenHeight / 2; h++)
				{
					Texture2D texture = blockTextures[random.Next(0, NUM_OF_BLOCK_TYPES)];
					Vector2 position = new Vector2(texture.Width * w, texture.Height * h);
					Sprite blockSprite = new Sprite(texture, position);

					Block newBlock = new Block(blockSprite);
					blocks.Add(newBlock);
				}
			}

			return blocks;
		}

		public Font CreateScoreFont(SpriteFont font)
		{
			string initialScore = "0";
			Vector2 position = new Vector2(10, 10); // TODO: use screenWidth and screenHeight

			Font scoreFont = new Font(font, initialScore, position, Color.Red);
			return scoreFont;
		}

		public Font CreateLiveFont(SpriteFont font)
		{
			string initialLives = "3";
			Vector2 position = new Vector2(10, 30); // TODO: use screenWidth and screenHeight

			Font scoreFont = new Font(font, initialLives, position, Color.Green);
			return scoreFont;
		}

		public Font CreateComboFont(SpriteFont font)
		{
			string initialCombo = "0";
			Vector2 position = new Vector2(10, 50); // TODO: use screenWidth and screenHeight

			Font scoreFont = new Font(font, initialCombo, position, Color.Red);
			return scoreFont;
		}

		public Font CreateMaxComboFont(SpriteFont font)
		{
			string initialMaxCombo = "0";
			Vector2 position = new Vector2(10, 70); // TODO: use screenWidth and screenHeight

			Font scoreFont = new Font(font, initialMaxCombo, position, Color.Red);
			return scoreFont;
		}

		public Font CreateBlockLeftFont(SpriteFont font)
		{
			string initialBlocks = "0";
			Vector2 position = new Vector2(10, 90); // TODO: use screenWidth and screenHeight

			Font scoreFont = new Font(font, initialBlocks, position, Color.Red);
			return scoreFont;
		}
	}
}

using Breakout.Extensions;
using Breakout.Models.Enums;
using Breakout.Models.Meta;
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
			Texture2D startTexture = content.Load<Texture2D>("Buttons/Start");
			Texture2D startHoverTexture = content.Load<Texture2D>("Buttons/StartHover");
			Texture2D startClickedTexture = content.Load<Texture2D>("Buttons/StartClicked");

			ButtonUI button = new ButtonUI(startTexture, startHoverTexture, startClickedTexture);
			return button;
		}

		public static ButtonUI CreateCreditButton(ContentManager content)
		{
			Texture2D creditTexture = content.Load<Texture2D>("Buttons/Credit");
			Texture2D creditHoverTexture = content.Load<Texture2D>("Buttons/CreditHover");
			Texture2D creditClickedTexture = content.Load<Texture2D>("Buttons/CreditClicked");

			ButtonUI button = new ButtonUI(creditTexture, creditHoverTexture, creditClickedTexture);
			return button;
		}

		public static ButtonUI CreateExitButton(ContentManager content)
		{
			Texture2D exitTexture = content.Load<Texture2D>("Buttons/Exit");
			Texture2D exitHoverTexture = content.Load<Texture2D>("Buttons/ExitHover");
			Texture2D exitClickedTexture = content.Load<Texture2D>("Buttons/ExitClicked");

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

		public static Dictionary<BlockType, BlockUI> CreateBlocks(ContentManager content)
		{
			Texture2D[] magentaBlockTextures = new Texture2D[1];
			Texture2D[] cyanBlockTextures = new Texture2D[2];
			Texture2D[] blueBlockTextures = new Texture2D[3];
			Texture2D[] yellowBlockTextures = new Texture2D[4];
			Texture2D[] orangeBlockTextures = new Texture2D[5];
			Texture2D[] redBlockTextures = new Texture2D[1];

			magentaBlockTextures[0] = content.Load<Texture2D>("Blocks/Magenta1");

			cyanBlockTextures[0] = content.Load<Texture2D>("Blocks/Cyan1");
			cyanBlockTextures[1] = content.Load<Texture2D>("Blocks/Cyan2");

			blueBlockTextures[0] = content.Load<Texture2D>("Blocks/Blue1");
			blueBlockTextures[1] = content.Load<Texture2D>("Blocks/Blue2");
			blueBlockTextures[2] = content.Load<Texture2D>("Blocks/Blue3");

			yellowBlockTextures[0] = content.Load<Texture2D>("Blocks/Yellow1");
			yellowBlockTextures[1] = content.Load<Texture2D>("Blocks/Yellow2");
			yellowBlockTextures[2] = content.Load<Texture2D>("Blocks/Yellow3");
			yellowBlockTextures[3] = content.Load<Texture2D>("Blocks/Yellow4");

			orangeBlockTextures[0] = content.Load<Texture2D>("Blocks/Orange1");
			orangeBlockTextures[1] = content.Load<Texture2D>("Blocks/Orange2");
			orangeBlockTextures[2] = content.Load<Texture2D>("Blocks/Orange3");
			orangeBlockTextures[3] = content.Load<Texture2D>("Blocks/Orange4");
			orangeBlockTextures[4] = content.Load<Texture2D>("Blocks/Orange5");

			redBlockTextures[0] = content.Load<Texture2D>("Blocks/Red");

			BlockUI magentaBlock = new BlockUI(magentaBlockTextures);
			BlockUI cyanBlock = new BlockUI(cyanBlockTextures);
			BlockUI blueBlock = new BlockUI(blueBlockTextures);
			BlockUI yellowBlock = new BlockUI(yellowBlockTextures);
			BlockUI orangeBlock = new BlockUI(orangeBlockTextures);
			BlockUI redBlock = new BlockUI(redBlockTextures);

			Dictionary<BlockType, BlockUI> blocks = new Dictionary<BlockType, BlockUI>()
			{
				{ BlockType.Magenta, magentaBlock },
				{ BlockType.Cyan, cyanBlock },
				{ BlockType.Blue, blueBlock },
				{ BlockType.Yellow, yellowBlock },
				{ BlockType.Orange, orangeBlock },
				{ BlockType.Red, redBlock },
			};

			return blocks;
		}

		public static FlashingBlockUI CreateFlashingBlock(ContentManager content, string color1, string color2)
		{
			Texture2D blockTexture = content.Load<Texture2D>("Blocks/Green");

			FlashingBlockUI block = new FlashingBlockUI(blockTexture,
				color1.ToColor(),
				color2.ToColor());

			return block;
		}

		public static Font CreateRedFont(SpriteFont font)
		{
			return new Font(font, GameInfo.Theme["LightRed"]);
		}

		public static Font CreateGreenFont(SpriteFont font)
		{
			return new Font(font, GameInfo.Theme["LightGreen"]);
		}

		public static Font CreateYellowFont(SpriteFont font)
		{
			return new Font(font, GameInfo.Theme["Yellow"]);
		}
	}
}

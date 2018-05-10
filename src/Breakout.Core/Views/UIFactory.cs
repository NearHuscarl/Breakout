using Breakout.Extensions;
using Breakout.Models;
using Breakout.Models.Enums;
using Breakout.Models.Meta;
using Breakout.Views.Enums;
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
		public static Dictionary<Stage, Background> CreateBackground(ContentManager content)
		{
			Texture2D menuBgTexture = content.Load<Texture2D>("Backgrounds/MenuBackground");
			Texture2D level1BgTexture = content.Load<Texture2D>("Backgrounds/Level1_Background");

			Background menuBackground = new Background(menuBgTexture);
			Background lvl1Background = new Background(level1BgTexture);

			return new Dictionary<Stage, Background>()
			{
				{ Stage.Menu, menuBackground },
				{ Stage.Level1, lvl1Background },
			};
		}

		public static Sprite CreateFooter(ContentManager content)
		{
			Texture2D footerTexture = content.Load<Texture2D>("Backgrounds/Footer");
			Sprite footer = new Sprite(footerTexture);

			return footer;
		}

		private static ButtonUI CreateButton(ContentManager content, SpriteFont font)
		{
			Texture2D startTexture = content.Load<Texture2D>("Buttons/Button");
			Texture2D startHoverTexture = content.Load<Texture2D>("Buttons/ButtonHover");
			Texture2D startClickedTexture = content.Load<Texture2D>("Buttons/ButtonClicked");

			Color fgColor = GameInfo.Theme["White"];

			return new ButtonUI(font, startTexture, startHoverTexture, startClickedTexture, fgColor);
		}

		public static ButtonUI CreateStartButton(ContentManager content, SpriteFont font)
		{
			ButtonUI button = CreateButton(content, font);

			Scene.StartButton.ButtonHovered += button.OnButtonHovered;
			Scene.StartButton.ButtonHoldClicked += button.OnButtonHoldClicked;
			Scene.StartButton.ButtonInactive += button.OnButtonInactive;

			return button;
		}

		public static ButtonUI CreateCreditButton(ContentManager content, SpriteFont font)
		{
			ButtonUI button = CreateButton(content, font);

			Scene.CreditButton.ButtonHovered += button.OnButtonHovered;
			Scene.CreditButton.ButtonHoldClicked += button.OnButtonHoldClicked;
			Scene.CreditButton.ButtonInactive += button.OnButtonInactive;

			return button;
		}

		public static ButtonUI CreateExitButton(ContentManager content, SpriteFont font)
		{
			ButtonUI button = CreateButton(content, font);

			Scene.ExitButton.ButtonHovered += button.OnButtonHovered;
			Scene.ExitButton.ButtonHoldClicked += button.OnButtonHoldClicked;
			Scene.ExitButton.ButtonInactive += button.OnButtonInactive;

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
			Texture2D redBlockTexture = content.Load<Texture2D>("Blocks/Red");
			Texture2D orangeBlockTexture = content.Load<Texture2D>("Blocks/Orange");
			Texture2D yellowBlockTexture = content.Load<Texture2D>("Blocks/Yellow");
			Texture2D greenTexture = content.Load<Texture2D>("Blocks/Green");
			Texture2D blueBlockTexture = content.Load<Texture2D>("Blocks/Blue");
			Texture2D cyanBlockTexture = content.Load<Texture2D>("Blocks/Cyan");
			Texture2D magentaBlockTexture = content.Load<Texture2D>("Blocks/Magenta");
			Texture2D grayBlockTexture = content.Load<Texture2D>("Blocks/Gray");
			Texture2D blackBlockTexture = content.Load<Texture2D>("Blocks/Black");

			BlockUI redBlock = new BlockUI(redBlockTexture, GameInfo.Theme["LightRed"], GameInfo.Theme["Red"]);
			BlockUI orangeBlock = new BlockUI(orangeBlockTexture, GameInfo.Theme["LightOrange"], GameInfo.Theme["Orange"]);
			BlockUI yellowBlock = new BlockUI(yellowBlockTexture, GameInfo.Theme["LightYellow"], GameInfo.Theme["Yellow"]);
			BlockUI greenBlock = new BlockUI(yellowBlockTexture, GameInfo.Theme["LightGreen"], GameInfo.Theme["Green"]);
			BlockUI blueBlock = new BlockUI(blueBlockTexture, GameInfo.Theme["LightBlue"], GameInfo.Theme["Blue"]);
			BlockUI cyanBlock = new BlockUI(cyanBlockTexture, GameInfo.Theme["LightCyan"], GameInfo.Theme["Cyan"]);
			BlockUI magentaBlock = new BlockUI(magentaBlockTexture, GameInfo.Theme["LightMagenta"], GameInfo.Theme["Magenta"]);
			BlockUI grayBlock = new BlockUI(grayBlockTexture, GameInfo.Theme["LightGray"], GameInfo.Theme["Gray"]);
			BlockUI blackBlock = new BlockUI(blackBlockTexture, GameInfo.Theme["Dark"], GameInfo.Theme["Black"]);

			return new Dictionary<BlockType, BlockUI>()
			{
				{ BlockType.Red, redBlock },
				{ BlockType.Orange, orangeBlock },
				{ BlockType.Yellow, yellowBlock },
				{ BlockType.Green, greenBlock },
				{ BlockType.Blue, blueBlock },
				{ BlockType.Cyan, cyanBlock },
				{ BlockType.Magenta, magentaBlock },
				{ BlockType.Gray, grayBlock },
				{ BlockType.Black, blackBlock },

				{ BlockType.LightRed, redBlock },
				{ BlockType.LightOrange, orangeBlock },
				{ BlockType.LightYellow, yellowBlock },
				{ BlockType.LightGreen, greenBlock },
				{ BlockType.LightBlue, blueBlock },
				{ BlockType.LightCyan, cyanBlock },
				{ BlockType.LightMagenta, magentaBlock },
				{ BlockType.LightGray, grayBlock },
				{ BlockType.Dark, blackBlock },
			};
		}

		public static Dictionary<BlockType, FlashingBlockUI> CreateFlashingBlocks(ContentManager content)
		{
			Texture2D redBlockTexture = content.Load<Texture2D>("Blocks/Red");
			Texture2D orangeBlockTexture = content.Load<Texture2D>("Blocks/Orange");
			Texture2D yellowBlockTexture = content.Load<Texture2D>("Blocks/Yellow");
			Texture2D greenTexture = content.Load<Texture2D>("Blocks/Green");
			Texture2D blueBlockTexture = content.Load<Texture2D>("Blocks/Blue");
			Texture2D cyanBlockTexture = content.Load<Texture2D>("Blocks/Cyan");
			Texture2D magentaBlockTexture = content.Load<Texture2D>("Blocks/Magenta");
			Texture2D grayBlockTexture = content.Load<Texture2D>("Blocks/Gray");
			Texture2D blackBlockTexture = content.Load<Texture2D>("Blocks/Black");

			FlashingBlockUI redBlock = new FlashingBlockUI(redBlockTexture, GameInfo.Theme["LightRed"], GameInfo.Theme["Red"]);
			FlashingBlockUI orangeBlock = new FlashingBlockUI(orangeBlockTexture, GameInfo.Theme["LightOrange"], GameInfo.Theme["Orange"]);
			FlashingBlockUI yellowBlock = new FlashingBlockUI(yellowBlockTexture, GameInfo.Theme["LightYellow"], GameInfo.Theme["Yellow"]);
			FlashingBlockUI greenBlock = new FlashingBlockUI(yellowBlockTexture, GameInfo.Theme["LightGreen"], GameInfo.Theme["Green"]);
			FlashingBlockUI blueBlock = new FlashingBlockUI(blueBlockTexture, GameInfo.Theme["LightBlue"], GameInfo.Theme["Blue"]);
			FlashingBlockUI cyanBlock = new FlashingBlockUI(cyanBlockTexture, GameInfo.Theme["LightCyan"], GameInfo.Theme["Cyan"]);
			FlashingBlockUI magentaBlock = new FlashingBlockUI(magentaBlockTexture, GameInfo.Theme["LightMagenta"], GameInfo.Theme["Magenta"]);
			FlashingBlockUI grayBlock = new FlashingBlockUI(grayBlockTexture, GameInfo.Theme["LightGray"], GameInfo.Theme["Gray"]);
			FlashingBlockUI blackBlock = new FlashingBlockUI(blackBlockTexture, GameInfo.Theme["Dark"], GameInfo.Theme["Black"]);

			return new Dictionary<BlockType, FlashingBlockUI>()
			{
				{ BlockType.FlashingRed, redBlock },
				{ BlockType.FlashingOrange, orangeBlock },
				{ BlockType.FlashingYellow, yellowBlock },
				{ BlockType.FlashingGreen, greenBlock },
				{ BlockType.FlashingBlue, blueBlock },
				{ BlockType.FlashingCyan, cyanBlock },
				{ BlockType.FlashingMagenta, magentaBlock },
				{ BlockType.FlashingGray, grayBlock },
				{ BlockType.FlashingBlack, blackBlock },

			};
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

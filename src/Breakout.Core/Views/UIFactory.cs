using Breakout.Extensions;
using Breakout.Models;
using Breakout.Models.Enums;
using Breakout.Models.UIComponents;
using Breakout.Views.Enums;
using Breakout.Views.UI;
using Breakout.Views.UI.Blocks;
using Breakout.Views.UI.Buttons;
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
		public static Cursor CreateCursor(ContentManager content)
		{
			Texture2D cursorTexture = content.Load<Texture2D>("Cursor");
			Cursor cursor = new Cursor(cursorTexture);

			return cursor;
		}

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

		public static ScreenUI CreateScreen(ContentManager content, SpriteFont font)
		{
			Texture2D screenTexture = content.Load<Texture2D>("Windows/Screen");
			ScreenUI messageBox = new ScreenUI(screenTexture, font, GameInfo.Theme["White"]);

			return messageBox;
		}

		public static MessageBoxUI CreateMessageBox(ContentManager content, SpriteFont font)
		{
			Texture2D screenTexture = content.Load<Texture2D>("Windows/MessageBox");
			MessageBoxUI messageBox = new MessageBoxUI(screenTexture, font, GameInfo.Theme["White"]);

			return messageBox;
		}

		public static Sprite CreateFooter(ContentManager content)
		{
			Texture2D footerTexture = content.Load<Texture2D>("Backgrounds/Footer");
			Sprite footer = new Sprite(footerTexture);

			return footer;
		}

		public static ButtonUI CreateButton(ContentManager content, SpriteFont font)
		{
			Texture2D buttonTexture = content.Load<Texture2D>("Buttons/Button");
			Texture2D buttonHoveredTexture = content.Load<Texture2D>("Buttons/ButtonHover");
			Texture2D buttonClickedTexture = content.Load<Texture2D>("Buttons/ButtonClicked");

			Color fgColor = GameInfo.Theme["White"];

			return new ButtonUI(buttonTexture, buttonHoveredTexture, buttonClickedTexture, font, fgColor);
		}

		public static CheckBoxUI CreateCheckBox(ContentManager content, SpriteFont font)
		{
			Texture2D checkedTexture = content.Load<Texture2D>("Buttons/CheckBoxChecked");
			Texture2D uncheckedTexture = content.Load<Texture2D>("Buttons/CheckBoxUnchecked");

			Color fgColor = GameInfo.Theme["White"];

			return new CheckBoxUI(checkedTexture, uncheckedTexture, font, fgColor);
		}

		public static CheckBoxUI CreateRadioButton(ContentManager content, SpriteFont font)
		{
			Texture2D checkedTexture = content.Load<Texture2D>("Buttons/RadioButtonChecked");
			Texture2D uncheckedTexture = content.Load<Texture2D>("Buttons/RadioButtonUnchecked");

			Color fgColor = GameInfo.Theme["White"];

			return new CheckBoxUI(checkedTexture, uncheckedTexture, font, fgColor);
		}

		public static PaddleUI CreatePaddle(ContentManager content)
		{
			Texture2D longPaddleTexture = content.Load<Texture2D>("Paddles/LongPaddle");
			Texture2D mediumPaddleTexture = content.Load<Texture2D>("Paddles/MediumPaddle");
			Texture2D shortPaddleTexture = content.Load<Texture2D>("Paddles/ShortPaddle");
			Texture2D extraShortPaddleTexture = content.Load<Texture2D>("Paddles/ExtraShortPaddle");

			return new PaddleUI(extraShortPaddleTexture, shortPaddleTexture, mediumPaddleTexture, longPaddleTexture);
		}

		public static Sprite CreateBall(ContentManager content)
		{
			Texture2D ballTexture = content.Load<Texture2D>("Ball");
			Sprite ball = new Sprite(ballTexture);

			return ball;
		}

		public static Dictionary<GameColor, BlockUI> CreateBlocks(ContentManager content)
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

			return new Dictionary<GameColor, BlockUI>()
			{
				{ GameColor.Red, redBlock },
				{ GameColor.Orange, orangeBlock },
				{ GameColor.Yellow, yellowBlock },
				{ GameColor.Green, greenBlock },
				{ GameColor.Blue, blueBlock },
				{ GameColor.Cyan, cyanBlock },
				{ GameColor.Magenta, magentaBlock },
				{ GameColor.Gray, grayBlock },
				{ GameColor.Black, blackBlock },
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

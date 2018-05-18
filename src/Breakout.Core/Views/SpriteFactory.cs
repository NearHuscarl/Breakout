using Breakout.Models;
using Breakout.Models.Enums;
using Breakout.Views.Enums;
using Breakout.Views.Sprites;
using Breakout.Views.Sprites.Blocks;
using Breakout.Views.UIComponents;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Breakout.Views
{
	public static class SpriteFactory
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

		public static GameSprite CreateFooter(ContentManager content)
		{
			Texture2D footerTexture = content.Load<Texture2D>("Backgrounds/Footer");
			GameSprite footer = new GameSprite(footerTexture);

			return footer;
		}

		public static PaddleUI CreatePaddle(ContentManager content)
		{
			Texture2D extraLongPaddleTexture = content.Load<Texture2D>("Paddles/ExtraLongPaddle");
			Texture2D longPaddleTexture = content.Load<Texture2D>("Paddles/LongPaddle");
			Texture2D mediumPaddleTexture = content.Load<Texture2D>("Paddles/MediumPaddle");
			Texture2D shortPaddleTexture = content.Load<Texture2D>("Paddles/ShortPaddle");
			Texture2D extraShortPaddleTexture = content.Load<Texture2D>("Paddles/ExtraShortPaddle");

			return new PaddleUI(extraShortPaddleTexture, shortPaddleTexture, mediumPaddleTexture, longPaddleTexture, extraLongPaddleTexture);
		}

		public static GameSprite CreateBall(ContentManager content)
		{
			Texture2D ballTexture = content.Load<Texture2D>("Ball");
			GameSprite ball = new GameSprite(ballTexture);

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

		public static GameSprite CreateSkeletonBlock(ContentManager content)
		{
			Texture2D skeletonBlockTexture = content.Load<Texture2D>("Blocks/Skeleton");
			GameSprite skeletonBlock = new GameSprite(skeletonBlockTexture);

			return skeletonBlock;
		}
	}
}

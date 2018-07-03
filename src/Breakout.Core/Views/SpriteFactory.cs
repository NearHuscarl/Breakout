using Breakout.Core.Models;
using Breakout.Core.Models.Enums;
using Breakout.Core.Utilities.Map;
using Breakout.Core.Views.Loaders;
using Breakout.Core.Views.Sprites;
using Breakout.Core.Views.Sprites.Blocks;
using Breakout.Core.Views.UIComponents;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Breakout.Core.Views
{
	public static class SpriteFactory
	{
		public static Background CreateBackground(ContentManager content, Scene scene)
		{
			Dictionary<string, Texture2D> backgroundImages = new Dictionary<string, Texture2D>();

			foreach (var bgName in MapManager.Stages.Values)
			{
				try
				{
					backgroundImages.Add(bgName, BackgroundLoader.Load(bgName));
				}
				catch (ContentLoadException)
				{
					backgroundImages.Add(bgName, BackgroundLoader.Load("Default"));
				}
			}

			return new Background(scene, backgroundImages);
		}

		public static Cursor CreateCursor(ContentManager content)
		{
			Texture2D cursorTexture = content.Load<Texture2D>("Cursor");
			Cursor cursor = new Cursor(cursorTexture);

			return cursor;
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

		public static Dictionary<PowerUpType, GameSprite> CreatePowerups(ContentManager content)
		{
			Texture2D doubleTexture = content.Load<Texture2D>("Powerups/Double");
			Texture2D tripleTexture = content.Load<Texture2D>("Powerups/Triple");
			Texture2D biggerTexture = content.Load<Texture2D>("Powerups/Bigger");
			Texture2D smallerTexture = content.Load<Texture2D>("Powerups/Smaller");
			Texture2D strongerTexture = content.Load<Texture2D>("Powerups/Stronger");
			Texture2D weakerTexture = content.Load<Texture2D>("Powerups/Weaker");
			Texture2D fasterTexture = content.Load<Texture2D>("Powerups/Faster");
			Texture2D slowerTexture = content.Load<Texture2D>("Powerups/Slower");
			Texture2D longerTexture = content.Load<Texture2D>("Powerups/Longer");
			Texture2D shorterTexture = content.Load<Texture2D>("Powerups/Shorter");

			return new Dictionary<PowerUpType, GameSprite>()
			{
				{ PowerUpType.Double, new GameSprite(doubleTexture) },
				{ PowerUpType.Triple, new GameSprite(tripleTexture) },
				{ PowerUpType.Bigger, new GameSprite(biggerTexture) },
				{ PowerUpType.Smaller, new GameSprite(smallerTexture) },
				{ PowerUpType.Stronger, new GameSprite(strongerTexture) },
				{ PowerUpType.Weaker, new GameSprite(weakerTexture) },
				{ PowerUpType.Faster, new GameSprite(fasterTexture) },
				{ PowerUpType.Slower, new GameSprite(slowerTexture) },
				{ PowerUpType.Longer, new GameSprite(longerTexture) },
				{ PowerUpType.Shorter, new GameSprite(shorterTexture) },
			};
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

			BlockUI redBlock = new BlockUI(redBlockTexture, GlobalData.Theme["LightRed"], GlobalData.Theme["Red"]);
			BlockUI orangeBlock = new BlockUI(orangeBlockTexture, GlobalData.Theme["LightOrange"], GlobalData.Theme["Orange"]);
			BlockUI yellowBlock = new BlockUI(yellowBlockTexture, GlobalData.Theme["LightYellow"], GlobalData.Theme["Yellow"]);
			BlockUI greenBlock = new BlockUI(yellowBlockTexture, GlobalData.Theme["LightGreen"], GlobalData.Theme["Green"]);
			BlockUI blueBlock = new BlockUI(blueBlockTexture, GlobalData.Theme["LightBlue"], GlobalData.Theme["Blue"]);
			BlockUI cyanBlock = new BlockUI(cyanBlockTexture, GlobalData.Theme["LightCyan"], GlobalData.Theme["Cyan"]);
			BlockUI magentaBlock = new BlockUI(magentaBlockTexture, GlobalData.Theme["LightMagenta"], GlobalData.Theme["Magenta"]);
			BlockUI grayBlock = new BlockUI(grayBlockTexture, GlobalData.Theme["LightGray"], GlobalData.Theme["Gray"]);
			BlockUI blackBlock = new BlockUI(blackBlockTexture, GlobalData.Theme["Dark"], GlobalData.Theme["Black"]);

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

		public static Header CreateHeader(Scene scene)
		{
			Dictionary<string, Texture2D> headerTextures = new Dictionary<string, Texture2D>()
			{
				{ "Background", TextureLoader.Load("Header") },
				{ "LeftEdge", TextureLoader.Load("HeaderEdgeLeft") },
				{ "RightEdge", TextureLoader.Load("HeaderEdgeRight") },

				{ "GoldenBackground", TextureLoader.Load("GoldenHeader") },
				{ "GoldenRightEdge", TextureLoader.Load("GoldenHeaderEdgeRight") },
			};

			return new Header(scene, headerTextures);
		}

		public static Footer CreateFooter(Scene scene)
		{
			Texture2D background = TextureLoader.Load("Footer");

			return new Footer(scene, background);
		}
	}
}

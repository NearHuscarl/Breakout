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

namespace Breakout.Views.Renderers
{
	public class MonoGameRenderer : AbstractRenderer
	{
		private ContentManager content = EntryPoint.Game.Content;
		private SpriteBatch spriteBatch = EntryPoint.Game.SpriteBatch;
		private SpriteFont font = EntryPoint.Game.Content.Load<SpriteFont>("Fonts/Font");

		public ButtonUI StartButton;
		public ButtonUI CreditButton;
		public ButtonUI ExitButton;

		public Sprite PaddleUI;
		public Sprite BallUI;
		public Dictionary<BlockType, BlockUI> Blocks;
		public FlashingBlockUI GreenBlock;

		private Background background;

		public Font RedFont;
		public Font GreenFont;
		public Font YellowFont;

		public MonoGameRenderer()
		{
			background = UIFactory.CreateBackground(content);

			StartButton = UIFactory.CreateStartButton(content);
			CreditButton = UIFactory.CreateCreditButton(content);
			ExitButton = UIFactory.CreateExitButton(content);

			PaddleUI = UIFactory.CreatePaddle(content);
			BallUI = UIFactory.CreateBall(content);

			Blocks = UIFactory.CreateBlocks(content);
			GreenBlock = UIFactory.CreateFlashingBlock(content, "#2ECC71", "#27AE60");

			RedFont = UIFactory.CreateRedFont(font);
			GreenFont = UIFactory.CreateGreenFont(font);
			YellowFont = UIFactory.CreateYellowFont(font);
		}

		public override void DrawMenu()
		{
			StartButton.Draw(spriteBatch, Scene.StartButton);
			CreditButton.Draw(spriteBatch, Scene.CreditButton);
			ExitButton.Draw(spriteBatch, Scene.ExitButton);
		}

		public override void DrawGame()
		{
			background.Draw(spriteBatch);

			PaddleUI.Draw(spriteBatch, Scene.Paddle);

			foreach (var ball in Scene.Balls)
				BallUI.Draw(spriteBatch, ball);

			foreach (var block in Scene.Blocks)
			{
				if (block.Type == BlockType.Green)
					GreenBlock.Draw(spriteBatch, block, EntryPoint.Game.Elapsed);
				else
					Blocks[block.Type].Draw(spriteBatch, block);
			}

			RedFont.Draw(spriteBatch, Scene.Player.Score, Alignment.Center);
			GreenFont.Draw(spriteBatch, Scene.Player.Live, Alignment.Left);
			YellowFont.Draw(spriteBatch, Scene.BlockLeft, Alignment.Right);

			RedFont.Draw(spriteBatch, Scene.Player.CurrentCombo,
				Alignment.Left, offsetText: Scene.Player.Live.FullText);

			RedFont.Draw(spriteBatch, Scene.Player.HighestCombo,
				Alignment.Left, offsetText: Scene.Player.Live.FullText + Scene.Player.CurrentCombo.FullText);
		}

		public void CenterScreen()
		{
			Point position = new Point();

			int monitorWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
			int monitorHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

			position.X = (int)(monitorWidth * 0.5f - GameInfo.Screen.Width * 0.5f);
			position.Y = (int)(monitorHeight * 0.3f - GameInfo.Screen.Height * 0.3f);

			EntryPoint.Game.Window.Position = position;
		}
	}
}

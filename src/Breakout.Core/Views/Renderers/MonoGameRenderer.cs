using Breakout.Models;
using Breakout.Models.Blocks;
using Breakout.Models.Enums;
using Breakout.Models.UIComponents;
using Breakout.Models.Windows;
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
		private float deltaTime;

		private ContentManager content = EntryPoint.Game.Content;
		private SpriteBatch spriteBatch = EntryPoint.Game.SpriteBatch;

		private SpriteFont scoreFont = EntryPoint.Game.Content.Load<SpriteFont>("Fonts/ScoreFont");
		private SpriteFont buttonFont = EntryPoint.Game.Content.Load<SpriteFont>("Fonts/ButtonFont");

		private Cursor cursor;

		public Sprite PaddleUI;
		public Sprite BallUI;
		public Dictionary<BlockType, BlockUI> Blocks;
		public Dictionary<BlockType, FlashingBlockUI> FlashingBlocks;

		private Sprite footer;
		private Dictionary<Stage, Background> backgrounds;

		private ScreenUI gameScreen;
		private MessageBoxUI messageBox;

		public Font RedFont;
		public Font GreenFont;
		public Font YellowFont;

		public ButtonUI ButtonUI;

		public MessageBox ExitMsgBox;

		public MonoGameRenderer()
		{
			cursor = UIFactory.CreateCursor(content);

			backgrounds = UIFactory.CreateBackground(content);
			footer = UIFactory.CreateFooter(content);

			ButtonUI = UIFactory.CreateButton(content, buttonFont);

			gameScreen = UIFactory.CreateScreen(content, buttonFont);
			messageBox = UIFactory.CreateMessageBox(content, buttonFont);

			PaddleUI = UIFactory.CreatePaddle(content);
			BallUI = UIFactory.CreateBall(content);

			Blocks = UIFactory.CreateBlocks(content);
			FlashingBlocks = UIFactory.CreateFlashingBlocks(content);

			RedFont = UIFactory.CreateRedFont(scoreFont);
			GreenFont = UIFactory.CreateGreenFont(scoreFont);
			YellowFont = UIFactory.CreateYellowFont(scoreFont);
		}

		public override void DrawMenu(float elapsed)
		{
			backgrounds[Stage.Menu].Draw(spriteBatch);

			foreach (var button in Scene.Buttons.Values)
				ButtonUI.Draw(spriteBatch, button);

			DrawBall();
			DrawBlocks(elapsed);

			cursor.Draw(spriteBatch);
		}

		public override void DrawGame(float elapsed)
		{
			deltaTime = elapsed;

			backgrounds[Stage.Level1].Draw(spriteBatch);

			PaddleUI.Draw(spriteBatch, Scene.Paddle);

			DrawBall();
			DrawBlocks(deltaTime);
			footer.Draw(spriteBatch, Scene.Footer);

			RedFont.Draw(spriteBatch, Scene.Player.Score, Alignment.Center);
			GreenFont.Draw(spriteBatch, Scene.Player.Live, Alignment.Left);
			YellowFont.Draw(spriteBatch, Scene.BlockLeft, Alignment.Right);

			RedFont.Draw(spriteBatch, Scene.Player.CurrentCombo,
				Alignment.Left, offsetText: Scene.Player.Live.FullText);

			RedFont.Draw(spriteBatch, Scene.Player.HighestCombo,
				Alignment.Left, offsetText: Scene.Player.Live.FullText + Scene.Player.CurrentCombo.FullText);
		}

		private void DrawBall()
		{
			foreach (var ball in Scene.Balls)
				BallUI.Draw(spriteBatch, ball);
		}

		private void DrawBlocks(float elapsed)
		{
			foreach (var flashingBlock in FlashingBlocks.Values)
				flashingBlock.UpdateFlashingColorAmount(elapsed);

			foreach (var block in Scene.Blocks)
			{
				if (BlockInfo.IsFlashing(block.Type))
					FlashingBlocks[block.Type].Draw(spriteBatch, block);
				else
					Blocks[block.Type].Draw(spriteBatch, block);
			}
		}

		public override void DrawExitPrompt()
		{
			MessageBox exitPrompt = WindowManager.CurrentScreen as MessageBox;

			if (exitPrompt == null)
				return;

			if (Scene.IsInGame)
				DrawGame(deltaTime);
			else
				DrawMenu(deltaTime);

			messageBox.Draw(spriteBatch, exitPrompt);

			ButtonUI.Draw(spriteBatch, exitPrompt.YesButton);
			ButtonUI.Draw(spriteBatch, exitPrompt.NoButton);

			cursor.Draw(spriteBatch);
		}

		public override void DrawAbout()
		{
			AboutScreen aboutScreen = WindowManager.CurrentScreen as AboutScreen;

			if (aboutScreen == null)
				return;

			DrawMenu(deltaTime);

			gameScreen.Draw(spriteBatch, aboutScreen);
			ButtonUI.Draw(spriteBatch, aboutScreen.OpenCodeButton);
			ButtonUI.Draw(spriteBatch, aboutScreen.CancelButton);

			cursor.Draw(spriteBatch);
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

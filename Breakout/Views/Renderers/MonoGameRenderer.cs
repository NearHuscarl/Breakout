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
		private int screenWidth = EntryPoint.Game.graphics.PreferredBackBufferWidth;
		private int screenHeight = EntryPoint.Game.graphics.PreferredBackBufferHeight;

		private ContentManager content = EntryPoint.Game.Content;
		private SpriteBatch spriteBatch = EntryPoint.Game.SpriteBatch;
		private SpriteFont font = EntryPoint.Game.Content.Load<SpriteFont>("Font");
		private UIFactory uiFactory;

		public Button StartGameButton;
		public Button OptionButton;
		public Button ExitButton;

		public Paddle PaddleUI;
		public Ball BallUI;
		public List<Block> Blocks;

		private float ballVelocity;
		private float paddleVelocity;
		public bool IsPlaying; // for pause hotkey or on restarting

		private Background background;

		public Font Score; // score for every block hit
		public Font Live;
		public Font BlockLeft;
		public Font CurrentCombo;
		public Font HighestCombo;

		public MonoGameRenderer()
		{
			uiFactory = new UIFactory(screenWidth, screenHeight);

			background = uiFactory.CreateBackground(content);

			StartGameButton = uiFactory.CreateStartGameButton(content);
			OptionButton = uiFactory.CreateOptionButton(content);
			ExitButton = uiFactory.CreateExitButton(content);

			PaddleUI = uiFactory.CreatePaddle(content);
			BallUI = uiFactory.CreateBall(content, PaddleUI);
			Blocks = uiFactory.CreateBlocks(content);

			ballVelocity = 3f;
			paddleVelocity = 10f;
			IsPlaying = false;

			Score = uiFactory.CreateScoreFont(font);
			Live = uiFactory.CreateLiveFont(font);
			BlockLeft = uiFactory.CreateBlockLeftFont(font);
			CurrentCombo = uiFactory.CreateComboFont(font);
			HighestCombo = uiFactory.CreateMaxComboFont(font);
		}

		public override void DrawGame()
		{
			background.Draw(spriteBatch);

			PaddleUI.Draw(spriteBatch);
			BallUI.Draw(spriteBatch);

			foreach (var block in Blocks)
				block.Draw(spriteBatch);

			Score.Draw(spriteBatch);
			Live.Draw(spriteBatch);
			BlockLeft.Draw(spriteBatch);
			CurrentCombo.Draw(spriteBatch);
			HighestCombo.Draw(spriteBatch);
		}

		public override void DrawMenu()
		{
			StartGameButton.Draw(spriteBatch);
			OptionButton.Draw(spriteBatch);
			ExitButton.Draw(spriteBatch);
		}

		public override void MovePaddle(int currentXPos, int newXPos)
		{
			throw new NotImplementedException();
		}

		public void CenterScreen()
		{
			Point position = new Point();

			int monitorWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
			int monitorHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

			position.X = monitorWidth / 2 - screenWidth / 2;
			position.Y = monitorHeight / 2 - screenHeight / 2;

			EntryPoint.Game.Window.Position = position;
		}
	}
}

using Breakout.Models;
using Breakout.Models.Blocks;
using Breakout.Models.Enums;
using Breakout.Models.UIComponents;
using Breakout.Models.Windows;
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

namespace Breakout.Views.Renderers
{
	public class MonoGameRenderer : AbstractRenderer
	{
		private float deltaTime;

		private ContentManager content = EntryPoint.Game.Content;
		private SpriteBatch spriteBatch = EntryPoint.Game.SpriteBatch;
		private Scene scene = EntryPoint.Game.Scene;

		private SpriteFont scoreFont = EntryPoint.Game.Content.Load<SpriteFont>("Fonts/ScoreFont");
		private SpriteFont buttonFont = EntryPoint.Game.Content.Load<SpriteFont>("Fonts/ButtonFont");

		private Cursor cursor;

		public PaddleUI PaddleUI;
		public Sprite BallUI;
		public Dictionary<GameColor, BlockUI> Blocks;

		private Sprite footer;
		private Dictionary<Stage, Background> backgrounds;

		private ScreenUI gameScreen;
		private MessageBoxUI messageBox;

		public Font RedFont;
		public Font GreenFont;
		public Font YellowFont;

		public ButtonUI ButtonUI;
		public CheckBoxUI CheckBoxUI;
		public CheckBoxUI RadioBtnUI;

		public MessageBox ExitMsgBox;

		public MonoGameRenderer()
		{
			cursor = UIFactory.CreateCursor(content);

			backgrounds = UIFactory.CreateBackground(content);
			footer = UIFactory.CreateFooter(content);

			ButtonUI = UIFactory.CreateButton(content, buttonFont);
			CheckBoxUI = UIFactory.CreateCheckBox(content, buttonFont);
			RadioBtnUI = UIFactory.CreateRadioButton(content, buttonFont);

			gameScreen = UIFactory.CreateScreen(content, buttonFont);
			messageBox = UIFactory.CreateMessageBox(content, buttonFont);

			PaddleUI = UIFactory.CreatePaddle(content);
			BallUI = UIFactory.CreateBall(content);

			Blocks = UIFactory.CreateBlocks(content);

			RedFont = UIFactory.CreateRedFont(scoreFont);
			GreenFont = UIFactory.CreateGreenFont(scoreFont);
			YellowFont = UIFactory.CreateYellowFont(scoreFont);
		}

		public override void DrawMenu(float elapsed)
		{
			backgrounds[Stage.Menu].Draw(spriteBatch);

			foreach (var button in scene.Buttons.Values)
				ButtonUI.Draw(spriteBatch, button);

			DrawBall();
			DrawBlocks(elapsed);

			cursor.Draw(spriteBatch);
		}

		public override void DrawGame(float elapsed)
		{
			deltaTime = elapsed;

			backgrounds[Stage.Level1].Draw(spriteBatch);

			PaddleUI.Draw(spriteBatch, scene.Paddle);

			DrawBall();
			DrawBlocks(deltaTime);
			footer.Draw(spriteBatch, scene.Footer);

			RedFont.Draw(spriteBatch, scene.Player.Score, Alignment.Center);
			GreenFont.Draw(spriteBatch, scene.Player.Live, Alignment.Left);
			YellowFont.Draw(spriteBatch, scene.BlockLeft, Alignment.Right);

			RedFont.Draw(spriteBatch, scene.Player.CurrentCombo,
				Alignment.Left, offsetText: scene.Player.Live.FullText);

			RedFont.Draw(spriteBatch, scene.Player.HighestCombo,
				Alignment.Left, offsetText: scene.Player.Live.FullText + scene.Player.CurrentCombo.FullText);
		}

		private void DrawBall()
		{
			foreach (var ball in scene.Balls)
				BallUI.Draw(spriteBatch, ball);
		}

		private void DrawBlocks(float elapsed)
		{
			foreach (var block in Blocks.Values)
				block.UpdateColor(elapsed);

			foreach (var block in scene.Blocks)
				Blocks[block.Color].Draw(spriteBatch, block);
		}

		public override void DrawExitPrompt()
		{
			MessageBox exitPrompt = WindowManager.CurrentScreen as MessageBox;

			if (exitPrompt == null)
				return;

			if (scene.IsInGame)
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

		public override void DrawSetting()
		{
			SettingScreen settingScreen = WindowManager.CurrentScreen as SettingScreen;

			if (settingScreen == null)
				return;

			DrawMenu(deltaTime);

			gameScreen.Draw(spriteBatch, settingScreen);
			ButtonUI.Draw(spriteBatch, settingScreen.ApplyButton);
			ButtonUI.Draw(spriteBatch, settingScreen.CancelButton);
			CheckBoxUI.Draw(spriteBatch, settingScreen.Mute);

			foreach (var radio in settingScreen.Difficulties.RadioButtons)
				RadioBtnUI.Draw(spriteBatch, radio.Value);

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

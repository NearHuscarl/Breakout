﻿using Breakout.Models;
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

namespace Breakout.Views.Renderers
{
	public class MonoGameRenderer : AbstractRenderer
	{
		private ContentManager content = EntryPoint.Game.Content;
		private SpriteBatch spriteBatch = EntryPoint.Game.SpriteBatch;
		private SpriteFont font = EntryPoint.Game.Content.Load<SpriteFont>("Font");

		public ButtonUI StartButton;
		public ButtonUI CreditButton;
		public ButtonUI ExitButton;

		public Sprite PaddleUI;
		public Sprite BallUI;
		public Dictionary<BlockType, BlockUI> Blocks;
		public FlashingBlockUI GreenBlock;

		private Background background;

		public Font Score; // score for every block hit
		public Font Live;
		public Font BlockLeft;
		public Font CurrentCombo;
		public Font HighestCombo;

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

			Score = UIFactory.CreateScoreFont(font);
			Live = UIFactory.CreateLiveFont(font);
			BlockLeft = UIFactory.CreateBlockLeftFont(font);
			CurrentCombo = UIFactory.CreateComboFont(font);
			HighestCombo = UIFactory.CreateMaxComboFont(font);
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

			Score.Draw(spriteBatch, Scene.Player.Score);
			Live.Draw(spriteBatch, Scene.Player.Live);
			BlockLeft.Draw(spriteBatch, Scene.BlockLeft);
			CurrentCombo.Draw(spriteBatch, Scene.Player.CurrentCombo);
			HighestCombo.Draw(spriteBatch, Scene.Player.HighestCombo);
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
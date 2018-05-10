using Breakout.Models;
using Breakout.Models.Blocks;
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

		private SpriteFont scoreFont = EntryPoint.Game.Content.Load<SpriteFont>("Fonts/ScoreFont");
		private SpriteFont buttonFont = EntryPoint.Game.Content.Load<SpriteFont>("Fonts/ButtonFont");

		public ButtonUI StartButton;
		public ButtonUI CreditButton;
		public ButtonUI ExitButton;

		public Sprite PaddleUI;
		public Sprite BallUI;
		public Dictionary<BlockType, BlockUI> Blocks;
		public Dictionary<BlockType, FlashingBlockUI> FlashingBlocks;

		private Sprite footer;
		private Dictionary<Stage, Background> backgrounds;

		public Font RedFont;
		public Font GreenFont;
		public Font YellowFont;

		public MonoGameRenderer()
		{
			backgrounds = UIFactory.CreateBackground(content);
			footer = UIFactory.CreateFooter(content);

			StartButton = UIFactory.CreateStartButton(content, buttonFont);
			CreditButton = UIFactory.CreateCreditButton(content, buttonFont);
			ExitButton = UIFactory.CreateExitButton(content, buttonFont);

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

			StartButton.Draw(spriteBatch, Scene.StartButton);
			CreditButton.Draw(spriteBatch, Scene.CreditButton);
			ExitButton.Draw(spriteBatch, Scene.ExitButton);

			DrawBalls();
			DrawBlocks(elapsed);
		}

		public override void DrawGame(float elapsed)
		{
			backgrounds[Stage.Level1].Draw(spriteBatch);

			PaddleUI.Draw(spriteBatch, Scene.Paddle);

			DrawBalls();
			DrawBlocks(elapsed);

			footer.Draw(spriteBatch, Scene.Footer);

			RedFont.Draw(spriteBatch, Scene.Player.Score, Alignment.Center);
			GreenFont.Draw(spriteBatch, Scene.Player.Live, Alignment.Left);
			YellowFont.Draw(spriteBatch, Scene.BlockLeft, Alignment.Right);

			RedFont.Draw(spriteBatch, Scene.Player.CurrentCombo,
				Alignment.Left, offsetText: Scene.Player.Live.FullText);

			RedFont.Draw(spriteBatch, Scene.Player.HighestCombo,
				Alignment.Left, offsetText: Scene.Player.Live.FullText + Scene.Player.CurrentCombo.FullText);
		}

		private void DrawBalls()
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

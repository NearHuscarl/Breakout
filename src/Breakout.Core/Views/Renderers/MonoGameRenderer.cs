using Breakout.Models;
using Breakout.Models.Enums;
using Breakout.Views.Enums;
using Breakout.Views.Sprites;
using Breakout.Views.Sprites.Blocks;
using Breakout.Views.UIComponents;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Breakout.Views.Renderers
{
	public class MonoGameRenderer : AbstractRenderer
	{
		private float deltaTime;

		private ContentManager content = EntryPoint.Game.Content;
		private SpriteBatch spriteBatch = EntryPoint.Game.SpriteBatch;
		private Scene scene;

		private Cursor cursor;

		public PaddleUI PaddleUI;
		public GameSprite BallUI;
		public Dictionary<GameColor, BlockUI> Blocks;
		private GameSprite skeletonBlock;

		private ScoreBar scoreBar;
		private Dictionary<Stage, Background> backgrounds;

		public MonoGameRenderer(Scene scene)
		{
			this.scene = scene;

			cursor = SpriteFactory.CreateCursor(content);

			backgrounds = SpriteFactory.CreateBackground(content);
			scoreBar = new ScoreBar(scene);

			PaddleUI = SpriteFactory.CreatePaddle(content);
			BallUI = SpriteFactory.CreateBall(content);

			Blocks = SpriteFactory.CreateBlocks(content);
			skeletonBlock = SpriteFactory.CreateSkeletonBlock(content);
		}

		public override void DrawMenu(float elapsed)
		{
			backgrounds[Stage.Menu].Draw(spriteBatch);

			DrawBallAndBlocks(elapsed);

			cursor.Draw(spriteBatch);

			DrawScreens();
		}

		public override void DrawGame(float elapsed)
		{
			deltaTime = elapsed;

			backgrounds[Stage.Level1].Draw(spriteBatch);

			PaddleUI.Draw(spriteBatch, scene.Paddle);

			DrawBallAndBlocks(deltaTime);

			scoreBar.Draw(spriteBatch);

			DrawScreens();
		}

		private void DrawBallAndBlocks(float elapsed)
		{
			foreach (var block in Blocks.Values)
				block.UpdateColor(elapsed);

			foreach (var block in scene.Map.Layer0)
				skeletonBlock.Draw(spriteBatch, block);

			foreach (var ball in scene.Balls)
				BallUI.Draw(spriteBatch, ball);

			foreach (var block in scene.Map.Layer1)
				Blocks[block.Color].Draw(spriteBatch, block);
		}

		public override void DrawScreens()
		{
			foreach (var screen in WindowManager.Screens)
			{
				screen.Draw(spriteBatch);
			}

			if (WindowManager.Screens.Count > 0)
			{
				cursor.Draw(spriteBatch);
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
using Breakout.Core.Models;
using Breakout.Core.Models.Data;
using Breakout.Core.Models.Enums;
using Breakout.Core.Views.Enums;
using Breakout.Core.Views.Sprites;
using Breakout.Core.Views.Sprites.Blocks;
using Breakout.Core.Views.UIComponents;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;

namespace Breakout.Core.Views.Renderers
{
	public class MonoGameRenderer : AbstractRenderer
	{
		private float deltaTime;

		private ContentManager content = EntryPoint.Game.Content;
		private SpriteBatch spriteBatch = EntryPoint.Game.SpriteBatch;
		private Scene scene;

		private Cursor cursor;

		public PaddleUI PaddleUI;
		public BallUI BallUI;
		private Dictionary<PowerUpType, GameSprite> powerups;

		public Dictionary<GameColor, BlockUI> Blocks;
		private GameSprite skeletonBlock;

		private Header header;
		private Footer footer;
		private Background backgrounds;

		public MonoGameRenderer(Scene scene)
		{
			this.scene = scene;

			cursor = SpriteFactory.CreateCursor(content);

			backgrounds = SpriteFactory.CreateBackground(content, scene);
			header = SpriteFactory.CreateHeader(scene);
			footer = SpriteFactory.CreateFooter(scene);

			PaddleUI = SpriteFactory.CreatePaddle(content);
			BallUI = SpriteFactory.CreateBall(content);
			powerups = SpriteFactory.CreatePowerups(content);

			Blocks = SpriteFactory.CreateBlocks(content);
			skeletonBlock = SpriteFactory.CreateSkeletonBlock(content);
		}

		public override void DrawMenu(float elapsed)
		{
			backgrounds.Draw(spriteBatch);

			DrawGameEntities(elapsed);

			cursor.Draw(spriteBatch);

			DrawScreens();
		}

		public override void DrawGame(float elapsed)
		{
			deltaTime = elapsed;

			backgrounds.Draw(spriteBatch);

			PaddleUI.Draw(spriteBatch, scene.Paddle);

			DrawGameEntities(deltaTime);

			header.Draw(spriteBatch);
			footer.Draw(spriteBatch);

			DrawScreens();
		}

		private void DrawGameEntities(float elapsed)
		{
			foreach (var block in Blocks.Values)
				block.UpdateColor(elapsed);

			foreach (var block in scene.Map.Layer0)
				skeletonBlock.Draw(spriteBatch, block);

			foreach (var ball in scene.Balls)
				BallUI.Draw(spriteBatch, ball);

			foreach (var block in scene.Map.Layer1)
				Blocks[block.Color].Draw(spriteBatch, block);

			scene.Packages
				.Where(p => p.Type != PowerUpType.Nothing)
				.ToList()
				.ForEach(p => powerups[p.Type].Draw(spriteBatch, p));
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

			position.X = (int)(monitorWidth * 0.5f - GlobalData.Screen.Width * 0.5f);
			position.Y = (int)(monitorHeight * 0.3f - GlobalData.Screen.Height * 0.3f);

			EntryPoint.Game.Window.Position = position;
		}
	}
}
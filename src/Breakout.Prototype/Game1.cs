using Breakout;
using Breakout.Fonts;
using Breakout.Core.Models;
using Breakout.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Breakout
{
	/// <summary>
	/// This is the main type for your game.
	/// </summary>
	public class Game1 : Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;

		public static int screenHeight;
		public static int screenWidth;
		public static Random random;

		private Live live;
		private Blocks blocks;
		private Bat bat;
		private Ball ball;

		private bool isPlaying = false;

		public Game1()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
		}

		/// <summary>
		/// Allows the game to perform any initialization it needs to before starting to run.
		/// This is where it can query for any required services and load any non-graphic
		/// related content.  Calling base.Initialize will enumerate through any components
		/// and initialize them as well.
		/// </summary>
		protected override void Initialize()
		{
			screenWidth = graphics.PreferredBackBufferWidth;
			screenHeight = graphics.PreferredBackBufferHeight;
			random = new Random();

			base.Initialize();
		}

		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch(GraphicsDevice);

			var batTexture = Content.Load<Texture2D>("Bat");
			var ballTexture = Content.Load<Texture2D>("Ball");
			var font = Content.Load<SpriteFont>("Font");
			var blockTextures = new List<Texture2D>()
			{
				{ Content.Load<Texture2D>("block1") },
				{ Content.Load<Texture2D>("block2") },
				{ Content.Load<Texture2D>("block3") },
				{ Content.Load<Texture2D>("block4") },
				{ Content.Load<Texture2D>("block5") },
				{ Content.Load<Texture2D>("block6") },
				{ Content.Load<Texture2D>("block7") },
			};

			blocks = new Blocks(blockTextures);
			bat = new Bat(batTexture)
			{
				input = new Input()
				{
					Left = Keys.Left,
					Right = Keys.Right,
				}
			};
			ball = new Ball(ballTexture);
			live = new Live(font)
			{
				position = new Vector2(2, 2),
			};

			StartGame();
		}

		/// <summary>
		/// UnloadContent will be called once per game and is the place to unload
		/// game-specific content.
		/// </summary>
		protected override void UnloadContent()
		{
			// TODO: Unload any non ContentManager content here
		}

		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Update(GameTime gameTime)
		{
			if (Keyboard.GetState().IsKeyDown(Keys.Space))
				isPlaying = true;

			if (!isPlaying)
				return;

			ball.Update(gameTime);
			bat.Update(gameTime);

			ball.CheckBatCollision(bat);
			ball.CheckBlocksCollision(blocks);

			if (ball.IsOffBottom())
			{
				Reset();
				live.Take(1);
			}

			if (live.Amount() == 0)
			{
				Restart();
				live.Get(3);
			}

			base.Update(gameTime);
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);

			spriteBatch.Begin();

			bat.Draw(spriteBatch);
			ball.Draw(spriteBatch);

			blocks.Draw(spriteBatch);

			live.Draw(spriteBatch);

			spriteBatch.End();

			base.Draw(gameTime);
		}

		private void StartGame()
		{
			bat.ResetPosition();
			ball.ResetPosition(bat.Rectangle);
			blocks.ResetPosition();
		}


		/// <summary>
		/// When you lose 1 live
		/// </summary>
		private void Reset()
		{
			bat.ResetPosition();
			ball.ResetPosition(bat.Rectangle);

			isPlaying = false;
		}

		/// <summary>
		/// When you lose all lives
		/// </summary>
		private void Restart()
		{
			StartGame();
			isPlaying = false;
		}
	}
}

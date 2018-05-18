using Breakout.Controllers;
using Breakout.Models;
using Breakout.Views.Renderers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Breakout
{
	public class BreakoutGame : Game
	{
		public GraphicsDeviceManager Graphics;
		public SpriteBatch SpriteBatch;
		public MonoGameRenderer Renderer;
		public Scene Scene;

		public float Elapsed { get; private set; }

		public BreakoutGame()
		{
			Graphics = new GraphicsDeviceManager(this);

			Content.RootDirectory = "Content";
			IsMouseVisible = false; // We will use custom cursor here

			Graphics.PreferredBackBufferWidth = 1000;
			Graphics.PreferredBackBufferHeight = 600;
		}

		protected override void Initialize()
		{
			Scene = new Scene(EntryPoint.Game);

			StateMachine.Initialize(Scene);

			base.Initialize();
		}

		protected override void LoadContent()
		{
			SpriteBatch = new SpriteBatch(GraphicsDevice);
			Renderer = new MonoGameRenderer(Scene);

			Renderer.CenterScreen();
		}

		protected override void Update(GameTime gameTime)
		{
			Elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;

			StateMachine.CurrentState.Update();

			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			// GraphicsDevice.Clear(Color.CornflowerBlue);

			SpriteBatch.Begin();
			StateMachine.CurrentState.Draw(Renderer);
			SpriteBatch.End();

			base.Draw(gameTime);
		}
	}
}

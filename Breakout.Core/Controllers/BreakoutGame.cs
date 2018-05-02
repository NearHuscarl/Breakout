using Breakout.Controllers;
using Breakout.Models.Meta;
using Breakout.Views.Renderers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout
{
	public class BreakoutGame : Game
	{
		public GraphicsDeviceManager graphics;
		public SpriteBatch SpriteBatch;
		public MonoGameRenderer renderer;

		public double Elapsed { get; private set; }

		public BreakoutGame()
		{
			graphics = new GraphicsDeviceManager(this);

			Content.RootDirectory = "Content";
			IsMouseVisible = true;

			graphics.PreferredBackBufferHeight = 600;
			graphics.PreferredBackBufferWidth = 1000;
		}

		protected override void Initialize()
		{
			StateMachine.Initialize();
			StateMachine.CurrentState = StateMachine.States["InitialState"];
			StateMachine.CurrentState.Update();

			base.Initialize();
		}

		protected override void LoadContent()
		{
			SpriteBatch = new SpriteBatch(GraphicsDevice);
			renderer = new MonoGameRenderer();

			renderer.CenterScreen();
		}

		protected override void Update(GameTime gameTime)
		{
			// if (Keyboard.GetState().IsKeyDown(Keys.Escape))
			// 	Exit();

			Elapsed = gameTime.ElapsedGameTime.TotalSeconds;

			StateMachine.CurrentState.Update();

			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);

			SpriteBatch.Begin();
			StateMachine.CurrentState.Draw(renderer);
			SpriteBatch.End();

			base.Draw(gameTime);
		}
	}
}

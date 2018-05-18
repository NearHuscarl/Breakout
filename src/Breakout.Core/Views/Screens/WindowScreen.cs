using Breakout.Models;
using Breakout.Views.Windows;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Breakout.Views.Screens
{
	/// <summary>
	/// A screen is a Rectangle to group buttons and text. It's bigger than
	/// MessageBox and used in game screen like settings screen, about screen...
	/// </summary>
	public abstract class WindowScreen : Screen
	{
		protected Texture2D background;
		protected SpriteFont spriteFont;

		public Vector2 Position
		{
			get
			{
				return new Vector2()
				{
					X = GameInfo.Screen.Width / 2 - Width / 2,
					Y = GameInfo.Screen.Height / 2 - Height / 2,
				};
			}
		}
		public virtual int Width
		{
			get
			{
				if (background != null)
					return background.Width;

				return default(int);
			}
		}
		public virtual int Height
		{
			get
			{
				if (background != null)
					return background.Height;

				return default(int);
			}
		}

		public Label Title { get; set; }
		public float Margin { get; set; } = 5f;

		public WindowScreen()
		{
			this.spriteFont = FontLoader.Load("MenuFont");
			this.Title = new Label(spriteFont, text: "Breakout");
		}

		protected Vector2 GetTitlePosition()
		{
			return new Vector2()
			{
				X = Position.X + Width / 2 - spriteFont.MeasureString(Title.Text).X / 2,
				Y = Position.Y + spriteFont.MeasureString(Title.Text).Y * 0.1f,
			};
		}

		/// <summary>
		/// Get Button X Position based on button ordinal number and
		/// total number of buttons to place it equally on the x axis
		/// </summary>
		/// <param name="controlOrdinalNumber"></param>
		/// <param name="totalButton"></param>
		/// <returns></returns>
		protected float GetControlXPosition(Control control, int controlOrdinalNumber, int numOfControls)
		{
			float margin = (Width - numOfControls * control.Width) / (numOfControls + 1);

			return Position.X + margin * controlOrdinalNumber + control.Width * (controlOrdinalNumber - 1);
		}

		protected float GetControlYPosition(Control control, int controlOrdinalNumber, int numOfControls)
		{
			float margin = (Height - numOfControls * control.Height) / (numOfControls + 1);

			return Position.Y + margin * controlOrdinalNumber + control.Height * (controlOrdinalNumber - 1);
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(background, Position, Color.White);

			Title.Position = GetTitlePosition();
			Title.Draw(spriteBatch);
		}
	}
}

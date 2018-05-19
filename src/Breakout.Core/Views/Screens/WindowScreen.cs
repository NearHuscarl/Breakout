using Breakout.Core.Models;
using Breakout.Core.Views.Loaders;
using Breakout.Core.Views.Windows;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Breakout.Core.Views.Screens
{
	/// <summary>
	/// A screen is a Rectangle to group buttons and text. It's bigger than
	/// MessageBox and used in game screen like settings screen, about screen...
	/// </summary>
	public abstract class WindowScreen : Screen
	{
		protected Texture2D background;
		protected SpriteFont defaultFont;

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
			this.defaultFont = FontLoader.Load("MenuFont");
			this.Title = new Label(defaultFont, text: "Breakout");
		}

		protected Vector2 GetTitlePosition()
		{
			return new Vector2()
			{
				X = Position.X + Width / 2 - defaultFont.MeasureString(Title.Text).X / 2,
				Y = Position.Y + defaultFont.MeasureString(Title.Text).Y * 0.1f,
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

		protected void SetTextPosition(Label label, float lineOffset)
		{
			label.Position = new Vector2()
			{
				X = Position.X + Width / 2 - label.Font.MeasureString(label.Text).X / 2,
				Y = Position.Y + Margin + label.Font.MeasureString(label.Text).Y + lineOffset,
			};
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(background, Position, Color.White);

			Title.Position = GetTitlePosition();
			Title.Draw(spriteBatch);
		}
	}
}

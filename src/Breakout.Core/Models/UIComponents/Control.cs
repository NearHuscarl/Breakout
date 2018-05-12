using Breakout.Models.Bases;
using Breakout.Models.Shapes;
using Microsoft.Xna.Framework;

namespace Breakout.Models.UIComponents
{
	public class Control : GameObject, IRectangle
	{
		public Rectangle Rectangle
		{
			get
			{
				return new Rectangle((int)Position.X, (int)Position.Y, Width, Height);
			}
		}

		public Control()
		{

		}

		public virtual void HandleInput()
		{

		}
	}
}

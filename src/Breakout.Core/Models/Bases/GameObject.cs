using Microsoft.Xna.Framework;

namespace Breakout.Models.Bases
{
	/// <summary>
	/// Base class of all game entities
	/// </summary>
	public class GameObject
	{
		public Vector2 Position;
		public virtual int Width { get; set; }
		public virtual int Height { get; set; }

		public GameObject()
		{

		}

		public GameObject(int width, int height, Vector2 position)
		{
			Width = width;
			Height = height;
			Position = position;
		}
	}
}

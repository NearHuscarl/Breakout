using Microsoft.Xna.Framework;

namespace Breakout.Models.Bases
{
	/// <summary>
	/// Base class of all game entities
	/// </summary>
	public class GameObject
	{
		public Vector2 Position;
		public int Width { get; set; }
		public int Height { get; set; }
	}
}

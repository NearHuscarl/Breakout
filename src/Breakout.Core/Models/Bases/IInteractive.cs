using Microsoft.Xna.Framework;

namespace Breakout.Models.Bases
{
	public interface IInteractive
	{
		/// <summary>
		/// Method to describe certain action when this object is hit with another
		/// Dynamic Object
		/// </summary>
		void Hit();
		Rectangle Rectangle { get; }
	}
}

using Breakout.Core.Utilities.Audio;
using Microsoft.Xna.Framework;

namespace Breakout.Core.Models.Blocks
{
	public class NormalBlock : Block
	{
		public NormalBlock(Scene scene, int width, int height, Vector2 position, BlockAtrributes attrs)
			: base(scene, width, height, position, attrs)
		{

		}

		public override void Hit(object src)
		{
			base.Hit(src);
			AudioManager.PlaySound("HitLightBlock", percent: scene.Volume);
		}
	}
}

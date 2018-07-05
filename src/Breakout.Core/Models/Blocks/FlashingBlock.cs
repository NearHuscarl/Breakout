using Breakout.Core.Models.Enums;
using Breakout.Core.Utilities.Audio;
using Microsoft.Xna.Framework;

namespace Breakout.Core.Models.Blocks
{
	public class FlashingBlock : Block
	{
		public FlashingBlock(Scene scene, int width, int height, Vector2 position, BlockAtrributes attrs)
			: base(scene, width, height, position, attrs)
		{

		}

		public override void Hit(object src)
		{
			base.Hit(src);
			AudioManager.PlaySound("HitFlashingBlock", percent: scene.Volume);
		}

		public override void OnDestroy()
		{
			base.OnDestroy();
			scene.ExplosiveZones.Add(ModelFactory.CreateExplosion(this.Rectangle));
		}
	}
}

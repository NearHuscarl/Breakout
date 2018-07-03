using Breakout.Core.Models.Enums;
using Breakout.Core.Utilities.Audio;
using Microsoft.Xna.Framework;

namespace Breakout.Core.Models.Blocks
{
	public class FlashingBlock : Block
	{
		public FlashingBlock(Scene scene, int width, int height, Vector2 position, BlockType blockType)
			: base(scene, width, height, position, blockType)
		{

		}

		public override void Hit()
		{
			base.Hit();
			AudioManager.PlaySound("HitFlashingBlock", percent: scene.Volume);
		}

		public override void OnDestroy()
		{
			base.OnDestroy();
			scene.ExplosiveZones.Add(ModelFactory.CreateExplosion(this.Rectangle));
		}
	}
}

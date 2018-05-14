using Breakout.Models.Enums;
using Breakout.Utilities;
using Microsoft.Xna.Framework;

namespace Breakout.Models.Blocks
{
	public class FlashingBlock : Block
	{
		public FlashingBlock(Scene scene, Vector2 position, BlockType blockType)
			: base(scene, position, blockType)
		{

		}

		public override void Hit()
		{
			base.Hit();
			AudioManager.PlaySound("HitFlashingBlock");
		}

		public override void OnDestroy()
		{
			base.OnDestroy();
			scene.ExplosiveZones.Add(ModelFactory.CreateExplosion(this.Rectangle));
		}
	}
}

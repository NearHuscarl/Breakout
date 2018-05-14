using Breakout.Models.Enums;
using Breakout.Utilities;
using Microsoft.Xna.Framework;

namespace Breakout.Models.Blocks
{
	public class NormalBlock : Block
	{
		public NormalBlock(Scene scene, Vector2 position, BlockType blockType)
			: base(scene, position, blockType)
		{
			this.Health = (int)(BlockInfo.Health[blockType] * 0.1f);
		}

		public override void Hit()
		{
			base.Hit();
			AudioManager.PlaySound("HitNormalBlock");
		}
	}
}

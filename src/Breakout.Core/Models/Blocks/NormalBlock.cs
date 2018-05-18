using Breakout.Models.Enums;
using Breakout.Utilities;
using Microsoft.Xna.Framework;

namespace Breakout.Models.Blocks
{
	public class NormalBlock : Block
	{
		public NormalBlock(Scene scene, int width, int height, Vector2 position, BlockType blockType)
			: base(scene, width, height, position, blockType)
		{
			this.Health = (int)(BlockInfo.Attributes[blockType].Health * 0.1f);
		}

		public override void Hit()
		{
			base.Hit();
			AudioManager.PlaySound("HitNormalBlock");
		}
	}
}

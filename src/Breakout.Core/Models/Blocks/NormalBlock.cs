using Breakout.Core.Models.Enums;
using Breakout.Core.Utilities.Audio;
using Microsoft.Xna.Framework;

namespace Breakout.Core.Models.Blocks
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
			AudioManager.PlaySound("HitNormalBlock", percent: scene.Volume);
		}
	}
}

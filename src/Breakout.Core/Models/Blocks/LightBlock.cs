using Breakout.Models.Enums;
using Breakout.Models.PowerUps;
using Breakout.Utilities;
using Microsoft.Xna.Framework;

namespace Breakout.Models.Blocks
{
	public class LightBlock : Block
	{
		public LightBlock(Scene scene, int width, int height, Vector2 position, BlockType blockType)
			: base(scene, width, height, position, blockType)
		{

		}

		public override void Hit()
		{
			base.Hit();
			AudioManager.PlaySound("HitLightBlock");
		}

		public override void OnDestroy()
		{
			base.OnDestroy();
			scene.PowerUps.Add(new PowerUp(PowerUpType.Faster, scene.Balls));
		}
	}
}

﻿using Breakout.Core.Models.Enums;
using Breakout.Core.Models.PowerUps;
using Breakout.Core.Utilities.Audio;
using Microsoft.Xna.Framework;

namespace Breakout.Core.Models.Blocks
{
	public class LightBlock : Block
	{
		public LightBlock(Scene scene, int width, int height, Vector2 position, BlockAtrributes attrs)
			: base(scene, width, height, position, attrs)
		{

		}

		public override void Hit(object src)
		{
			base.Hit(src);
			AudioManager.PlaySound("HitLightBlock", percent: scene.Volume);
		}


		//public override void OnDestroy()
		//{
		//	base.OnDestroy();

		//	var powerup = new PowerUp(scene, PowerUpType.Faster);
		//	powerup.Activate();
		//	scene.TriggerPowerup(powerup);
		//}
	}
}

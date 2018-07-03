﻿using Breakout.Core.Models.Enums;
using Breakout.Core.Models.PowerUps;
using Breakout.Core.Utilities.Audio;
using Microsoft.Xna.Framework;

namespace Breakout.Core.Models.Blocks
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
			AudioManager.PlaySound("HitLightBlock", percent: scene.Volume);
		}

		public override void OnDestroy()
		{
			base.OnDestroy();

			var powerup = new BallPowerUp(PowerUpType.Faster, scene.Balls);
			powerup.Activate();
			scene.PowerUps.Add(powerup);
		}
	}
}

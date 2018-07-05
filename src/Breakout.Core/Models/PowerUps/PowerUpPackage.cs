using Breakout.Core.Models.Balls;
using Breakout.Core.Models.Bases;
using Breakout.Core.Models.Enums;
using Breakout.Core.Utilities.Audio;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Breakout.Core.Models.PowerUps
{
	/// <summary>
	/// Package contain power-up
	/// </summary>
	public class PowerUpPackage : RectangleObject, IInteractive
	{
		public PowerUp PowerUp { get; private set; }
		public PowerUpType Type
		{
			get { return PowerUp.PowerUpType;  }
		}

		/// <summary>
		/// When a ball destroy a block, it spawn a package containing a powerup.
		/// but there is high chance are the ball will hit the package anyway
		/// because the package spawn right where the block is destroyed so we
		/// need to wait a bit before the ball can hit the package
		/// </summary>
		public static readonly float ReadyToHitBallInterval = 0.5f; // in secs
		public float Timer { get; set; } = 0f;

		public PowerUpPackage(Scene scene, PowerUp powerUp, int width, int height, Vector2 position)
			: base(width, height, position)
		{
			this.scene = scene;

			PowerUp = powerUp;
			Velocity = 300f;
			Direction = new Vector2(0, 1); // going down
		}

		public void SpawnPowerUp(object src)
		{
			Hit(src);

			scene.TriggerPowerup(PowerUp);
			scene.Packages.Remove(this);
		}

		public void Hit(object src)
		{
			AudioManager.PlaySound("HitPowerUp", percent: scene.Volume);
		}
	}
}

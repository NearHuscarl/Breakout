using Breakout.Core.Models.Balls;
using Breakout.Core.Models.Enums;
using Breakout.Core.Utilities.Audio;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System;
using System.Collections.Specialized;
using Breakout.Extensions;

namespace Breakout.Core.Models.Paddles
{
	public struct TrackedBall
	{
		public Ball Instance { get; set; }
		public float ContactArea { get; set; }
	}

	public class MagnetizedPaddle : Paddle
	{
		public ObservableCollection<TrackedBall> TrackedBalls { get; private set; }

		public MagnetizedPaddle(Scene scene, int height) : base(scene, height)
		{
			TrackedBalls = new ObservableCollection<TrackedBall>();

			TrackedBalls.CollectionChanged += OnTrackedBallsChanged;
		}

		private void OnTrackedBallsChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			if (e.Action == NotifyCollectionChangedAction.Add)
			{
				foreach (TrackedBall trackedBall in e.NewItems)
				{
					var ball = trackedBall.Instance;

					ball.IsAttached = true;
					ball.Position.Y = Position.Y - ball.Height;
				}
			}

			if (e.Action == NotifyCollectionChangedAction.Remove)
			{
				foreach (TrackedBall trackedBall in e.OldItems)
				{
					var ball = trackedBall.Instance;
					
					ball.IsAttached = false;
					ball.Angle = this.GetBounceBackAngle(trackedBall.ContactArea);
				}
			}
		}

		public override void HandleBall(Ball ball)
		{
			if (IsTouching(ball))
			{
				Hit(ball);

				if (!TrackedBalls.Any(trackedBall => trackedBall.Instance.Equals(ball)))
				{
					ball.Position.Y = Position.Y - ball.Height;

					TrackedBall trackedBall = new TrackedBall();

					trackedBall.Instance = ball;
					trackedBall.ContactArea = GetPaddleContactArea(ball);

					TrackedBalls.Add(trackedBall);
				}
			}

			foreach (var trackedBall in TrackedBalls)
			{
				var ballInstance = trackedBall.Instance;

				ballInstance.Position.X = Position.X + MathHelper.Lerp(0, Width, trackedBall.ContactArea);
			}
		}

		public void Release()
		{
			Hit(null);
			TrackedBalls.RemoveAll();
		}

		public override void Hit(object src)
		{
			AudioManager.PlaySound("HitMagnetizedPaddle", percent: scene.Volume);
		}
	}
}

using Microsoft.Xna.Framework.Audio;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;

namespace Breakout.Core.Utilities.Audio
{
	internal static class AudioManager
	{
		private static ContentManager content;
		private static bool isMute = false;

		private static readonly string soundPath = "Sounds/";

		private static string[] soundNames;
		private static string[] songNames;

		private static Dictionary<string, SoundEffectInstance[]> soundLibraries;
		private static Dictionary<string, Song> songLibraries;

		public static float Volume { get; set; }
		public static float CurrentVolume { get; set; }

		public static bool IsMute
		{
			get { return isMute;  }

			set
			{
				if (value)
					CurrentVolume = 0;
				else
					CurrentVolume = Volume;

				isMute = value;
			}
		}
		public static void LoadSound(ContentManager content)
		{
			AudioManager.content = content;

			LoadSongs();
			LoadSoundEffects();

			AudioManager.Volume = 0.5f;
			AudioManager.CurrentVolume = Volume;
		}

		private static void LoadSongs()
		{
			songNames = new string[]
			{
				"WinAllGame",
			};

			songLibraries = new Dictionary<string, Song>();

			foreach (var songName in songNames)
			{
				songLibraries.Add(songName, content.Load<Song>(soundPath + songName));
			}
		}

		private static void LoadSoundEffects()
		{
			soundNames = new string[]
			{
				"ButtonHovered",
				"ButtonClicked",
				"ButtonChecked",

				"CheckBoxToggle",
				"RadioButtonToggle",

				"HitFlashingBlock",
				"HitLightBlock",
				"HitNormalBlock",
				"HitPowerUp",
				"HitWall",
				"HitPaddle",
				"HitMagnetizedPaddle",
				"PaddleHitWall",

				"AddScore",
				"LoseLive",
				"WinGame",
				"GetStar",

				"Interrupt",
			};

			soundLibraries = new Dictionary<string, SoundEffectInstance[]>();

			foreach (var soundName in soundNames)
			{
				soundLibraries.Add(soundName, new SoundEffectInstance[]
				{
					GetSound(soundName),
					GetSound(soundName),
					GetSound(soundName),
				});
			}
		}

		private static SoundEffectInstance GetSound(string fileName)
		{
			return content.Load<SoundEffect>(soundPath + fileName).CreateInstance();
		}

		public static void PlaySong(string name)
		{
			if (songLibraries.ContainsKey(name))
			{
				MediaPlayer.Play(songLibraries[name]);
			}
		}

		public static void StopSong()
		{
			if (MediaPlayer.State != MediaState.Playing)
			{
				return;
			}

			MediaPlayer.Stop();
		}

		/// <summary>
		/// Plays a sound by name.
		/// </summary>
		/// <param name="name">The name of the sound to play</param>
		/// <param name="isLooped">Indicates if the sound should loop</param>
		public static void PlaySound(string name, bool isLooped = false, float percent = 1f)
		{
			if (soundLibraries.ContainsKey(name))
			{
				var soundInstance = (from instance in soundLibraries[name]
										  where instance.State != SoundState.Playing
										  select instance).FirstOrDefault();

				if (soundInstance == null)
					return;

				soundInstance.IsLooped = isLooped;
				soundInstance.Volume = MathHelper.Clamp(CurrentVolume * percent, 0f, 1f);
				soundInstance.Play();
			}
		}

		/// <summary>
		/// Stops a sound mid-play. If the sound is not playing, this
		/// method does nothing.
		/// </summary>
		/// <param name="name">The name of the sound to stop</param>
		public static void StopSound(string name)
		{
			if (soundLibraries.ContainsKey(name))
			{
				var soundInstances = soundLibraries[name];

				foreach (var soundInstance in soundInstances)
					soundInstance.Stop();
			}
		}

		/// <summary>
		/// Stops a sound mid-play. If the sound is not playing, this
		/// method does nothing.
		/// </summary>
		/// <param name="name">The name of the sound to stop</param>
		public static void StopSounds(string name, bool isLooped = false)
		{
			var soundInstances = from instances in soundLibraries.Values
										from instance in instances
										where instance.State != SoundState.Stopped
										select instance;

			foreach (var soundInstance in soundInstances)
				soundInstance.Stop();
		}

		/// <summary>
		/// Pause all sounds to support pause screen
		/// </summary>
		public static void PauseSounds()
		{
			var soundInstances = from instances in soundLibraries.Values
										from instance in instances
										where instance.State == SoundState.Playing
										select instance;

			foreach (var soundInstance in soundInstances)
				soundInstance.Pause();
		}

		/// <summary>
		/// Resume all sounds after going back to game from pause screen
		/// </summary>
		public static void ResumeSounds()
		{
			var soundInstances = from instances in soundLibraries.Values
										from instance in instances
										where instance.State == SoundState.Paused
										select instance;

			foreach (var soundInstance in soundInstances)
				soundInstance.Play();
		}

		#region Instance Disposal Methods

		/// <summary>
		/// Clean up the component when it is disposing.
		/// </summary>
		//public static void Dispose(bool disposing)
		//{
		//	try
		//	{
		//		if (disposing)
		//		{
		//			foreach (var item in soundLibraries.Values)
		//			{
		//				item.Dispose();
		//			}
		//			soundLibraries.Clear();
		//			soundLibraries = null;
		//		}
		//	}
		//	finally
		//	{

		//	}
		//}

		#endregion
	}
}

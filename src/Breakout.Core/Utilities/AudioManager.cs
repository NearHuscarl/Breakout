using Microsoft.Xna.Framework.Audio;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using System.Linq;

namespace Breakout.Utilities
{
	public static class AudioManager
	{
		private static readonly string soundPath = "Sounds/";
		private static Dictionary<string, SoundEffectInstance[]> soundLibraries;
		private static ContentManager content;

		public static float Volume { get; set; }

		public static void LoadSound(ContentManager content, string[] soundNames)
		{
			AudioManager.content = content;
			AudioManager.Volume = 0.5f;

			soundLibraries = new Dictionary<string, SoundEffectInstance[]>();

			foreach (var soundName in soundNames)
				soundLibraries.Add(soundName, new SoundEffectInstance[]
				{
					GetSound(soundName),
					GetSound(soundName),
					GetSound(soundName),
				} );
		}

		private static SoundEffectInstance GetSound(string fileName)
		{
			return content.Load<SoundEffect>(soundPath + fileName).CreateInstance();
		}

		/// <summary>
		/// Plays a sound by name.
		/// </summary>
		/// <param name="name">The name of the sound to play</param>
		/// <param name="isLooped">Indicates if the sound should loop</param>
		public static void PlaySound(string name, bool isLooped = false)
		{
			if (soundLibraries.ContainsKey(name))
			{
				var soundInstance = (from instance in soundLibraries[name]
										  where instance.State != SoundState.Playing
										  select instance).FirstOrDefault();

				if (soundInstance == null)
					return;

				soundInstance.IsLooped = isLooped;
				soundInstance.Volume = Volume;
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

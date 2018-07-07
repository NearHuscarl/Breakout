﻿using System;
using System.IO;
using System.Reflection;

namespace Breakout.Core.Utilities
{
	public static class ApplicationPath
	{
		private static string applicationName = Path.GetFileName(Assembly.GetEntryAssembly().GetName().Name);

		public static string BaseDirectory = AppDomain.CurrentDomain.BaseDirectory;

		/// <summary>
		/// Accessible to all users
		/// </summary>
		public static string CommonApplicationData = Path.Combine(
			Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
			applicationName);

		/// <summary>
		/// Accessible to the currently logged-in user only
		/// </summary>
		public static string ApplicationData = Path.Combine(
			Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
			applicationName);

		/// <summary>
		/// Path to game settings and data for each user
		/// </summary>
		public static string UserData = Path.Combine(ApplicationData, "Data");
	}
}

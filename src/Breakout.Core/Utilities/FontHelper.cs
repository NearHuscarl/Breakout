using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Core.Utilities
{
	internal static class FontHelper
	{
		/// <summary>
		/// Adds newline characters to a string so that it fits within a certain size.
		/// </summary>
		/// <param name="text">The text to be modified.</param>
		/// <param name="maxCharsPerLine">
		/// The maximum length of a single line of text.
		/// </param>
		/// <param name="maxLines">The maximum number of lines to draw.</param>
		/// <returns>The new string, with newline characters if needed.</returns>
		public static string BreakTextIntoLines(string text, int maxCharsPerLine, int maxLines)
		{
			if (maxLines <= 0)
			{
				throw new ArgumentOutOfRangeException("maxLines");
			}
			if (maxCharsPerLine <= 0)
			{
				throw new ArgumentOutOfRangeException("maxCharsPerLine");
			}

			// if the string is trivial, then this is really easy
			if (String.IsNullOrEmpty(text))
			{
				return String.Empty;
			}

			// if the text is short enough to fit on one line, then this is still easy
			if (text.Length < maxCharsPerLine)
			{
				return text;
			}

			// construct a new string with carriage returns
			StringBuilder stringBuilder = new StringBuilder(text);
			int currentLine = 0;
			int newLineIndex = 0;

			while ((text.Length - newLineIndex > maxCharsPerLine) && (currentLine < maxLines))
			{
				text.IndexOf(' ', 0);
				int nextIndex = newLineIndex;
				while ((nextIndex >= 0) && (nextIndex < maxCharsPerLine))
				{
					newLineIndex = nextIndex;
					nextIndex = text.IndexOf(' ', newLineIndex + 1);
				}
				stringBuilder.Replace(' ', '\n', newLineIndex, 1);
				currentLine++;
			}

			return stringBuilder.ToString();
		}
	}
}

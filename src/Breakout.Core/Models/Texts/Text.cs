using Breakout.Models.Bases;
using Microsoft.Xna.Framework;
using System;

namespace Breakout.Models.Texts
{
	public class Text : GameObject
	{
		public virtual string Content { get; set; }
		public string Prompt { get; set; } = "";

		/// Prompt + Content + Margin
		public string FullText
		{
			get
			{
				return " " + Prompt + Content + " ";
			}
		}

		public Text()
		{

		}

		public Text(int text, string prompt)
		{
			Content = text.ToString();
			Prompt = prompt;
			Position = new Vector2();
		}

		public Text(int text, string prompt, Vector2 position)
		{
			Content = text.ToString();
			Prompt = prompt;
			Position = position;
		}

		/// <summary>
		/// Take away an amount (health, score, live,...)
		/// </summary>
		/// <param name="amount"></param>
		public void Take(int amount)
		{
			Content = (Int32.Parse(Content) - amount).ToString();
		}

		/// <summary>
		/// Add an amount of numeric value
		/// </summary>
		/// <param name="amount"></param>
		public void Get(int amount)
		{
			Content = (Int32.Parse(Content) + amount).ToString();
		}

		#region Operator Overloading

		public static bool operator < (Text text1, Text text2)
		{
			int number1;
			int number2;

			if (Int32.TryParse(text1.Content, out number1) && Int32.TryParse(text2.Content, out number2))
			{
				if (number1 < number2)
					return true;
			}

			return false;
		}

		public static bool operator > (Text text1, Text text2)
		{
			int number1;
			int number2;

			if (Int32.TryParse(text1.Content, out number1) && Int32.TryParse(text2.Content, out number2))
			{
				if (number1 > number2)
					return true;
			}

			return false;
		}

		public static bool operator != (Text text1, int number2)
		{
			int number1;

			if (Int32.TryParse(text1.Content, out number1))
			{
				if (number1 != number2)
					return true;
			}

			return false;
		}

		public static bool operator == (Text text1, int number2)
		{
			if (text1 != number2)
				return false;

			return true;
		}

		public override bool Equals(Object obj)
		{
			Text text = obj as Text;

			if (text == null)
				return false;

			if (this == text)
				return true;

			return false;
		}

		#endregion

		public override int GetHashCode()
		{
			return Content.GetHashCode();
		}
	}
}

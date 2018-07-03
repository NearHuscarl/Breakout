namespace Breakout.Core.Models.Data
{
	public class Session : GameData
	{
		public static readonly string FullPath = System.IO.Path.Combine(Directory, "session.xml");

		public int CurrentLevel { get; set; }
		public int CurrentLives { get; set; }
		public int CurrentScore { get; set; }

		public static Session Default
		{
			get
			{
				return new Session()
				{
					CurrentLevel = 1,
					CurrentLives = 3,
					CurrentScore = 0,
				};
			}
		}
	}
}

namespace Breakout.Core.Models.Data
{
	public struct PlayerStats
	{
		public string Name { get; set; }
		public int Score { get; set; }
		public int Level { get; set; }
	}

	public struct HighScore
	{
		public PlayerStats[] Players { get; set; }
	}
}

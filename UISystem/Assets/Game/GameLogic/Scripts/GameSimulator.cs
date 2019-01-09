using UnityEngine;

namespace Shimmer.Game.GameLogic
{
	public class GameSimulator : MonoBehaviour
	{
		public GameStatsVariable GameStats;

		private void OnEnable()
		{
			GameStats stats = new GameStats();
			stats.MaxHeight = 0;
			GameStats.SetValue(stats);
		}

		private void Update()
		{
			GameStats stats = GameStats.GetValue();
			stats.MaxHeight++;
			GameStats.SetValue(stats);
		}
	}
}
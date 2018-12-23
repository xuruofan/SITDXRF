using Shimmer.Common.Variables;
using UnityEngine;

namespace Shimmer.Game.GameLogic
{
	[CreateAssetMenu(fileName = "V_GameStats_New", menuName = "Shimmer/Game/GameLogic/GameStats Variable")]
	public class GameStatsVariable : VariableOf<GameStats>
	{
		public int Score;
		public int MaxHeight;
		public int SparksCollected;
	}
}
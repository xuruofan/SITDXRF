using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shimmer.Game.GameLogic
{
	[CreateAssetMenu(fileName = "V_Game_NewGameResult", menuName = "Shimmer/Game/GameLogic/GameResult")]
	public class GameResult : ScriptableObject
	{
		public int Score;
		public int MaxHeight;
		public int SparksCollected;
	}
}
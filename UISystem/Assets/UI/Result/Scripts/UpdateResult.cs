using Shimmer.Game.GameLogic;
using UnityEngine;
using UnityEngine.UI;

namespace Shimmer.UI.Result
{
	public class UpdateResult : MonoBehaviour
	{
		public GameStatsVariable GameStats;
		public Text TextHeight;

		private void OnEnable()
		{
			TextHeight.text = GameStats.GetValue().MaxHeight.ToString();
		}
	}
}
using Shimmer.Common.Variables;
using UnityEngine;

namespace Shimmer.Game.GameLogic
{
	public class DifficultyCalculator : MonoBehaviour
	{
		[Header("Write")]
		[SerializeField]
		private IntReference Difficulty;
		[Header("Read")]
		[SerializeField]
		private FloatReference MaxHeightReached;

		private const int MAX_DIFFICULTY = 7;
		private const int EQUILIBRIUM = 300;

		private void OnEnable()
		{
			MaxHeightReached.Subscribe(Compute);
		}

		private void OnDisable()
		{
			MaxHeightReached.Unsubscribe(Compute);
		}

		private void Compute()
		{
			float height = MaxHeightReached.GetValue();
			int currentLevel = Mathf.CeilToInt(MAX_DIFFICULTY * height / (EQUILIBRIUM + height));
			Difficulty.SetValue(currentLevel);
		}
	}
}
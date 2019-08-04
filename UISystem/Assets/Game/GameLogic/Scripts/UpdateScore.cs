using Shimmer.Common.Variables;
using UnityEngine;

namespace Shimmer.Game.GameLogic
{
	public class UpdateScore : MonoBehaviour
	{
		[Header("Read")]
		public FloatReference MaxHeight;
		public IntReference SparksCollected;
		[Header("Write")]
		public IntReference Score;

		private void OnEnable()
		{
			MaxHeight.Subscribe(ComputeScore);
			SparksCollected.Subscribe(ComputeScore);

			Score.SetValue(0);
		}

		private void OnDisable()
		{
			MaxHeight.Unsubscribe(ComputeScore);
			SparksCollected.Unsubscribe(ComputeScore);
		}

		private void ComputeScore()
		{
			int height = Mathf.CeilToInt(MaxHeight.GetValue());
			int numSparks = SparksCollected.GetValue();

			int score = height + numSparks;

			Score.SetValue(score);
		}
	}
}
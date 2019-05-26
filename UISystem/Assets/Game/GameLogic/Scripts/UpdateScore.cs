using Shimmer.Common.Variables;
using UnityEngine;

namespace Shimmer.Game.GameLogic
{
	public class UpdateScore : MonoBehaviour
	{
		public FloatReference MaxHeight;
		public IntReference Score;

		private void OnEnable()
		{
			MaxHeight.Subscribe(ComputeScore);

			Score.SetValue(0);
		}

		private void OnDisable()
		{
			MaxHeight.Unsubscribe(ComputeScore);
		}

		private void ComputeScore()
		{
			int height = Mathf.CeilToInt(MaxHeight.GetValue());

			Score.SetValue(height);
		}
	}
}
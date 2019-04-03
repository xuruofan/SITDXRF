using System;
using Shimmer.Common.Variables;
using UnityEngine;
using UnityEngine.Assertions;

namespace Shimmer.Game.World.Segments
{
	public class SegmentManager : MonoBehaviour
	{
		public IntReference CurrentDifficulty;
		public SegmentDataVariable AllSegments;
		public PrefabListVariable SegmentsForNow;

		private void Awake()
		{
			Assert.IsNotNull(AllSegments);
			Assert.IsNotNull(SegmentsForNow);

			SetupSegments();
		}

		private void OnEnable()
		{
			CurrentDifficulty.Subscribe(SetupSegments);
		}

		private void OnDisable()
		{
			CurrentDifficulty.Unsubscribe(SetupSegments);
		}

		private void SetupSegments()
		{
			var levels = AllSegments.GetValue().Levels;
			int numLevels = levels.Length;
			int difficulty = CurrentDifficulty.GetValue();

			if (difficulty < numLevels)
			{
				var segments = levels[difficulty].GetValue();
				SegmentsForNow.SetValue(segments);
			}
		}
	}
}
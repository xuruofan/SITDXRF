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

		private int m_CurrentLevel;

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

			if (difficulty > m_CurrentLevel && difficulty <= numLevels)
			{
				var currentSegments = SegmentsForNow.GetValue().Items;
				var newSegments = levels[difficulty-1].GetValue().Items;

				var newItems = new GameObject[currentSegments.Length + newSegments.Length];
				currentSegments.CopyTo(newItems, 0);
				newSegments.CopyTo(newItems, currentSegments.Length);

				SegmentsForNow.GetValue().Items = newItems;
				SegmentsForNow.SetValue(SegmentsForNow.GetValue());

				m_CurrentLevel = difficulty;
			}
		}
	}
}
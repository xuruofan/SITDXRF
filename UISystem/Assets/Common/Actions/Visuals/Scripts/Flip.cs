using Shimmer.Common.Variables;
using System;
using UnityEngine;
using UnityEngine.Assertions;

namespace Shimmer.Common.Actions.Visuals
{
	[Serializable]
	public class Flip : Action
	{
		public GameObject Object;
		public bool Not;
		public BoolReference Flipped;

		public static string MenuName
		{
			get
			{
				return "Visuals/Flip";
			}
		}

		public override void Execute()
		{
			Assert.IsNotNull(Object);

			bool flipped = Flipped.GetValue();

			if (Not)
			{
				flipped = !flipped;
			}

			int flipInt = flipped ? -1 : 1;

			Vector2 scale = Object.transform.localScale;
			scale.x = flipInt * Mathf.Abs(Object.transform.localScale.x);

			Object.transform.localScale = scale;
		}
	}

}
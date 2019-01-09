using System;
using UnityEngine;
using UnityEngine.Assertions;

namespace Shimmer.Common.Actions.Actions
{
	[Serializable]
	public class Pause : Action
	{
		public bool SetPause;

		public static string MenuName
		{
			get
			{
				return "Actions/Pause";
			}
		}

		public override void Execute()
		{
			Time.timeScale = SetPause ? 0.0f : 1.0f;
		}
	}

}
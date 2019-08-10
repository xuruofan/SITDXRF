using System;
using UnityEngine;
using UnityEngine.Assertions;

namespace Shimmer.Common.Actions.Actions
{
	[Serializable]
	public class Invoke : Action
	{
		public ActionListVariable Actions;

		public static string MenuName
		{
			get
			{
				return "Actions/Invoke";
			}
		}

		public override void Execute(MonoBehaviour _behaviour)
		{
			Assert.IsNotNull(Actions);

			Actions.GetValue().Execute(_behaviour);
		}
	}

}
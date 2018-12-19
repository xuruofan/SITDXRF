using System;
using UnityEngine.Assertions;

namespace Shimmer.Common.Actions.Execution
{
	[Serializable]
	public class Invoke : Action
	{
		public ActionListVariable Actions;

		public static string MenuName
		{
			get
			{
				return "Execution/Invoke";
			}
		}

		public override void Execute()
		{
			Assert.IsNotNull(Actions);

			Actions.GetValue().Execute();
		}
	}

}
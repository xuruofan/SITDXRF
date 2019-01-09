using System;
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

		public override void Execute()
		{
			Assert.IsNotNull(Actions);

			Actions.GetValue().Execute();
		}
	}

}
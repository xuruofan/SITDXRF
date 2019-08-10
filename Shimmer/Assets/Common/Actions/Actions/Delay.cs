using Shimmer.Common.Variables;
using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Assertions;

namespace Shimmer.Common.Actions.Actions
{
	[Serializable]
	public class Delay : Action
	{
		public ActionListVariable Actions;
		public FloatReference DelayInSeconds;

		public static string MenuName
		{
			get
			{
				return "Actions/Delay";
			}
		}

		public override void Execute(MonoBehaviour _behaviour)
		{
			Assert.IsNotNull(Actions, "Please set a ActionList to delay");

			_behaviour.StartCoroutine(DelayAction(_behaviour));
		}

		IEnumerator DelayAction(MonoBehaviour _behaviour)
		{
			yield return new WaitForSeconds(DelayInSeconds.GetValue());

			Actions.GetValue().Execute(_behaviour);
		}
	}

}
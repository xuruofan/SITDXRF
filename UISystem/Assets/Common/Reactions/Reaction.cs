using Shimmer.Common.Actions;
using Shimmer.Common.Conditions;
using UnityEngine;

namespace Shimmer.Common.Reactions
{
	public class Reaction : MonoBehaviour
	{
		public ConditionList Conditions;
		public ActionList Actions;

		private void OnEnable()
		{
			Conditions.Enable(OnConditionSatisfied);
		}

		private void OnDisable()
		{
			Conditions.Disable();
		}

		private void OnConditionSatisfied(bool _satisfied)
		{
			if (_satisfied)
			{
				Actions.Execute();
			}
		}
	}
}

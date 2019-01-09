using Shimmer.Common.Actions;
using Shimmer.Common.Conditions;
using UnityEngine;

namespace Shimmer.Common.Reactions
{
	public class Reaction : MonoBehaviour
	{
		public ConditionList If;
		public ActionList Do;
		public ActionList Else;

		private void OnEnable()
		{
			If.Enable(OnStateChanged);
		}

		private void OnDisable()
		{
			If.Disable();
		}

		private void OnStateChanged()
		{
			if (If.Evaluate())
			{
				Do.Execute();
			}
			else
			{
				Else.Execute();
			}
		}
	}
}

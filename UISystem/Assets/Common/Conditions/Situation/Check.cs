using System;

namespace Shimmer.Common.Conditions.Situation
{
	[Serializable]
	public class Check : Condition
	{
		public static string MenuName
		{
			get
			{
				return "Situation/Check";
			}
		}

		public ConditionListVariable ConditionList;
		private Callback m_Callback;

		public override bool Evaluate()
		{
			if (ConditionList != null)
			{
				ConditionList.GetValue().Enable(OnConditionSatisfied);
			}
			return false;
		}

		public override void Subscribe(Callback _callback)
		{
			ConditionList.GetValue().Enable(_callback);
		}

		public override void Unsubscribe(Callback _callback)
		{
			m_Callback = null;
		}

		private void OnConditionSatisfied(bool _satisfied)
		{
			
		}
	}
}
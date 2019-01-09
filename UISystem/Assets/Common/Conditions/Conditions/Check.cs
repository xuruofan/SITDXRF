using Shimmer.Common.Variables;
using System;

namespace Shimmer.Common.Conditions.Conditions
{
	[Serializable]
	public class Check : Condition
	{
		public static string MenuName
		{
			get
			{
				return "Conditions/Check";
			}
		}

		public ConditionListVariable ConditionList;

		
		public override bool Evaluate()
		{
			return ConditionList.GetValue().Evaluate();
		}

		public override void Subscribe(Callback _callback)
		{
			ConditionList.GetValue().Enable(_callback);
		}

		public override void Unsubscribe(Callback _callback)
		{
			ConditionList.GetValue().Disable();
		}
	}
}
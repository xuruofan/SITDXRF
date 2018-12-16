using System;
using Shimmer.Tools;

namespace Shimmer.Common.Conditions
{
	[Serializable]
	public class ConditionOptions : Options<Condition>
	{
		// Event
		public Situation.OnEnable[] m_Situation_OnEnable;
		// Variable
		public Variable.Changed[] m_Variable_Changed;
	}
}
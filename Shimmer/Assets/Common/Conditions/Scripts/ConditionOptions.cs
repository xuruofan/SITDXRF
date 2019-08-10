using System;
using Shimmer.Tools;

namespace Shimmer.Common.Conditions
{
	[Serializable]
	public class ConditionOptions : Options<Condition>
	{
		// Event
		public Conditions.Check[] m_Conditions_Check;
		public Conditions.OnEnable[] m_Conditions_OnEnable;
		// Variable
		public Variables.Changed[] m_Variable_Changed;
		public Variables.TestString[] m_Variable_TestString;
		public Variables.TestBool[] m_Variable_TestBool;
	}
}
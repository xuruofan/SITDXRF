using Shimmer.Tools;
using System;

namespace Shimmer.Common.Actions
{
	[Serializable]
	public class ActionOptions : Options<Action>
	{
		// Variable
		public Variable.SetInt[] m_Variable_SetInt;
		// Text
		public Text.PrintLog[] m_Text_PrintLog;
	}
}
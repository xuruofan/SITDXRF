using Shimmer.Tools;
using System;

namespace Shimmer.Common.Actions
{
	[Serializable]
	public class ActionOptions : Options<Action>
	{
		// Execution
		public Execution.Invoke[] m_Execution_Invoke;
		// Variable
		public Variable.SetInt[] m_Variable_SetInt;
		// Text
		public Text.SetString[] m_Text_SetString;
		public Text.PrintLog[] m_Text_PrintLog;
		//UI
		public UI.GoTo[] m_UI_GoTo;
		public UI.GoBack[] m_UI_GoBack;
	}
}
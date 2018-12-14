using Shimmer.Tools;
using System;

namespace Shimmer.Common.Actions
{
	[Serializable]
	public class ActionOptions : Options<Action>
	{
		public Variable.SetInt[] m_Variable_SetInt;
	}
}
using Shimmer.Common.Variables;
using System;

namespace Shimmer.Common.Conditions.Situation
{
	[Serializable]
	public class OnEnable : Condition
	{
		public static string MenuName
		{
			get
			{
				return "Situation/OnEnable";
			}
		}

		private bool m_Enabled = false;

		public override bool Evaluate()
		{
			if (m_Enabled)
			{
				m_Enabled = false;
				return true;
			}
			return false;
		}

		public override void Subscribe(Callback _callback)
		{
			m_Enabled = true;
			_callback();
		}

		public override void Unsubscribe(Callback _callback)
		{
			m_Enabled = false;
		}
	}
}
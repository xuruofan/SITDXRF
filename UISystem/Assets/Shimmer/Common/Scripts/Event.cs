using System.Collections.Generic;

namespace Shimmer.Common
{
	public delegate void Callback();

	public class Event
	{
		private Dictionary<Callback, int> m_listeners = new Dictionary<Callback, int>();
		private bool m_isRaised = false;

		public void Raise()
		{

		}

		public void Subscribe(Callback _callback)
		{

		}

		public void Unsubscribe(Callback callback)
		{

		}
	}
}
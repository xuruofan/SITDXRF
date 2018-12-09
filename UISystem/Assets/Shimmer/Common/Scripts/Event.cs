using System.Collections.Generic;
using UnityEngine.Assertions;

namespace Shimmer.Common
{
	public delegate void Callback();

	public class Event
	{
		private Dictionary<Callback, int> m_listeners = new Dictionary<Callback, int>();
		private bool m_isRaised = false;

		public void Raise()
		{
			Assert.IsFalse(m_isRaised, "Event loop!");

			m_isRaised = true;
			foreach(var callback in m_listeners)
			{
				callback.Key.Invoke();
			}
			m_isRaised = false;
		}

		public bool IsRaised()
		{
			return m_isRaised;
		}

		public void Subscribe(Callback _callback)
		{
			Assert.IsFalse(m_listeners.ContainsKey(_callback), "Already subscribed!");

			m_listeners[_callback] = 1;
		}

		public void Unsubscribe(Callback _callback)
		{
			Assert.IsTrue(m_listeners.ContainsKey(_callback), "Callback not found, already unsubscribed?");

			m_listeners.Remove(_callback);
		}
	}
}
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Shimmer.Common.Variables
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
            foreach (var callback in m_listeners.Keys)
            {
                try
                {
                    callback();
                }
                catch (Exception e)
                {
                    Debug.LogError($"Exception in Event: {e.Message}");
                }
            }
            m_isRaised = false;
        }

        public bool IsRaised()
        {
            return m_isRaised;
        }

        public void Subscribe(Callback _callback)
        {
            Assert.IsFalse(m_isRaised, "Subscribe when Raised!");

            int count;
            if (m_listeners.TryGetValue(_callback, out count))
            {
                m_listeners[_callback] = count + 1;
            }
            else
            {
                m_listeners[_callback] = 1;
            }
        }

        public void Unsubscribe(Callback _callback)
        {
            Assert.IsFalse(m_isRaised, "Unsubscribed when Raised");

            int count;
            bool found = m_listeners.TryGetValue(_callback, out count);
            Assert.IsTrue(found, "Callback not found, already unsubscribed?");
            Assert.IsTrue(count > 0);

            if (count == 1)
            {
                m_listeners.Remove(_callback);
            }
            else
            {
                m_listeners[_callback] = count - 1;
            }
        }

		public bool HasSubscribed(Callback _callback)
		{
			int count;
			bool found = m_listeners.TryGetValue(_callback, out count);

			return found && count > 0;
		}
    }
}
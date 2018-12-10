using UnityEngine;

namespace Shimmer.Common.Variables
{
    public class VariableOf<T> : ResettableScriptableObject, IVariable<T>
    {
        [SerializeField]
        private T m_value;

        public Event Changed { get; } = new Event();

        public T GetValue()
        {
            return m_value;
        }

        public void SetValue(T _value)
        {
            m_value = _value;
            Changed.Raise();
        }

        public void Subscribe(Callback _callback)
        {
            Changed.Subscribe(_callback);
        }

        public void Unsubscribe(Callback _callback)
        {
            Changed.Unsubscribe(_callback);
        }
    }
}
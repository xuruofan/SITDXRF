using UnityEngine;

namespace Shimmer.Common.Variables
{
	public abstract class Variable : ResettableScriptableObject, IVariable
	{
		public Event Changed { get; } = new Event();

		public void Subscribe(Callback _callback)
		{
			Changed.Subscribe(_callback);
		}

		public void Unsubscribe(Callback _callback)
		{
			Changed.Unsubscribe(_callback);
		}
	}

	public abstract class VariableOf<T> : Variable, IVariableOf<T>
	{
		[SerializeField]
		protected T m_Value;

		public virtual T GetValue()
		{
			return m_Value;
		}

		public void SetValue(T _value)
		{
			m_Value = _value;
			Changed.Raise();
		}
	}
}
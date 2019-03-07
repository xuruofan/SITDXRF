using System;
using UnityEngine;

namespace Shimmer.Common.Variables
{
	[Serializable]
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

		public bool HasSubscribed(Callback _callback)
		{
			return Changed.HasSubscribed(_callback);
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

		public virtual void SetValue(T _value)
		{
			m_Value = _value;
			Changed.Raise();
		}
	}
}
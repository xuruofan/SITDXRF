using UnityEngine;

namespace Shimmer.Common.Variables
{
	public abstract class Enum : ScriptableObject
	{
	}

	public abstract class EnumOf <T> : Enum, IValue<T>
	{
		[SerializeField]
		protected T m_Value;

		public T GetValue()
		{
			return m_Value;
		}
	}
}
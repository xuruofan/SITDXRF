using UnityEngine;

namespace Shimmer.Common.Variables
{
	public abstract class EnumOf <T> : ScriptableObject, IValue<T>
	{
		[SerializeField]
		protected T m_Value;

		public T GetValue()
		{
			return m_Value;
		}
	}
}
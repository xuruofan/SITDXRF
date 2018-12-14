using System.Collections;
using UnityEngine;

namespace Shimmer.Tools
{
    public abstract class OptionsBase { }

    public class Options<T> : OptionsBase, ISerializationCallbackReceiver
        where T : class
    {
        private T m_Value = null;

        public static implicit operator T(Options<T> _option)
        {
            return _option != null ? _option.m_Value : null;
        }

        private object FindValue()
        {
            foreach (var field in GetType().GetFields())
            {
                var list = field.GetValue(this) as IList;
                if (list != null && list.Count > 0)
                {
                    return list[0];
                }
            }
            return null;
        }

        public void OnBeforeSerialize()
        {
        }

        public void OnAfterDeserialize()
        {
            m_Value = FindValue() as T;
        }
    }
}


using UnityEngine.Assertions;

namespace Shimmer.Common.Variables
{
	public enum ReferenceSelection
	{
		Constant,
		Variable
	}

	public abstract class Reference
	{
		public ReferenceSelection Selection = ReferenceSelection.Constant;

		public bool IsContant
		{
			get
			{
				return Selection == ReferenceSelection.Constant;
			}
		}

		public Event Changed { get; } = new Event();
	}

	public class ReferenceOf<T, TVariable> : Reference, IVariable<T>
		where TVariable : class, IVariable<T>
	{
		public T Constant;
		public TVariable Variable;

		public T GetValue()
		{
			switch (Selection)
			{
				case ReferenceSelection.Constant:
					return Constant;
				case ReferenceSelection.Variable:
					return Variable == null ? default(T) : Variable.GetValue();
				default:
					return default(T);
			}
		}

		public void SetValue(T _value)
		{
			switch (Selection)
			{
				case ReferenceSelection.Constant:
					Constant = _value;
					Changed.Raise();
					break;
				case ReferenceSelection.Variable:
					if (Variable != null)
					{
						Variable.SetValue(_value);
					}
					break;
			}
		}

		public void Subscribe(Callback _callback)
		{
			switch (Selection)
			{
				case ReferenceSelection.Constant:
					Changed.Subscribe(_callback);
					break;
				case ReferenceSelection.Variable:
					Assert.IsNotNull(Variable, "Reference is missing a Variable!");
					Variable.Changed.Subscribe(_callback);
					break;
			}
		}

		public void Unsubscribe(Callback _callback)
		{
			switch (Selection)
			{
				case ReferenceSelection.Constant:
					Changed.Unsubscribe(_callback);
					break;
				case ReferenceSelection.Variable:
					Assert.IsNotNull(Variable, "Reference is missing a Variable!");
					Variable.Changed.Unsubscribe(_callback);
					break;
			}
		}
	}
}
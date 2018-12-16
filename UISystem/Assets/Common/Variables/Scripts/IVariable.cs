namespace Shimmer.Common.Variables
{
	public interface IValue<T>
	{
		T GetValue();
	}

	public interface IVariable
	{
		Event Changed { get; }
		void Subscribe(Callback _callback);
		void Unsubscribe(Callback _callback);
	}

    public interface IVariableOf<T> : IVariable, IValue<T>
    {
        void SetValue(T _value);
    }
}
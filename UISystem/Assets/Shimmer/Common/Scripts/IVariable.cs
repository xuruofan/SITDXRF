namespace Shimmer.Common
{
	public interface IVariable<T>
	{
		Event Changed { get; }

		T GetValue();
		void SetValue(T _value);
		void Subscribe(Callback _callback);
		void Unsubscribe(Callback _callback);
		void Raise();
	}
}
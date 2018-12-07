namespace Shimmer.Common
{
	public interface IVariable<T>
	{
		Event Changed { get; }

		T GetValue();
		void SetValue(T _value);
		void Subscribe();
		void Unsubscribe();
		void Raise();
	}
}
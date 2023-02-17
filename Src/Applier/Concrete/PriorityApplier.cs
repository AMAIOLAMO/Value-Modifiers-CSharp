namespace CxUtils.ValueModifiers;

public class PriorityApplier<T> : IApplier<T>
{
	public T ApplyTo( T value ) =>
		throw new NotImplementedException();

	public void Clear() =>
		throw new NotImplementedException();

	public int Count { get; }
}

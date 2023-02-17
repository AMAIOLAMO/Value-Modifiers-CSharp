namespace CxUtils.ValueModifiers;

// TODO: require unit tests for this applier
// TODO: require documentation
public class PriorityApplier<T> : IApplier<T>
{
	public T ApplyTo( T value )
	{
		T resultValue = value;

		EnsureSorted();

		foreach ( PriorityModifier<T> priorityModifier in _priorityModifiers )
			resultValue = priorityModifier.ApplyTo( resultValue );

		return resultValue;
	}

	public void Clear()
	{
		_priorityModifiers.Clear();
		_sorted = true;
	}

	public int Count { get; }

	/// <summary>
	///     Sorts the modifiers
	/// </summary>
	public void Sort() =>
		EnsureSorted();

	public void Add( PriorityModifier<T> modifier )
	{
		_priorityModifiers.Add( modifier );
		OnItemsUpdated();
	}

	public void RemoveAt( int index )
	{
		_priorityModifiers.RemoveAt( index );
		OnItemsUpdated();
	}

	readonly List<PriorityModifier<T>> _priorityModifiers = new();

	bool _sorted;

	void OnItemsUpdated()
	{
		switch ( _priorityModifiers.Count )
		{
			case 0:
			case 1:
				_sorted = true;

				break;
		}
	}

	void EnsureSorted()
	{
		if ( _sorted )
			return;

		_priorityModifiers.Sort();
		_sorted = true;
	}
}

namespace CxUtils.ValueModifiers;

/// <summary>
///     a concrete implementation of a modification applier which applies modifications without order
/// </summary>
public class KeyApplier<T> : IApplier<T>
{
	public T ApplyTo( T value )
	{
		T resultValue = value;

		foreach ( KeyValuePair<ModifierHandle, IValueModifier<T>> pair in _modifiers )
			resultValue = pair.Value.ApplyTo( resultValue );

		return resultValue;
	}

	public int Count { get; }


	public ModifierHandle Add( IValueModifier<T> modifier )
	{
		var newHandle = ModifierHandle.New();

		_modifiers.Add( newHandle, modifier );

		return newHandle;
	}

	public void Remove( ModifierHandle handle ) =>
		_modifiers.Remove( handle );

	public List<ModifierHandle> AddRange( IEnumerable<IValueModifier<T>> modifiers )
	{
		List<ModifierHandle> handles = new();

		foreach ( IValueModifier<T> modifier in modifiers )
			handles.Add( Add( modifier ) );

		return handles;
	}

	public List<ModifierHandle> AddMultiple( params IValueModifier<T>[] modifiers )
	{
		List<ModifierHandle> handles = new();

		foreach ( IValueModifier<T> modifier in modifiers )
			handles.Add( Add( modifier ) );

		return handles;
	}

	public void Clear() =>
		_modifiers.Clear();


	// uses dictionary internally
	readonly Dictionary<ModifierHandle, IValueModifier<T>> _modifiers = new();
}

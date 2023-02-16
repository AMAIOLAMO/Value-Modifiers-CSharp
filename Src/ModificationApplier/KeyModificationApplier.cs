namespace CxUtils.ValueModifiers;

/// <summary>
///     a concrete implementation of a modification applier which applies modifications without order
/// </summary>
public class KeyModificationApplier<T> : IModificationApplier<T>
{
	public T ApplyTo( T value )
	{
		T resultValue = value;

		foreach ( KeyValuePair<ModifierHandle, IValueModifier<T>> pair in _modifiers )
			resultValue = pair.Value.ApplyTo( resultValue );

		return resultValue;
	}

	public int ModifierCount { get; }


	public ModifierHandle AddModifier( IValueModifier<T> modifier )
	{
		var newHandle = ModifierHandle.New();

		_modifiers.Add( newHandle, modifier );

		return newHandle;
	}

	public void RemoveModifier( ModifierHandle handle ) =>
		_modifiers.Remove( handle );

	public List<ModifierHandle> AddModifiers( IEnumerable<IValueModifier<T>> modifiers )
	{
		List<ModifierHandle> handles = new();

		foreach ( IValueModifier<T> modifier in modifiers )
			handles.Add( AddModifier( modifier ) );

		return handles;
	}

	public List<ModifierHandle> AddModifiers( params IValueModifier<T>[] modifiers )
	{
		List<ModifierHandle> handles = new();

		foreach ( IValueModifier<T> modifier in modifiers )
			handles.Add( AddModifier( modifier ) );

		return handles;
	}

	public void ClearModifiers() =>
		_modifiers.Clear();


	// uses dictionary internally
	readonly Dictionary<ModifierHandle, IValueModifier<T>> _modifiers = new();
}

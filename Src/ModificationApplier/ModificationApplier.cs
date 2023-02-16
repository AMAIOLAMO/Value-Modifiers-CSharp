namespace CxUtils.ValueModifiers;

/// <summary>
///     A Concrete Implementation of a modification applier which applies modifications in the order which where they are
///     added, similarly like a list
/// </summary>
public class ModificationApplier<T> : IModificationApplier<T>
{
	public T ApplyTo( T value )
	{
		T resultValue = value;

		foreach ( IValueModifier<T> modifier in _modifiers )
			resultValue = modifier.ApplyTo( resultValue );

		return resultValue;
	}

	public int ModifierCount => _modifiers.Count;

	public void AddModifier( IValueModifier<T> modifier ) =>
		_modifiers.Add( modifier );

	public void RemoveModifierAt( int index ) =>
		_modifiers.RemoveAt( index );

	public void AddModifiers( IEnumerable<IValueModifier<T>> modifiers ) =>
		_modifiers.AddRange( modifiers );

	public void AddModifiers( params IValueModifier<T>[] modifiers ) =>
		_modifiers.AddRange( modifiers );

	public void ClearModifiers() =>
		_modifiers.Clear();

	readonly List<IValueModifier<T>> _modifiers = new();
}

namespace CxUtils.ValueModifiers;

/// <summary>
///     A concrete implementation of an ordered modifier applier that handles a base value
/// </summary>
public class ModifiedValue<T> : IModifiedValue<T>
{
	public ModifiedValue( T baseValue )
	{
		BaseValue = baseValue;
		_modificationApplier = new ModificationApplier<T>();
	}

	public T CalculateValue() =>
		_modificationApplier.ApplyTo( BaseValue );

	public T BaseValue { get; set; }

	/// <summary>
	///     Applies all of the modifiers to the base
	/// </summary>
	public void ApplyToBaseValue() =>
		BaseValue = CalculateValue();

	public void AddModifier( IValueModifier<T> modifier ) =>
		_modificationApplier.AddModifier( modifier );

	public void RemoveModifierAt( int index ) =>
		_modificationApplier.RemoveModifierAt( index );

	/// <summary>
	///     Clears all modifiers from this modified value
	/// </summary>
	public void Clear() =>
		_modificationApplier.Clear();

	readonly ModificationApplier<T> _modificationApplier;
}

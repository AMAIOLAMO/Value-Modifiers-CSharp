namespace CxUtils.ValueModifiers;

/// <summary>
///     A concrete implementation of a unordered modifier applier that handles a base value
/// </summary>
public class KeyModifiedValue<T> : IModifiedValue<T>
{
	public KeyModifiedValue( T baseValue )
	{
		BaseValue = baseValue;
		_modificationApplier = new KeyModificationApplier<T>();
	}

	public T CalculateValue() =>
		_modificationApplier.ApplyTo( BaseValue );

	public T BaseValue { get; set; }

	public void ApplyToBaseValue() =>
		BaseValue = CalculateValue();

	public ModifierHandle AddModifier( IValueModifier<T> modifier ) =>
		_modificationApplier.AddModifier( modifier );

	public void RemoveModifier( ModifierHandle handle ) =>
		_modificationApplier.RemoveModifier( handle );

	public void Clear() =>
		_modificationApplier.Clear();

	readonly KeyModificationApplier<T> _modificationApplier;
}

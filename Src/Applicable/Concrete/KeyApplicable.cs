namespace CxUtils.ValueModifiers;

/// <summary>
///     A concrete implementation of a unordered modifier applier that handles a base value
/// </summary>
public class KeyApplicable<T> : IApplicable<T>
{
	public KeyApplicable( T baseValue )
	{
		BaseValue = baseValue;
		_applier = new KeyApplier<T>();
	}

	public T CalculateApplied() =>
		_applier.ApplyTo( BaseValue );

	public T BaseValue { get; set; }

	public void ApplyToBaseValue() =>
		BaseValue = CalculateApplied();

	public ModifierHandle AddModifier( IValueModifier<T> modifier ) =>
		_applier.Add( modifier );

	public void RemoveModifier( ModifierHandle handle ) =>
		_applier.Remove( handle );

	public void Clear() =>
		_applier.Clear();

	readonly KeyApplier<T> _applier;
}

namespace CxUtils.ValueModifiers;

/// <summary>
///     A concrete implementation of an ordered modifier applier that handles a base value
/// </summary>
public class Applicable<T> : IApplicable<T>
{
	public Applicable( T baseValue )
	{
		BaseValue = baseValue;
		_applier = new Applier<T>();
	}

	public T CalculateApplied() =>
		_applier.ApplyTo( BaseValue );

	public T BaseValue { get; set; }

	/// <summary>
	///     Applies all of the modifiers to the base
	/// </summary>
	public void ApplyToBaseValue() =>
		BaseValue = CalculateApplied();

	public void AddModifier( IValueModifier<T> modifier ) =>
		_applier.AddModifier( modifier );

	public void RemoveModifierAt( int index ) =>
		_applier.RemoveAt( index );

	/// <summary>
	///     Clears all modifiers from this modified value
	/// </summary>
	public void Clear() =>
		_applier.Clear();

	readonly Applier<T> _applier;
}

namespace CxUtils.ValueModifiers;

/// <summary>
///     A concrete implementation of an ordered modifier applier that handles a base value
/// </summary>
public class OrderedModifiedValue<T> : IModifiedValue<T>
{
	public OrderedModifiedValue( T baseValue ) : this( baseValue, new OrderedModificationApplier<T>() )
	{
	}

	public OrderedModifiedValue( T baseValue, IOrderedModificationApplier<T> modificationApplier )
	{
		BaseValue = baseValue;
		_modificationApplier = modificationApplier;
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

	public void RemoveModifierAt( int index )
	{
		_modificationApplier.RemoveModifierAt( index );
	}

	readonly IOrderedModificationApplier<T> _modificationApplier;
}

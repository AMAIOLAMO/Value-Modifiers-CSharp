namespace CxUtils.ValueModifiers;

/// <summary>
///     A concrete implementation of a unordered modifier applier that handles a base value
/// </summary>
public class UnOrderedModifiedValue<T> : IModifiedValue<T>
{
	public UnOrderedModifiedValue( T baseValue ) : this( baseValue, new UnorderedModificationApplier<T>() )
	{
	}

	public UnOrderedModifiedValue( T baseValue, IUnorderedModificationApplier<T> modificationApplier )
	{
		BaseValue = baseValue;
		_modificationApplier = modificationApplier;
	}

	public T CalculateValue() =>
		_modificationApplier.ApplyTo( BaseValue );

	public T BaseValue { get; set; }

	public void ApplyToBaseValue() =>
		BaseValue = CalculateValue();

	public ModifierHandle AddModifier( IValueModifier<T> modifier ) =>
		_modificationApplier.AddModifier( modifier );

	public void RemoveModifier( ModifierHandle handle )
	{
		_modificationApplier.RemoveModifier( handle );
	}

	readonly IUnorderedModificationApplier<T> _modificationApplier;
}

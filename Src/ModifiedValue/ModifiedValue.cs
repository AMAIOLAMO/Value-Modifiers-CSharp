using System.Diagnostics.CodeAnalysis;

namespace CxUtils.ValueModifiers;

public class ModifiedValue<T> : IModifiedValue<T>
{
	public ModifiedValue( T baseValue = default ) : this( baseValue, new ModificationApplier<T>() )
	{
	}

	public ModifiedValue( T baseValue, [NotNull] IModificationApplier<T> modificationApplier )
	{
		BaseValue = baseValue;
		_modificationApplier = modificationApplier;
	}

	public T CalculateValue() =>
		_modificationApplier.Apply( BaseValue );

	public ModifierHandle AddModifier( IValueModifier<T> modifier ) =>
		_modificationApplier.AddModifier( modifier );

	public void RemoveModifier( ModifierHandle handle )
	{
		_modificationApplier.RemoveModifier( handle );
	}

	public T BaseValue { get; set; }

	readonly IModificationApplier<T> _modificationApplier;
}

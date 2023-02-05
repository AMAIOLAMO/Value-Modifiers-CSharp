namespace CxUtils.ValueModifiers;


/// <summary>
/// represents a base value that could be modified
/// </summary>
public interface IModifiedValue<T>
{
	T CalculateValue();

	/// <summary>
	/// Applies the given <paramref name="modifier"/> to the <see cref="BaseValue"/>
	/// </summary>
	void ApplyToBase(IValueModifier<T> modifier );
	
	/// <summary>
	/// Adds the given <paramref name="modifier"/> to the modifier applier of this value
	/// </summary>
	ModifierHandle AddModifier( IValueModifier<T> modifier );

	/// <summary>
	/// Removes a modifier from the modifier applier of this value using the given <paramref name="handle"/>
	/// </summary>
	void RemoveModifier( ModifierHandle handle );
	
	/// <summary>
	/// The absolute base value (unmodified value)
	/// </summary>
	T BaseValue { get; }
}

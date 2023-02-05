namespace CxUtils.ValueModifiers;

/// <summary>
/// Represents a list of modifiers that could be applied on a base / unmodified value
/// </summary>
public interface IModificationApplier<T>
{
	/// <summary>
	/// Applies all the modifiers from this applier to the <paramref name="value"/>
	/// </summary>
	T Apply( T value );

	/// <summary>
	/// Adds the given <paramref name="modifier"/> to this applier
	/// </summary>
	ModifierHandle AddModifier( IValueModifier<T> modifier );

	/// <summary>
	/// Removes a modifier from this applier using the given <paramref name="handle"/>
	/// </summary>
	void RemoveModifier( ModifierHandle handle );
}

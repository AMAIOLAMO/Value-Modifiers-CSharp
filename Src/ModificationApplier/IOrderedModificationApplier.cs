namespace CxUtils.ValueModifiers;

public interface IOrderedModificationApplier<TValue> : IModificationApplier<TValue>
{
	/// <summary>
	///     Adds the given <paramref name="modifier" /> to this applier
	/// </summary>
	void AddModifier( IValueModifier<TValue> modifier );

	/// <summary>
	///     Removes a modifier from this applier using the given <paramref name="index" />
	/// </summary>
	void RemoveModifierAt( int index );
}

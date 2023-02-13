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

	/// <summary>
	///     Adds the given <paramref name="modifiers" /> to this applier
	/// </summary>
	void AddModifiers( IEnumerable<IValueModifier<TValue>> modifiers );

	/// <summary>
	///     Adds the given <paramref name="modifiers" /> to this applier
	/// </summary>
	void AddModifiers( params IValueModifier<TValue>[] modifiers );
}

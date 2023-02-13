namespace CxUtils.ValueModifiers;

public interface IUnorderedModificationApplier<TValue> : IModificationApplier<TValue>
{
	/// <summary>
	///     Adds the given <paramref name="modifier" /> to this applier
	/// </summary>
	ModifierHandle AddModifier( IValueModifier<TValue> modifier );

	/// <summary>
	///     Removes a modifier from this applier using the given <paramref name="handle" />
	/// </summary>
	void RemoveModifier( ModifierHandle handle );

	/// <summary>
	///     Adds the given <paramref name="modifiers" /> to this applier
	/// </summary>
	List<ModifierHandle> AddModifiers( IEnumerable<IValueModifier<TValue>> modifiers );
	
	/// <summary>
	///     Adds the given <paramref name="modifiers" /> to this applier
	/// </summary>
	List<ModifierHandle> AddModifiers( params IValueModifier<TValue>[] modifiers );
}

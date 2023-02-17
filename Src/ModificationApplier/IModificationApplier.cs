namespace CxUtils.ValueModifiers;

/// <summary>
///     Represents a list of modifiers that could be applied on a base / unmodified value
/// </summary>
public interface IModificationApplier<TValue> : IValueModifier<TValue>
{
	/// <summary>
	///     Clears all modifiers from this applier
	/// </summary>
	void Clear();

	/// <summary>
	///     The amount of modifiers the current applier contains
	/// </summary>
	int ModifierCount { get; }
}

namespace CxUtils.ValueModifiers;

/// <summary>
///     Represents a list of modifiers that could be applied on a base / unmodified value
/// </summary>
public interface IModificationApplier<TValue>
{
	/// <summary>
	///     Applies all the modifiers from this applier to the <paramref name="value" />
	/// </summary>
	TValue ApplyTo( TValue value );

	/// <summary>
	///     The amount of modifiers the current applier contains
	/// </summary>
	int ModifierCount { get; }
}

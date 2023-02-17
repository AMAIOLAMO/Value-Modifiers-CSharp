namespace CxUtils.ValueModifiers;

/// <summary>
///     Represents a list of modifiers that could be applied on a base / unmodified value
/// </summary>
public interface IApplier<TValue> : IValueModifier<TValue>
{
	/// <summary>
	///     The amount of modifiers the current applier contains
	/// </summary>
	int Count { get; }
}
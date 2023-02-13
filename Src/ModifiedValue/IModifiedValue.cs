namespace CxUtils.ValueModifiers;

/// <summary>
///     represents a base value that could be modified
/// </summary>
public interface IModifiedValue<out T>
{
	/// <summary>
	///     Calculates the value by applying every modifier and returning the result (does not modify the base value)
	/// </summary>
	T CalculateValue();

	/// <summary>
	///     The absolute base value (unmodified value)
	/// </summary>
	T BaseValue { get; }
}

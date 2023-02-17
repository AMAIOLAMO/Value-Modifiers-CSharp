namespace CxUtils.ValueModifiers;

/// <summary>
///     represents a base value that could be modified / Applied onto
/// </summary>
public interface IApplicable<out T>
{
	/// <summary>
	///     Calculates the value by applying every modifier and returning the result (does not modify the base value)
	/// </summary>
	T CalculateApplied();

	/// <summary>
	///     The absolute base value (unmodified value)
	/// </summary>
	T BaseValue { get; }
}

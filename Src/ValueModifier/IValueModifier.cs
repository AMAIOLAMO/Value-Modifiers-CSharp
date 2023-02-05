namespace CxUtils.ValueModifiers;

/// <summary>
/// Represents a singular modifier for a value
/// </summary>
public interface IValueModifier<T>
{
	/// <summary>
	/// Applies this modifier to the given <paramref name="value"/> and returns the result
	/// </summary>
	T Apply( T value );
}

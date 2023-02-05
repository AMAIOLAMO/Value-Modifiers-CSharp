namespace CxUtils.ValueModifiers;

/// <summary>
/// Represents a singular modifier for a value
/// </summary>
public interface IValueModifier<T>
{
	/// <summary>
	/// Applies this modifier and returns the result
	/// </summary>
	T Modify( T value );
}

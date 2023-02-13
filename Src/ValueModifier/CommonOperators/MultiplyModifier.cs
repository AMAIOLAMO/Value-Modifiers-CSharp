using System.Numerics;

namespace CxUtils.ValueModifiers;

/// <summary>
///     A Concrete Implementation of a modifier which multiplies
/// </summary>
public class MultiplyModifier<T> : IValueModifier<T> where T : IMultiplyOperators<T, T, T>
{
	public MultiplyModifier( T multiplier ) =>
		Multiplier = multiplier;

	public T ApplyTo( T value ) =>
		value * Multiplier;

	public T Multiplier { get; set; }
}

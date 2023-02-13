using System.Numerics;

namespace CxUtils.ValueModifiers;

/// <summary>
///     A Concrete Implementation of a modifier which divides a value
/// </summary>
public class DivisionModifier<T> : IValueModifier<T> where T : IDivisionOperators<T, T, T>
{
	public DivisionModifier( T divisor ) =>
		Divisor = divisor;

	public T ApplyTo( T value ) =>
		value / Divisor;

	public T Divisor { get; set; }
}

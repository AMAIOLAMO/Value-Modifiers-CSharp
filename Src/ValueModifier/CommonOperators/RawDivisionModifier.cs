using System.Numerics;

namespace CxUtils.ValueModifiers;

/// <summary>
///     A Concrete Implementation of a modifier which divides a value,
///     NOTE: Division by 0 is not safe, use <see cref="SafeDivisionModifier{TValue}" />
/// </summary>
public class RawDivisionModifier<TValue> : IValueModifier<TValue> where TValue : IDivisionOperators<TValue, TValue, TValue>
{
	public RawDivisionModifier( TValue divisor ) =>
		Divisor = divisor;

	public TValue ApplyTo( TValue value ) =>
		value / Divisor;

	public TValue Divisor { get; set; }
}

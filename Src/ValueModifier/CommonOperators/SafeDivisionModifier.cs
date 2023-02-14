using System.Numerics;

namespace CxUtils.ValueModifiers;

/// <summary>
///     A Concrete Implementation of a modifier which divides a value,
///     and when the divisor is 0, returns 0 for safety
/// </summary>
public class SafeDivisionModifier<TValue> : IValueModifier<TValue> where TValue : INumber<TValue>
{
	public SafeDivisionModifier( TValue divisor ) =>
		Divisor = divisor;

	public TValue ApplyTo( TValue value )
	{
		if ( TValue.IsZero( Divisor ) )
			return TValue.Zero;
		// else

		return value / Divisor;
	}

	public TValue Divisor { get; set; }
}

using System.Numerics;

namespace CxUtils.ValueModifiers;

public class MapModifier<TValue> : IValueModifier<TValue>
	where TValue :
	ISubtractionOperators<TValue, TValue, TValue>, IMultiplyOperators<TValue, TValue, TValue>,
	IDivisionOperators<TValue, TValue, TValue>, IAdditionOperators<TValue, TValue, TValue>
{
	public MapModifier( TValue inMin, TValue inMax, TValue outMin, TValue outMax )
	{
		InMin = inMin;
		InMax = inMax;
		OutMin = outMin;
		OutMax = outMax;
	}

	public TValue ApplyTo( TValue value ) =>
		( value - InMin ) * ( OutMax - OutMin ) / ( InMax - InMin ) + OutMin;

	public TValue InMin { get; set; }

	public TValue InMax { get; set; }

	public TValue OutMin { get; set; }

	public TValue OutMax { get; set; }
}

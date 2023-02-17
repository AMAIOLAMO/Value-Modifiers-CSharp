using System.Numerics;

namespace CxUtils.ValueModifiers;

public class MinModifier<T> : IValueModifier<T> where T : IComparisonOperators<T, T, bool>
{
	public MinModifier( T min ) =>
		Min = min;

	public T ApplyTo( T value ) =>
		value < Min ?
			Min :
			value;

	public T Min { get; set; }
}

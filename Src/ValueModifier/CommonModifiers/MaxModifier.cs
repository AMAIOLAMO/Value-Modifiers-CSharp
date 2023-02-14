using System.Numerics;

namespace CxUtils.ValueModifiers;

public class MaxModifier<T> : IValueModifier<T> where T : IComparisonOperators<T, T, bool>
{
	public MaxModifier( T max ) =>
		Max = max;

	public T ApplyTo( T value ) =>
		value > Max ?
			Max :
			value;

	public T Max { get; }
}

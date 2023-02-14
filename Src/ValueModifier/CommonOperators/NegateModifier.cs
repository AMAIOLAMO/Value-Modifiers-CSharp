using System.Numerics;

namespace CxUtils.ValueModifiers;

public class NegateModifier<T> : IValueModifier<T> where T : IUnaryNegationOperators<T, T>
{
	public T ApplyTo( T value ) => -value;
}

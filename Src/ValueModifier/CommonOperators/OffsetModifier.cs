using System.Numerics;

namespace CxUtils.ValueModifiers;

/// <summary>
///     A Concrete Implementation of a modifier which offsets a value
/// </summary>
public class OffsetModifier<T> : IValueModifier<T> where T : IAdditionOperators<T, T, T>
{
	public OffsetModifier( T offset ) =>
		Offset = offset;

	public T ApplyTo( T value ) =>
		value + Offset;

	public T Offset { get; set; }
}

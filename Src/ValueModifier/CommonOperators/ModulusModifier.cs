using System.Numerics;

namespace CxUtils.ValueModifiers;

/// <summary>
///     A Concrete Implementation of a modifier which does modulus when applied
/// </summary>
public class ModulusModifier<T> : IValueModifier<T> where T : IModulusOperators<T, T, T>
{
	public ModulusModifier( T divisor ) =>
		Divisor = divisor;

	public T ApplyTo( T value ) =>
		value % Divisor;

	public T Divisor { get; set; }
}

namespace CxUtils.ValueModifiers;

/// <summary>
///     A modifier which inputs a factory method
/// </summary>
public class FactoryModifier<T> : IValueModifier<T>
{
	public FactoryModifier( Func<T, T> factory ) =>
		Factory = factory;

	public T ApplyTo( T value ) =>
		Factory( value );

	public Func<T, T> Factory { get; set; }
}

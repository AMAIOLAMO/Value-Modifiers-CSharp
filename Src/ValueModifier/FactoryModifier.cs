namespace CxUtils.ValueModifiers;

/// <summary>
/// A modifier which inputs a factory
/// </summary>
public class FactoryModifier<T> : IValueModifier<T>
{
    public FactoryModifier(Func<T, T> factory)
    {
        _factory = factory;
    }

    public T ApplyTo(T value)
    {
        return _factory(value);
    }

    readonly Func<T, T> _factory;
}

namespace CxUtils.ValueModifiers;

public interface IModificationApplier<T>
{
	T Apply( T value );

	ModifierHandle AddModifier( IValueModifier<T> modifier );

	void RemoveModifier( ModifierHandle handle );
}

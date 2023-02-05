namespace CxUtils.ValueModifiers;

public interface IValueModifier<T>
{
	T Modify( T value );

	void ApplyTo( IModifiedValue<T> modifiedValue );
}

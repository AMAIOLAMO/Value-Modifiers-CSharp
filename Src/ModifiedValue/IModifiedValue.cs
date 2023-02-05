namespace CxUtils.ValueModifiers;

public interface IModifiedValue<T>
{
	T CalculateValue();

	ModifierHandle AddModifier( IValueModifier<T> modifier );

	void RemoveModifier( ModifierHandle handle );
	
	T BaseValue { get; set; }
}

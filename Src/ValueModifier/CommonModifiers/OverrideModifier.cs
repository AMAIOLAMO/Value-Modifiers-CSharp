namespace CxUtils.ValueModifiers;

/// <summary>
///     A modifier which ignores the previous modification and overrides the entire value
/// </summary>
public class OverrideModifier<TValue> : IValueModifier<TValue>
{
	public OverrideModifier( TValue overridingValue ) =>
		OverridingValue = overridingValue;

	public TValue ApplyTo( TValue value ) =>
		OverridingValue;

	public TValue OverridingValue { get; set; }
}

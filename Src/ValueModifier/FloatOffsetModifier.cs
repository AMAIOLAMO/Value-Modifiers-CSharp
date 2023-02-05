namespace CxUtils.ValueModifiers;

public class FloatOffsetModifier : IValueModifier<float>
{
	public FloatOffsetModifier( float offset = 0 ) =>
		Offset = offset;

	public float Modify( float value ) =>
		value + Offset;

	public void ApplyTo( IModifiedValue<float> modifiedValue )
	{
		modifiedValue.BaseValue = Modify( modifiedValue.BaseValue );
	}
	
	
	public float Offset { get; set; }
}

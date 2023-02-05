namespace CxUtils.ValueModifiers;

/// <summary>
/// A Concrete implementation of an offset modifier for floating-points
/// </summary>
public class FloatOffsetModifier : IValueModifier<float>
{
	public FloatOffsetModifier( float offset = 0 ) =>
		Offset = offset;

	public float Modify( float value ) =>
		value + Offset;
	
	public float Offset { get; set; }
}

namespace CxUtils.ValueModifiers;

/// <summary>
/// A Concrete implementation of an offset modifier for doubles
/// </summary>
public class DoubleOffsetModifier : IValueModifier<double>
{
	public DoubleOffsetModifier( double offset = 0 ) =>
		Offset = offset;

	public double Modify( double value ) =>
		value + Offset;
	
	public double Offset { get; set; }
}

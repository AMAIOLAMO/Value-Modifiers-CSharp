using System.Numerics;

namespace CxUtils.ValueModifiers;

/// <summary>
///     A Modifier which returns Min if value is lesser than Min, and returns Max if greater than Max,
///     And returns value itself it both aren't satisfied
/// </summary>
public class ClampModifier<T> : IValueModifier<T> where T : IComparisonOperators<T, T, bool>
{
	public ClampModifier( T min, T max )
	{
		Min = min;
		Max = max;
	}

	public T ApplyTo( T value )
	{
		if ( value < Min )
			return Min;

		if ( value > Max )
			return Max;

		return value;
	}

	public T Min { get; }
	public T Max { get; }
}
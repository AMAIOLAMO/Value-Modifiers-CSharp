namespace CxUtils.ValueModifiers;

public class PriorityModifier<TValue> : IValueModifier<TValue>, IComparable<PriorityModifier<TValue>>
{
	public PriorityModifier( IValueModifier<TValue> modifier, int priority = 0 )
	{
		Modifier = modifier;
		Priority = priority;
	}

	public int CompareTo( PriorityModifier<TValue>? other )
	{
		if ( ReferenceEquals( this, other ) )
			return 0;

		if ( ReferenceEquals( null, other ) )
			return 1;

		return Priority.CompareTo( other.Priority );
	}

	public TValue ApplyTo( TValue value ) =>
		Modifier.ApplyTo( value );

	public IValueModifier<TValue> Modifier { get; set; }

	public int Priority { get; set; }
}

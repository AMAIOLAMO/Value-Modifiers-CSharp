namespace CxUtils.ValueModifiers;

/// <summary>
///     Filters the value when the given filterFactory returns true before <see cref="ApplyTo" /> is reached
/// </summary>
public class PassModifier<TValue> : IValueModifier<TValue>
{
	/// <param name="appliedModifier">The applied modifier when <paramref name="filterFactory" /> returns true</param>
	/// <param name="filterFactory">The factory which determines whether or not a value should pass through and be applied</param>
	public PassModifier( IValueModifier<TValue> appliedModifier, Predicate<TValue> filterFactory )
	{
		_filterFactory = filterFactory;
		AppliedModifier = appliedModifier;
	}

	public TValue ApplyTo( TValue value ) =>
		_filterFactory( value ) ? AppliedModifier.ApplyTo( value ) : value;

	/// <summary>
	///     The modifier to apply when filterFactory returns true
	/// </summary>
	public IValueModifier<TValue> AppliedModifier { get; set; }

	readonly Predicate<TValue> _filterFactory;
}

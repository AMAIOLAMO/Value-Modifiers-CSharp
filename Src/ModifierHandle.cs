namespace CxUtils.ValueModifiers;

/// <summary>
///     A safety handle for modifiers used as an identifier to know which modifier it is representing
/// </summary>
public readonly struct ModifierHandle : IEquatable<ModifierHandle>
{
	ModifierHandle( ulong id ) =>
		_id = id;

	public bool Equals( ModifierHandle other ) =>
		_id == other._id;

	public override int GetHashCode() =>
		_id.GetHashCode();

	public override bool Equals( object? obj ) =>
		obj is ModifierHandle other && Equals( other );

	static readonly ConcurrentUlongIncrementor _incrementor = new();

	readonly ulong _id;

	public static ModifierHandle New() => new( _incrementor.Next() );
}

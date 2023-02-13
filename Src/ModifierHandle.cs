namespace CxUtils.ValueModifiers;

/// <summary>
///     A safety handle for modifiers used as an identifier to know which modifier it is representing
/// </summary>
public readonly struct ModifierHandle
{
	ModifierHandle( int id ) =>
		_id = id;

	public override int GetHashCode() =>
		_id.GetHashCode();

	static readonly ConcurrentIntIncrementor _incrementor = new();

	readonly int _id;

	public static ModifierHandle New() => new( _incrementor.Next() );
}

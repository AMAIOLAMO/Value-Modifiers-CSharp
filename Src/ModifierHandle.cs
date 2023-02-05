using System;

namespace CxUtils.ValueModifiers;

/// <summary>
///     A safety handle for modifiers
/// </summary>
public readonly struct ModifierHandle
{
	ModifierHandle( Guid guid ) =>
		_guid = guid;

	public override int GetHashCode() =>
		_guid.GetHashCode();

	readonly Guid _guid;

	public static ModifierHandle New() => new( Guid.NewGuid() );
}

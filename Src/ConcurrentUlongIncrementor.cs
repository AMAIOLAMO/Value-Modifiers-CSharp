namespace CxUtils.ValueModifiers;

/// <summary>
///     Represents a <see cref="ulong" /> based identifier incrementor
/// </summary>
internal class ConcurrentUlongIncrementor
{
	public ulong Next()
	{
		lock ( _incrementalLock )
		{
			++_internalIncrementor;

			return _internalIncrementor;
		}
	}

	readonly object _incrementalLock = new();

	ulong _internalIncrementor;
}

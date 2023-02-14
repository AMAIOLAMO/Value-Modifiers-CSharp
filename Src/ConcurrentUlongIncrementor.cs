namespace CxUtils.ValueModifiers;

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

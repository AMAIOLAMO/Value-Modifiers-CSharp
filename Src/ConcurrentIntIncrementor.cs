namespace CxUtils.ValueModifiers;

internal class ConcurrentIntIncrementor
{
	public int Next()
	{
		lock ( _incrementalLock )
		{
			++_internalIncrementor;

			return _internalIncrementor;
		}
	}

	readonly object _incrementalLock = new();

	int _internalIncrementor;
}

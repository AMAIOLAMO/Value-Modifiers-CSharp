namespace CXUtils.Modifiers
{
	/// <summary>
	///     Implements a value modifier
	/// </summary>
	public interface IValueModifier<out T>
	{
		public T Get();
	}
}

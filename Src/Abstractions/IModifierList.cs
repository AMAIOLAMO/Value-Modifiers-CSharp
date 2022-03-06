using System.Collections.Generic;

namespace CXUtils.Modifiers
{
	public interface IModifierList<T> : IEnumerable<IValueModifier<T>>
	{
		int Add(IValueModifier<T> modifier);
		bool TryRemove(int id);
		bool ValidId(int id);

		T Evaluate();
	}
}

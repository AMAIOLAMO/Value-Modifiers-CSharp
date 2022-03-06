using System.Collections;
using System.Collections.Generic;

namespace CXUtils.Modifiers
{
	public abstract class ModifierListBase<T> : IModifierList<T>
	{
		public IEnumerator<IValueModifier<T>> GetEnumerator() => modifiers.GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

		public int Add(IValueModifier<T> modifier)
		{
			modifiers.Add(modifier);
			return modifiers.Count - 1;
		}

		public bool TryRemove(int id)
		{
			if (!ValidId(id)) return false;
			// else

			modifiers.RemoveAt(id);
			return true;
		}

		public bool ValidId(int id) => id > -1 && id < modifiers.Count;
		public abstract T Evaluate();

		public readonly List<IValueModifier<T>> modifiers = new List<IValueModifier<T>>();
	}
}

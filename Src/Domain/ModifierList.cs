using System;
using System.Collections.Generic;

namespace CXUtils.Modifiers
{
	public class ModifierList<T> : ModifierListBase<T>
	{
		public ModifierList(Func<List<IValueModifier<T>>, T> factory) => this.factory = factory;

		public override T Evaluate() => factory(modifiers);

		readonly Func<List<IValueModifier<T>>, T> factory;
	}
}

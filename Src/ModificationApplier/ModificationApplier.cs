using System.Collections.Generic;

namespace CxUtils.ValueModifiers;

public class ModificationApplier<T> : IModificationApplier<T>
{
	public T Apply( T value )
	{
		T resultValue = value;

		foreach ( KeyValuePair<ModifierHandle, IValueModifier<T>> pair in _modifiers )
			resultValue = pair.Value.Modify( resultValue );

		return resultValue;
	}

	public ModifierHandle AddModifier( IValueModifier<T> modifier )
	{
		var newHandle = ModifierHandle.New();

		_modifiers.Add( newHandle, modifier );

		return newHandle;
	}

	public void RemoveModifier( ModifierHandle handle )
	{
		_modifiers.Remove( handle );
	}


	// uses dictionary internally
	readonly Dictionary<ModifierHandle, IValueModifier<T>> _modifiers = new();
}

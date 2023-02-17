using System.Diagnostics.Contracts;

namespace CxUtils.ValueModifiers.Utilities;

public static class WrappedModifierExtensions
{
	/// <summary>
	///     Wraps this <paramref name="modifier" /> into a <see cref="PriorityModifier{TValue}" />
	/// </summary>
	[Pure]
	public static PriorityModifier<TValue> WrapPriority<TValue>( this IValueModifier<TValue> modifier, int priority = 0 ) =>
		new( modifier, priority );

	/// <summary>
	///     Wraps this <paramref name="modifier" /> into a <see cref="PassModifier{TValue}" />
	/// </summary>
	[Pure]
	public static PassModifier<TValue> WrapPass<TValue>( this IValueModifier<TValue> modifier, Predicate<TValue> filterFactory ) =>
		new( modifier, filterFactory );
}

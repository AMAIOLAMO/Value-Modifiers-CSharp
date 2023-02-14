# Value Modifiers

> Value Modifiers is a simple wrapper for applying multiply changes(Modification in our case) to a base(Unmodified) value.

---
## How To Use

Here's a basic example on how it could be used.
```csharp
using CxUtils.ValueModifiers;

float yourBaseValue = 2.0f;

// a modifier that offsets a base value by 2
OffsetModifier<float> modifier = new( 2 );

// applies this modifier to yourBaseValue
float modifiedValue = modifier.ApplyTo( yourBaseValue );

Console.WriteLine( modifiedValue ); // outputs 4
```

---
## Ordered Modifications
> Applies modification in the order on which the modifier is being added into
### `OrderedModificationApplier<TValue>`
> It resembles a list of modifiers and can be easily applied in order to a given base value:
```csharp
using CxUtils.ValueModifiers;

float yourBaseValue = 2.0f;

// a modifier that offsets a base value by 2
OffsetModifier<float> modifier = new( 2 );

// create an applier which applies in the order of which modifiers are added
var applier = new OrderedModificationApplier<float>();

// Adds the same offset modifier 2 times
// (baseValue + 2 + 2) = 6
applier.AddModifier( modifier );
applier.AddModifier( modifier );

// Applies all the modifiers in the applier to the given value
float modifiedValue = applier.ApplyTo( yourBaseValue );

Console.WriteLine( modifiedValue ); // Outputs 6




// removes the second modifier
// (baseValue + 2) = 4
applier.RemoveModifierAt( 1 );

float newModifiedValue = applier.ApplyTo( yourBaseValue );

Console.WriteLine( newModifiedValue ); // Outputs 4
```



---
### `OrderedModifiedValue<TValue>`
> Acts like a `OrderedModificationApplier<TValue>` but handles base value under the hood but handles base value under the hood.

```csharp
using CxUtils.ValueModifiers;

// Creates a new modified value of type float
// with a base value of 2
OrderedModifiedValue<float> myManagedValue = new( 2 );

// a modifier that offsets a base value by 2
OffsetModifier<float> modifier = new( 2 );

// Adds the modifier to the managed value's modification applier
myManagedValue.AddModifier( modifier );

// when it's calculated, it applies all the modifiers
// NOTE: this does not modify the base value!
Console.WriteLine( myManagedValue.CalculateValue() ); // outputs 4
```

---
## Unordered Modifications
> Applies modifications without order, but returns a `ModifierHandle` as an alternative to indexes as an identifier when adding any modifiers to an applier.

### `UnorderedModificationApplier<TValue>`
> It resembles as a kind of unstable list that applies values without order.

```csharp
using CxUtils.ValueModifiers;

float yourBaseValue = 2.0f;

// a modifier that offsets a base value by 2
OffsetModifier<float> modifier = new( 2 );

// create an applier which applies without order in mind
// but handles modifiers with ModifierHandles
var applier = new UnorderedModificationApplier<float>();

// Adds the same offset modifier 2 times
// (baseValue + 2 + 2) = 6
// the handle here acts as a safe way to identify which modifier it is in the applier
ModifierHandle handleA = applier.AddModifier( modifier );
ModifierHandle handleB = applier.AddModifier( modifier );

// Applies all the modifiers in the applier to the given value
float modifiedValue = applier.ApplyTo( yourBaseValue );

Console.WriteLine( modifiedValue ); // Outputs 6

// removes the second modifier
// (baseValue + 2) = 4
applier.RemoveModifier( handleB );

float newModifiedValue = applier.ApplyTo( yourBaseValue );

Console.WriteLine( newModifiedValue ); // Outputs 4
```
---
### `UnorderedModifiedValue<TValue>`
> Acts like a `UnorderedModificationApplier<TValue>` but handles base values under the hood.

```csharp
using CxUtils.ValueModifiers;

// Creates a new modified value of type float
// with a base value of 2
UnOrderedModifiedValue<float> myManagedValue = new( 2 );

// a modifier that offsets a base value by 2
OffsetModifier<float> modifier = new( 2 );

// Adds the modifier to the managed value's modification applier
ModifierHandle handleA = myManagedValue.AddModifier( modifier );

// when it's calculated, it applies all the modifiers
// NOTE: this does not modify the base value!
Console.WriteLine( myManagedValue.CalculateValue() ); // outputs 4

myManagedValue.RemoveModifier( handleA );

Console.WriteLine( myManagedValue.CalculateValue() ); // outputs 2
```

---
### Customization

Don't have the modifiers that you wanted? Implement one yourself with `IValueModifier<T>`

```csharp
using CxUtils.ValueModifiers;

var applier = new OrderedModificationApplier<float>();

applier.AddModifier( new MyPiMultiplier() );

Console.WriteLine( applier.ApplyTo( 2 ) ); // Outputs 6.2831855
    
class MyPiMultiplier : IValueModifier<float>
{
    public float ApplyTo( float value ) =>
        value * float.Pi;
}
```

MIT licensed, CxRedix

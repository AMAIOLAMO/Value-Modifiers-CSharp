# Value Modifiers

> Value Modifiers is a simple library for applying multiple changes(Modification in our case) to a base(Unmodified)
> value.

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

## Basics

Value Modifiers has 3 main types:

- Value Modifiers - represents a modifier which applies some action to the value (the core concept of this library)
- Applier - Holds a list of value modifiers and applies them (it is also a kind of Value Modifier)
- Applicable - Almost the same as applier, but this time the value that get's applied (base value) will be handled

### `Applier<TValue>`

> It resembles an ordered list of modifiers

```csharp
using CxUtils.ValueModifiers;

float yourBaseValue = 2.0f;

// a modifier that offsets a base value by 2
OffsetModifier<float> modifier = new( 2 );

// create an applier which applies in the order of which modifiers are added
var applier = new Applier<float>();

// Adds the same offset modifier 2 times
// (baseValue + 2 + 2) = 6
applier.Add( modifier );
applier.Add( modifier );

// Applies all the modifiers in the applier to the given value
float modifiedValue = applier.ApplyTo( yourBaseValue );

Console.WriteLine( modifiedValue ); // Outputs 6

// removes the second modifier
// (baseValue + 2) = 4
applier.RemoveAt( 1 );

float newModifiedValue = applier.ApplyTo( yourBaseValue );

Console.WriteLine( newModifiedValue ); // Outputs 4
```

---

### `Applicable<TValue>`

> Acts like an `Applier<TValue>` but handles base value under the hood

```csharp
using CxUtils.ValueModifiers;

// Creates a new modified value of type float
// with a base value of 2
Applicable<float> myManagedValue = new( 2 );

// a modifier that offsets a base value by 2
OffsetModifier<float> modifier = new( 2 );

// Adds the modifier to the managed value's modification applier
myManagedValue.AddModifier( modifier );

// when it's calculated, it applies all the modifiers
// NOTE: this does not modify the base value!
Console.WriteLine( myManagedValue.CalculateApplied() ); // outputs 4
```

---

### Unordered

    // Documentation TODO

---

### Customization

Don't have the modifiers that you wanted? Implement one yourself with `IValueModifier<T>`

```csharp
using CxUtils.ValueModifiers;

var applier = new Applier<float>();

applier.Add( new MyPiMultiplier() );

Console.WriteLine( applier.ApplyTo( 2 ) ); // Outputs 6.2831855

class MyPiMultiplier : IValueModifier<float>
{
    public float ApplyTo( float value ) =>
        value * float.Pi;
}
```

Or just use the `FactoryModifier<T>` to achieve the same effect from the above

```csharp
using CxUtils.ValueModifiers;

var applier = new Applier<float>();

var piMultiplier = new FactoryModifier<float>( value => value * float.Pi );

applier.Add( piMultiplier );

Console.WriteLine( applier.ApplyTo( 2 ) ); // Outputs 6.2831855
```

MIT licensed, CxRedix

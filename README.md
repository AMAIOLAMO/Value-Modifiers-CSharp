﻿# Value Modifiers

> Value Modifiers are a simple wrapper for applying multiply changes(Modification in our case) to a base(Unmodified) value.

Here's how to start using it:
```csharp
var yourBaseValue = 2.0f;

// a modifier that offsets a base value by 2
FloatOffsetModifier modifier = new( 2 );

// applies this modifier to yourBaseValue
var modifiedValue = modifier.Apply( yourBaseValue );

Console.WriteLine( modifiedValue ); // outputs 4
```

---
`ModificationApplier<T>` is like a list of modifiers and can be easily applied to a given base value:
```csharp
var yourBaseValue = 2.0f;

// a modifier that offsets a base value by 2
FloatOffsetModifier modifier = new( 2 );

var applier = new ModificationApplier<float>();

// Adds the same offset modifier 2 times
// (baseValue + 2 + 2) = 6
applier.AddModifier( modifier );
applier.AddModifier( modifier );

// Applies all the modifiers in the applier to the given value
float modifiedValue = applier.Apply( yourBaseValue );

Console.WriteLine( modifiedValue ); // Outputs 6
```

---

Want an elegant way on managing a base value? `ModifiedValue<T>` comes into play.

```csharp
// Creates a new modified value of type float
// with a base value of 2
ModifiedValue<float> myManagedValue = new( 2 );

// a modifier that offsets a base value by 2
FloatOffsetModifier modifier = new( 2 );

// Adds the modifier to the managed value's modification applier
myManagedValue.AddModifier( modifier );

// when it's calculated, it applies all the modifiers
// NOTE: this does not modify the base value!
Console.WriteLine( myManagedValue.CalculateValue() ); // outputs 4
```
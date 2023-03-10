On Break
  - Back at 11:10

TODO: 
* Mention Recess

Why immutability?
* Predictability. Fewer things to screw up.
* Parralelization. No mutex, lock.

Why use a record struct?
* Immutability (Optional).
* Value semantics. 
  - No garbage collection-- allocated on stack.
  - Maybe more copies. 
* Premature optimization is evil.


Eric's TODOs:
* Pattern versions....
* Can I override .equals in a record?
  - (No)
* Custom types on switch:
  - Look at a field
  - Constructor matching syntax



---

# Record advantages
* Automatically generated .Equals
  - value equality
* Opt in to immutability
* Terse syntax
* Automatically generated .ToString
* With syntax -- non-destructive mutations

```csharp
var p0 = new Point(0,0)
var p1 = p0 with {X=10};

```




## Pattern Matching
* The `is` keyword - tries to cast and create a variable at the same time
* 
```
int i = 0;

var message = i switch{
   0 => "is zero",
   _ when i % 2 == 0 => "is even",
   short iShort => 
   {properties}
   [0,91,81]
}

```


```csharp

class Foo{
  void DoSomething(){
	// standard
  }

  public int add(int a, int b) 
	=> a+b
	
  public string Name
	 => "Joe";
  
}


```


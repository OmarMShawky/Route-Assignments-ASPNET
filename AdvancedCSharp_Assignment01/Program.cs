using Generics;
using System.Data;
using System.Text;
// ========== Question 1 ==========

// Q1: What is a generic class? Why use generics?
// A1: generics allow you to define type-safe classes, interfaces, methods, and delegates
// without committing to a specific data type until the code is used.

// Q2: Write a generic class Container<T> with Add and Get methods.
// A2: 
//var container = new Container<int>();
//container.Add(100);
        
//Console.WriteLine(container.Get());

//var container2 = new Container<string>();
//container2.Add("Omar");
//container2.Get();
//Console.WriteLine(container2.Get());
// Q3:What are multiple type parameters? Write Pair<TKey, TValue>.
// A3: mutiple type parameters allow the developer to specify more than one generic type
var pair = new Pair<string, int>("Omar", 30);
Console.WriteLine(pair);

// Q4: What is a generic method? Write Swap<T>.
// A4: generic method defines its own type parameter independent of the class it lives in.

int x = 5, y = 10;
SwapHelper.Swap(ref x, ref y);
Console.WriteLine(x + "\t" + y);

// Q7:
// The struct constraint restricts T to value types only (int, double, DateTime, custom structs…). This guarantees:
// T cannot be null — value types always have a default value.
// No boxing overhead when stored internally.
// You can safely use default(T) and get a meaningful zero-state.
var box = new ValueBox<Money>();
box.Set(new Money(500.00m));

// Q8: What is the 'class' constraint? Write an example.
// A8: The class constraint restricts T to reference types only (classes, interfaces, delegates, arrays)
// This enables ssigning null to T, calling ReferenceEquals or checking identity. safe use of is / as patterns.

var w = new NullableWrapper<string>();
w.Set("hello");
Console.WriteLine(w.IsNull);

// Q9: What is the 'new()' constraint? Write an example.
// A9: The new() constraint guarantees that T has a public parameterless constructor
// This allows the generic code to call new T() to create instances

var factory = new ObjectFactory<StringBuilder>();
var list = factory.CreateMany(3);
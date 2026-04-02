using System;
using System.Collections.Generic;
using System.Text;

using Generics;

// Q16
// Contravariance: if Dog extends Animal, IConsumer<Animal> can be used as IConsumer<Dog>.
// 'in T' means T appears only in INPUT (parameter) positions — safe to go DOWN the hierarchy.

namespace Q16_contravariance;
// Re-declare minimal hierarchy to keep this file self-contained
public class Animal { public string Name { get; set; } = "Animal"; }
public class Dog : Animal { public Dog() => Name = "Dog"; }

// ── Contravariant interface — T only in parameter position ────
public interface IConsumer<in T>
{
    void Consume(T item);
    // T Produce();  // ✗ would be a compile error — return position forbidden
}

public class AnimalConsumer : IConsumer<Animal>
{
    public void Consume(Animal a) => Console.WriteLine($"Consuming: {a.Name}");
}

// ── Demonstrates contravariance ───────────────────────────────
public static class ContravarianceDemo
{
    public static void Run()
    {
        IConsumer<Animal> animalConsumer = new AnimalConsumer();

        // Contravariance: IConsumer<Animal> → IConsumer<Dog>  (Animal goes DOWN to Dog)
        IConsumer<Dog> dogConsumer = animalConsumer;  // ✓ compiles

        dogConsumer.Consume(new Dog());  // AnimalConsumer handles it fine
    }
}
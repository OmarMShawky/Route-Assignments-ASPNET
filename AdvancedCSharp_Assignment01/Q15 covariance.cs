using System;
using System.Collections.Generic;
using System.Text;

using Generics;
// Q15 — Covariance and the 'out' keyword.
// Covariance: if Dog extends Animal, IProducer<Dog> can be used as IProducer<Animal>.
// 'out T' means T appears only in OUTPUT (return) positions — safe to go UP the hierarchy.


// ──────────────────── Type hierarchy ──────────────────────────
public class Animal { public string Name { get; set; } = "Animal"; }
public class Dog : Animal { public Dog() => Name = "Dog"; }

// ── Covariant interface — T only in return position ───────────
public interface IProducer<out T>
{
    T Produce();
    // void Consume(T item);  // ✗ would be a compile error — input position forbidden
}

public class DogProducer : IProducer<Dog>
{
    public Dog Produce() => new Dog();
}

// ── Demonstrates covariance ───────────────────────────────────
public static class CovarianceDemo
{
    public static void Run()
    {
        IProducer<Dog> dogProducer = new DogProducer();

        IProducer<Animal> animalProducer = dogProducer;

        Animal a = animalProducer.Produce();
    }
}
using System;
using System.Collections.Generic;
using System.Text;

using Generics;

// Q17
//
//  Covariance (out) => go UP   the hierarchy  Dog → Animal   "producer"
//  Contravariance(in) -> go DOWN the hierarchy  Animal → Dog   "consumer"
//  Invariance         => must match exactly

namespace Q17_CovarianceVsContravariance;

public class Animal { }
public class Dog : Animal { }

public interface ICovariant<out T> { T Get(); }   // produces T
public interface IContravariant<in T> { void Use(T item); }   // consumes T

public static class VarianceComparison
{
    public static void ShowRules()
    {
        // ── Covariance (out) ──────────────────────────────────────

        ICovariant<Dog>? dogOut = null;
        ICovariant<Animal>? animalOut = dogOut;    // ✓

        // ── Contravariance (in) ───────────────────────────────────

        IContravariant<Animal>? animalIn = null;
        IContravariant<Dog>? dogIn = animalIn;  // ✓

        // ── Invariance (class — no variance keyword) ──────────────
        List<Dog> dogList = new();
        // List<Animal> animalList = dogList;  // ✗ compile error
        _ = dogList; _ = animalOut; _ = dogIn;  // suppress unused warnings
    }
}
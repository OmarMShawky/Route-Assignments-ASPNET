using System;
using System.Collections.Generic;
using System.Text;

namespace Generics;

// Q06 — Generic interface IRepository<T>.
// Defines a type-safe CRUD contract. Any entity type substitutes T.
public interface IRepository<T>
{
    void Add(T entity);
    T GetById(int id);
    IEnumerable<T> GetAll();
    void Delete(int id);
}
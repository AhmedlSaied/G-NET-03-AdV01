using System;
using System.Collections.Generic;
using AdvancedCSharpGenerics;

namespace AdvancedCSharpGenerics
{
    #region SUPPORTING TYPES & INTERFACES

    public interface IEntity
    {
        int Id { get; set; }
    }

    public class BaseEntity : IEntity
    {
        public int Id { get; set; }
    }

    public class User : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public User() { } 
    }

    #endregion
    #region PART 01 - QUESTIONS 01 TO 05
    #region Q01: Generic Class Definition
    /*
     * Q1: What is a generic class? Why use generics?
     * - Generic Class: A class that allows defining placeholder type parameters (e.g., <T>) 
     *   which are specified when the class is instantiated.
     * - Benefits:
     *   1. Type Safety: Prevents runtime casting errors by enforcing compile-time type checking.
     *   2. Performance: Eliminates boxing and unboxing overhead when working with value types.
     *   3. Reusability: Write logic once, apply to any data type without code duplication.
     */
    #endregion
    
}
#region Q02: Generic Container<T>
public class Container<T>
{
    private T _item = default!;

    public void Add(T item) => _item = item;
    public T Get() => _item;
}
#endregion
#region Q03: Multiple Type Parameters & Pair<TKey, TValue>
/*
 * Multiple Type Parameters allow a class or method to handle more than one generic 
 * type placeholder simultaneously (e.g., <TKey, TValue>).
 */
public class Pair<TKey, TValue>
{
    public TKey Key { get; set; }
    public TValue Value { get; set; }

    public Pair(TKey key, TValue value)
    {
        Key = key;
        Value = value;
    }
}
#endregion
#region Q04: Generic Method & Swap<T>
/*
 * Generic Method: A method declared with its own type parameters independent of class-level types.
 */
public static class Utility
{
    public static void Swap<T>(ref T a, ref T b)
    {
        T temp = a;
        a = b;
        b = temp;
    }

#region Q05: FindMax<T> Method
    public static T FindMax<T>(T a, T b) where T : IComparable<T>
    {
        return a.CompareTo(b) > 0 ? a : b;
    }
    #endregion
}
#endregion
#region PART 01 - QUESTIONS 06 TO 12: INTERFACES & CONSTRAINTS

#region Q06: Generic Interface IRepository<T>
/*
 * Generic Interface: Defines a type-safe contract using parameter placeholders.
 */
public interface IRepository<T>
{
    void Add(T entity);
    T GetById(int id);
    IEnumerable<T> GetAll();
}
#endregion
#endregion
#region Q07: Struct Constraint Example
// Restricts T to non-nullable value types only.
public class ValueWrapper<T> where T : struct
{
    public T Value { get; set; }
    public ValueWrapper(T value) => Value = value;
}
#endregion
#region Q08: Class Constraint Example
// Restricts T to reference types only.
public class ReferenceWrapper<T> where T : class
{
    public T? Value { get; set; }
}
#endregion
#region Q09: new() Constraint Example
// Requires T to have a public parameterless constructor.
public class EntityFactory<T> where T : new()
{
    public T CreateInstance() => new T();
}
#endregion
#region Q10: Interface Constraint Example
// Requires T to implement a specific interface.
public class EntityProcessor<T> where T : IEntity
{
    public void Process(T entity) => Console.WriteLine($"Processing Entity #{entity.Id}");
}
#endregion
#region Q11: Base Class Constraint Example
// Requires T to inherit from a specific base class.
public class BaseEntityManager<T> where T : BaseEntity
{
    public void Save(T entity) => Console.WriteLine($"Saving BaseEntity #{entity.Id}");
}
#endregion
#region Q12: Multiple Constraints Example
// Combining multiple constraint rules on a single type parameter.
public class Repository<T> : IRepository<T> where T : BaseEntity, IEntity, new()
{
    private readonly List<T> _data = new();

    public void Add(T entity) => _data.Add(entity);
    public T GetById(int id) => _data.Find(x => x.Id == id) ?? new T();
    public IEnumerable<T> GetAll() => _data;
}
#endregion
#region PART 01 - QUESTIONS 13 TO 19: ADVANCED CONCEPTS

#region Q13 & Q14: 'default' Keyword & SafeList<T>
/*
 * Q13: 'default' keyword returns null for reference types and 0/false/empty for value types.
 */
public class SafeList<T>
{
    private readonly List<T> _items = new();

    public void Add(T item) => _items.Add(item);

    public T Get(int index)
    {
        if (index >= 0 && index < _items.Count)
            return _items[index];

        return default!;
    }
}
#endregion
#region Q16: Contravariance ('in') Example
/*
 * Contravariance ('in'): Allows using a less derived (more base) type than originally specified.
 * Rule: Input positions ONLY (method arguments).
 */
public interface IContravariantConsumer<in T>
{
    void Consume(T item);
}

public class ContravariantConsumer<T> : IContravariantConsumer<T>
{
    public void Consume(T item) => Console.WriteLine($"Consuming item: {item}");
}
#endregion
#region Q17: Difference Between Covariance and Contravariance
/*
 * Q17: Difference Summary:
 * ---------------------------------------------------------------------------------------
 * Feature          | Covariance ('out')                 | Contravariance ('in')
 * ---------------------------------------------------------------------------------------
 * Direction        | Derived -> Base (Assignment)       | Base -> Derived (Assignment)
 * Allowed Position | Return Types (Outputs)             | Parameter Types (Inputs)
 * Real-world usage | IEnumerable<out T>, IReadOnlyList  | Action<in T>, IComparer<in T>
 * ---------------------------------------------------------------------------------------
 */
#endregion
#region Q18: Static Members in Generic Types
/*
 * Static members are NOT shared across different generic type instantiations.
 * Class<int> and Class<string> maintain completely isolated static state variables.
 */
public class GenericCounter<T>
{
    public static int Count;
}
#endregion
#region Q19: Inheritance from Generic Classes
// 1. Inherit with open generic parameters
public class OpenDerived<T> : Container<T> { }

// 2. Inherit with closed (concrete) generic type argument
public class ClosedDerived : Container<string> { }
#endregion
#endregion
#endregion

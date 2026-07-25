using System;
using System.Collections.Generic;

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
#endregion

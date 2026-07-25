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
}
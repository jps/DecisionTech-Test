using System;

namespace DecisionTech.Model
{
    public interface IEntity<T> where T: struct, IEquatable<T>
    {
        T Id { get; set; }
    }
}

using System;
using System.Collections.Generic;
using DecisionTech.Model;

namespace DecisionTech.Repository.Interfaces
{
    public interface IRepository<T, in TKey> 
        where T : class, IEntity<TKey> 
        where TKey : struct, IEquatable<TKey>
    {
        T GetById(TKey id);
        IEnumerable<T> GetManyByIds(params TKey[] ids);
        T Add(T entity);
        int Count();
    }
}
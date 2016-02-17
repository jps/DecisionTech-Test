using System;
using System.Collections.Generic;
using System.Linq;
using DecisionTech.Model;
using DecisionTech.Repository.Interfaces;
using Ploeh.AutoFixture;

namespace DecisionTech.Repository
{
    //May have got a little carried away here.. had planned on implementing a test application that would make more
    //use of the features in here but time is running a little short so have decided to omit. 
    public abstract class InMemoryRepository<T,TKey> : IRepository<T, TKey> 
        where T: class, IEntity<TKey>
        where TKey: struct, IEquatable<TKey>
    {
        protected ICollection<T> Collection { get; set; }

        private int _idCounter;

        private readonly IFixture _fixture = new Fixture();
        
        protected InMemoryRepository()
        {
            Collection = new List<T>();
        }

        protected InMemoryRepository(ICollection<T> collection)
        {
            Collection = collection;
        }

        /*  This isn't great... but should be ok for this test.. Could either inject a key generator based on typeof 
            TKey or make this class + method abstract and implement in sub classes for each key type we require. */
        protected TKey Nextval()
        {
            if (typeof(TKey) == typeof(int))
            {                
                return (TKey)(object)++_idCounter;
            }

            return _fixture.Create<TKey>();
        } 

        public T GetById(TKey id) => Collection.SingleOrDefault(entity => entity.Id.Equals(id));

        public IEnumerable<T> GetManyByIds(params TKey[] ids) => Collection.Where(entity => ids.Contains(entity.Id));

        public int Count() => Collection.Count;

        public T Add(T entity)
        {
            entity.Id = Nextval();
            Collection.Add(entity);
            return entity;
        }
        
        public void RemoveById(TKey id)
        {
            var objectForDeletion = GetById(id);
            if (objectForDeletion != null)
            {
                Collection.Remove(objectForDeletion);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using DecisionTech.Model;
using DecisionTech.Repository.Interfaces;
using Ploeh.AutoFixture;


namespace DecisionTech.Repository
{
    public abstract class InMemoryRepository<T,TKey> : IRepository<T, TKey> 
        where T: class, IEntity<TKey>
        where TKey: struct, IEquatable<TKey>
    {
        protected ICollection<T> Collection { get; set; }

        private int _idCounter;

        private readonly IFixture _fixture = new Fixture();

        protected InMemoryRepository()
        {
            //Empty.. for now
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

        public T GetById(TKey id)
        {
            return Collection.SingleOrDefault(entity => entity.Id.Equals(id));
        }

        public IEnumerable<T> GetManyByIds(params TKey[] ids)
        {
            return Collection.Where(entity => ids.Contains(entity.Id));
        }

        public T Add(T entity)
        {
            entity.Id = Nextval();
            Collection.Add(entity);
            return entity;
        }

        public int Count() => Collection.Count;

        public void RemoveById(TKey id)
        {
            var objectForDeletion = GetById(id);
            if (objectForDeletion != null)
            {
                Collection.Remove(objectForDeletion);
            }
        }

        //public void Remove(T entity)
        //{
        //    Collection.Remove(entity);
        //}

        //public T Update(T entity)
        //{
        //    //it's not really possible to update the object inplace so remove and add again.
        //    var entityForUpdate = GetById(entity.Id);

        //    if (entityForUpdate != null) throw new KeyNotFoundException();

        //    Add(entity);
        //    return entity;
        //}
    }
}

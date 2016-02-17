using System.Collections.Generic;
using System.Linq;
using DecisionTech.Model;
using DecisionTech.Repository.Interfaces;

namespace DecisionTech.Repository
{
    public class ProductRepository : InMemoryRepository<Product, int>, IProductRepository
    {
        public ProductRepository(ICollection<Product> products) : base(products)
        {
            //Empty
        }

        public Product GetByName(string name) => Collection.SingleOrDefault(p => p.Name == name);
    }
}
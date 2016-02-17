using System.Collections.Generic;
using System.Linq;
using DecisionTech.Model;
using DecisionTech.Repository.Interfaces;

namespace DecisionTech.Repository
{
    public class ProductRepository : InMemoryRepository<Product, int>, IProductRepository
    {
        //init collection in here for now obviously if we had a real data store we would use that
        public ProductRepository()
        {
            Add(new Product()
            {
                Name = "Butter",
                Cost = 0.80m,
            });

            Add(new Product()
            {
                Name = "Milk",
                Cost = 1.15m,
            });

            Add(new Product()
            {
                Name = "Bread",
                Cost = 1m,
            });
        }

        public Product GetByName(string name) => Collection.SingleOrDefault(p => p.Name == name);
    }
}
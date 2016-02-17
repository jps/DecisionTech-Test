using System.Collections.Generic;
using DecisionTech.Model;

namespace DecisionTech.Tests.Common
{
    public static class FakeProducts
    {
        public static ICollection<Product> Data()
        {
            return new List<Product>()
            {
                new Product()
                {
                    Id = 1,
                    Name = "Butter",
                    Cost = 0.80m,
                },
                new Product()
                {
                    Id = 2,
                    Name = "Milk",
                    Cost = 1.15m,
                },
                new Product()
                {
                    Id = 3,
                    Name = "Bread",
                    Cost = 1m,
                }
            };
        }
    }
}

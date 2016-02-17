using System.Collections.Generic;
using DecisionTech.Model;

namespace DecisionTech.Tests.Common
{
    public static class FakeProducts
    {
        public static Product Butter => new Product()
        {
            Id = 1,
            Name = "Butter",
            Cost = 0.80m,
        };

        public static Product Milk => new Product()
        {
            Id = 2,
            Name = "Milk",
            Cost = 1.15m,
        };

        public static Product Bread => new Product()
        {
            Id = 3,
            Name = "Bread",
            Cost = 1m,
        };

        public static ICollection<Product> Data() => new List<Product>()
        {
            Butter,
            Milk,
            Bread                
        };
    }
}

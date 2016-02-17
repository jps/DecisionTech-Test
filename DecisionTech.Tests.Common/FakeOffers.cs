using System.Collections.Generic;
using System.Linq;
using DecisionTech.Model;

namespace DecisionTech.Tests.Common
{
    public static class FakeOffers
    {
        public static ICollection<Offer> Data()
        {
            var products = FakeProducts.Data();

            var butter = products.Single(x => x.Name == "Butter");
            var milk = products.Single(x => x.Name == "Milk");
            var bread = products.Single(x => x.Name == "Butter");

            return new List<Offer>()
            {
                new Offer()
                {
                    PurchaseProduct = butter,
                    DiscountProduct = bread,
                    PercentDiscount = 0.50f,
                    RequiredPurchaseQuantity = 2
                },
                new Offer()
                {
                    PurchaseProduct = milk,
                    DiscountProduct = milk,
                    PercentDiscount = 1.00f,
                    RequiredPurchaseQuantity = 3
                }
            };
        }
    }
}

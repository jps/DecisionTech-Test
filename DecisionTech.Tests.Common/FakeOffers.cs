using System.Collections.Generic;
using DecisionTech.Model;

namespace DecisionTech.Tests.Common
{
    public static class FakeOffers
    {
        public static Offer MilkBuy3Get1FreeOffer() => new Offer()
        {
            PurchaseProduct = FakeProducts.Milk,
            DiscountProduct = FakeProducts.Milk,
            PercentDiscount = 1.00f,
            RequiredPurchaseQuantity = 4
        };

        public static Offer BuyBreadGetButterDiscountOffer() => new Offer()
        {
            PurchaseProduct = FakeProducts.Butter,
            DiscountProduct = FakeProducts.Bread,
            PercentDiscount = 0.50f,
            RequiredPurchaseQuantity = 2
        };

        public static ICollection<Offer> Data()
        {
            return new List<Offer>()
            {
                BuyBreadGetButterDiscountOffer(),
                MilkBuy3Get1FreeOffer()
            };
        }
    }
}

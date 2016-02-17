using System.Collections.Generic;
using System.Linq;
using DecisionTech.Model;
using DecisionTech.Repository.Interfaces;
using DecisionTech.Service.DTO;
using DecisionTech.Service.Interfaces;

namespace DecisionTech.Service
{
    public class BasketCalculatorService : IBasketCalculatorService
    {
        private readonly IOfferRepository _offerRepository;

        public BasketCalculatorService(IOfferRepository offerRepository)
        {
            _offerRepository = offerRepository;
        }

        public BasketCalculatorResult Calculate(Basket basket)
        {
            

            var gross = basket.BasketItems.Sum(basketItem => basketItem.Product.Cost*basketItem.Quantity);

            var discount = CalculateDiscount(basket);

            return new BasketCalculatorResult(gross, discount);
        }

        //I've omitted checking for duplicate items in basket. we assume each product row appears once.             
        private decimal CalculateDiscount(Basket basket)
        {
            var discount = 0.0m;
            
            foreach (var offer in GetOffersForProductsInBasket(basket))
            {
                var purchaseOfferItem = basket.BasketItems.Single(bi => bi.Product.Id == offer.PurchaseProduct.Id);
                var discountOfferItem = basket.BasketItems.SingleOrDefault(bi => bi.Product.Id == offer.DiscountProduct.Id);

                var offerMultiplier = purchaseOfferItem.Quantity/offer.RequiredPurchaseQuantity;

                if (offerMultiplier > 0 && discountOfferItem != null)
                {
                    discount -= offerMultiplier*(offer.DiscountProduct.Cost*(decimal) offer.PercentDiscount);
                }
            }

            return discount;
        }

        private IEnumerable<Offer> GetOffersForProductsInBasket(Basket basket)
        {
            var productIds = basket.BasketItems.Select(bi => bi.Product.Id).ToArray();
            var offersForProductsInBasket = _offerRepository.GetOffersByPurchasedProductIds(productIds);
            return offersForProductsInBasket;
        }
    }
}

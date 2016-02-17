using System.Collections.Generic;
using System.Linq;
using DecisionTech.Model;
using DecisionTech.Repository.Interfaces;

namespace DecisionTech.Repository
{
    public class OfferRepository : InMemoryRepository<Offer, int>, IOfferRepository
    {        
        public OfferRepository(ICollection<Offer> offers) : base(offers)
        {
            //Empty
        }

        public IEnumerable<Offer> GetOffersByPurchasedProductIds(params int[] productIds)
        {
            var distinctProductIds = productIds.Distinct();

            return Collection.Where(o => distinctProductIds.Contains(o.PurchaseProduct.Id));
        }
    }
}
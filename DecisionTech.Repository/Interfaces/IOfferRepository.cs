using System.Collections.Generic;
using DecisionTech.Model;

namespace DecisionTech.Repository.Interfaces
{
    public interface IOfferRepository
    {
        IEnumerable<Offer> GetOffersByPurchasedProducts(params int[] products);
    }
}

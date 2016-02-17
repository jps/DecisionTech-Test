using System.Collections.Generic;
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
    }
}
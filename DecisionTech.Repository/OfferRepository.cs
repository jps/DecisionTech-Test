using DecisionTech.Model;
using DecisionTech.Repository.Interfaces;

namespace DecisionTech.Repository
{
    public class OfferRepository : InMemoryRepository<Offer, int>, IOfferRepository
    {
        //I'm cheating as bit here just to init the data set generally I would inject another repo in here
        public OfferRepository(IProductRepository productRepository)
        {

            //productRepository.ge

            Collection.Add(new Offer()
            {
                
            });


        }
    }
}
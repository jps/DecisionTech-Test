using DecisionTech.Model;
using DecisionTech.Repository.Interfaces;

namespace DecisionTech.Repository
{
    public class OfferRepository : InMemoryRepository<Offer, int>, IOfferRepository
    {
        //I'm cheating as bit here just to init the data set generally I wouldn't ever inject another repo in here
        public OfferRepository(IProductRepository productRepository)
        {
            
            var butter = productRepository.GetByName("Butter");
            var bread = productRepository.GetByName("Bread");
            var milk = productRepository.GetByName("Milk");
            //Buy 2 Butter and get a Bread at 50% off
            Collection.Add(new Offer()
            {
                PurchaseProduct = butter,
                DiscountProduct = bread,
                PercentDiscount = 0.50f,
                RequiredPurchaseQuantity = 2
            });

            //Buy 3 Milk and get the 4th milk for free
            Collection.Add(new Offer()
            {
                PurchaseProduct = milk,
                DiscountProduct = milk,
                PercentDiscount = 1.00f,
                RequiredPurchaseQuantity = 3
            });
        }
    }
}
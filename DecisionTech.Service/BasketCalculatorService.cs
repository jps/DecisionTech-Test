using DecisionTech.Model;
using DecisionTech.Repository.Interfaces;
using DecisionTech.Service.DTO;
using DecisionTech.Service.Interfaces;

namespace DecisionTech.Service
{
    public class BasketCalculatorService : IBasketCalculatorService
    {
        private IOfferRepository _offerRepository;
        private IProductRepository _productRepository;

        public BasketCalculatorService(IProductRepository productRepository, IOfferRepository offerRepository)
        {
            this._productRepository = productRepository;
            this._offerRepository = offerRepository;
        }

        public BasketCalculatorResult Calculate(Basket basket)
        {
            throw new System.NotImplementedException();//TODO: Implement
        }
    }
}

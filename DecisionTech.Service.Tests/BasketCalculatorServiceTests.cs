using System.Linq;
using DecisionTech.Model;
using DecisionTech.Repository.Interfaces;
using DecisionTech.Service.Interfaces;
using DecisionTech.Tests.Common;
using NUnit.Framework;
using Rhino.Mocks;

namespace DecisionTech.Service.Tests
{
    [TestFixture]
    public class BasketCalculatorServiceTests
    {
        //SUT
        private readonly IBasketCalculatorService _basketCalculatorService;
        
        //Dependencies
        private readonly IProductRepository _productRepository;
        private readonly IOfferRepository _offerRepository;

        //TestData
        private readonly Product _butter;
        private readonly Product _milk;
        private readonly Product _bread;

        public BasketCalculatorServiceTests()
        {
            _productRepository = MockRepository.GenerateMock<IProductRepository>();
            _offerRepository = MockRepository.GenerateMock<IOfferRepository>();

            _basketCalculatorService = new BasketCalculatorService(_productRepository, _offerRepository);

            //setup shortcuts to data
            var fakeProductData = FakeProducts.Data();

            

            var fakeOfferData = FakeOffers.Data();

        }

        [TestFixtureSetUp]
        public void Setup()
        {
            //fake product data
//            _productRepository


        }

        [Test]
        public void BasketCalculatorService_Calculate_When_No_Discounts_Applied_Correct_Total()
        {
            //Arrange
            

            //Act

            //Assert

        }

        //Given the basket has 1 bread, 1 butter and 1 milk when I total the basket then the total

        //should be £2.95

        //Given the basket has 2 butter and 2 bread when I total the basket then the total should be 

        //£3.10

        //Given the basket has 4 milk when I total the basket then the total should be £3.45

        //Given the basket has 2 butter, 1 bread and 8 milk when I total the basket then the total

        //should be £9.00

    }
}
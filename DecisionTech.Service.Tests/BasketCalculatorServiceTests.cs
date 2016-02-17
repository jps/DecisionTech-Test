using System.Collections.Generic;
using DecisionTech.Model;
using DecisionTech.Repository.Interfaces;
using DecisionTech.Service.Interfaces;
using DecisionTech.Tests.Common;
using FluentAssertions;
using NUnit.Framework;
using Rhino.Mocks;

namespace DecisionTech.Service.Tests
{
    [TestFixture]
    public class BasketCalculatorServiceTests
    {
        //SUT
        private IBasketCalculatorService _basketCalculatorService;
        
        //Dependencies
        private IProductRepository _productRepository;
        private IOfferRepository _offerRepository;

        public BasketCalculatorServiceTests()
        {
            _productRepository = MockRepository.GenerateMock<IProductRepository>();
            

            
        }

        [SetUp]
        public void Setup()
        {
            _offerRepository = MockRepository.GenerateMock<IOfferRepository>();

            _basketCalculatorService = new BasketCalculatorService(_offerRepository);
        }

        [TearDown]
        public void TearDown()
        {
            _offerRepository = null;
        }

        [Test]
        public void BasketCalculatorService_Calculate_When_No_Discounts_Applied_Correct_Total()
        {
            _offerRepository.Stub(o => o.GetOffersByPurchasedProductIds())
                .IgnoreArguments()
                .Return(FakeOffers.Data());
            
            //Arrange
            //Given the basket has 1 bread, 1 butter and 1 milk when I total the basket then the total    
            var basket = new Basket()
            {
                BasketItems = new List<BasketItem>()
                {
                    new BasketItem()
                    {
                        Product = FakeProducts.Bread,
                        Quantity = 1
                    },
                    new BasketItem()
                    {
                        Product = FakeProducts.Butter,
                        Quantity = 1
                    },
                    new BasketItem()
                    {
                        Product = FakeProducts.Milk,
                        Quantity = 1
                    }
                }
            };

            //Act
            var basketCalculation = _basketCalculatorService.Calculate(basket);
            //Assert
            basketCalculation.Net.Should().Be(2.95m);
        }


        [Test]
        public void BasketCalculatorService_Calculate_When_Multiple_Discounted_Items_In_Basket_Discount_Should_Only_Be_Applied_Once()
        {
            //Arrange
            //Given the basket has 2 butter and 2 bread when I total the basket then the total should be 
            _offerRepository.Stub(o => o.GetOffersByPurchasedProductIds()).IgnoreArguments()
                .Return(new List<Offer> { FakeOffers.BuyBreadGetButterDiscountOffer()});

            var basket = new Basket()
            {
                BasketItems = new List<BasketItem>()
                {
                    new BasketItem()
                    {
                        Product = FakeProducts.Butter,
                        Quantity = 2
                    },
                    new BasketItem()
                    {
                        Product = FakeProducts.Bread,
                        Quantity = 2
                    }
                }
            };

            //Act
            var basketCalculation = _basketCalculatorService.Calculate(basket);
            //Assert
            basketCalculation.Net.Should().Be(3.10m);
        }



        [Test]
        public void BasketCalculatorService_Calculate_When_Buy_N_Get_One_Free_Should_Apply_Correct_Discount()
        {
            //Arrange
            //Given the basket has 2 butter and 2 bread when I total the basket then the total should be 
            _offerRepository.Stub(o => o.GetOffersByPurchasedProductIds()).IgnoreArguments()
                .Return(new List<Offer> { FakeOffers.MilkBuy3Get1FreeOffer()});

            var basket = new Basket()
            {
                BasketItems = new List<BasketItem>()
                {
                    new BasketItem()
                    {
                        Product = FakeProducts.Milk,
                        Quantity = 4
                    }
                }
            };

            //Act
            var basketCalculation = _basketCalculatorService.Calculate(basket);
            //Assert
            basketCalculation.Net.Should().Be(3.45m);
        }



        [Test]
        public void BasketCalculatorService_Calculate_When_Multiple_Offers_Present_Correct_Discount_Applied()
        {
            //Arrange
            //Given the basket has 2 butter and 2 bread when I total the basket then the total should be 
            _offerRepository.Stub(o => o.GetOffersByPurchasedProductIds()).IgnoreArguments()
                .Return(FakeOffers.Data());

            var basket = new Basket()
            {
                BasketItems = new List<BasketItem>()
                {
                    new BasketItem()
                    {
                        Product = FakeProducts.Butter,
                        Quantity = 2
                    },
                    new BasketItem()
                    {
                        Product = FakeProducts.Bread,
                        Quantity = 1
                    },
                    new BasketItem()
                    {
                        Product = FakeProducts.Milk,
                        Quantity = 8
                    }
                }
            };

            //Act
            var basketCalculation = _basketCalculatorService.Calculate(basket);
            //Assert
            basketCalculation.Net.Should().Be(9.00m);
        }        
    }
}
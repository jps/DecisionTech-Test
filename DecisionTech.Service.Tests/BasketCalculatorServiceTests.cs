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
        private IOfferRepository _offerRepository;

        [SetUp]
        public void Setup()
        {
            _offerRepository = MockRepository.GenerateMock<IOfferRepository>();
            _basketCalculatorService = new BasketCalculatorService(_offerRepository);
        }
        
        [Test]
        //Given the basket has 1 bread, 1 butter and 1 milk when I total the basket then the total should be £2.95
        public void BasketCalculatorService_Calculate_When_No_Discounts_Applied_Correct_Net_Returned()
        {
            //Arrange
            _offerRepository.Stub(o => o.GetOffersByPurchasedProductIds())
                .IgnoreArguments()
                .Return(FakeOffers.Data());
                        
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
        //Given the basket has 2 butter and 2 bread when I total the basket then the total should be £3.10
        public void BasketCalculatorService_Calculate_When_Multiple_Discounted_Items_In_Basket_Discount_Should_Only_Be_Applied_Once()
        {
            //Arrange            
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
        //Given the basket has 4 butter and 1 bread when I total the basket then the total should be £3.70
        public void BasketCalculatorService_Calculate_When_Multiple_Offer_Items_And_Single_Discount_Item_Discount_Should_Only_Be_Applied_Once()
        {
            //Arrange            
            _offerRepository.Stub(o => o.GetOffersByPurchasedProductIds()).IgnoreArguments()
                .Return(new List<Offer> { FakeOffers.BuyBreadGetButterDiscountOffer() });

            var basket = new Basket()
            {
                BasketItems = new List<BasketItem>()
                {
                    new BasketItem()
                    {
                        Product = FakeProducts.Butter,
                        Quantity = 4
                    },
                    new BasketItem()
                    {
                        Product = FakeProducts.Bread,
                        Quantity = 1
                    }
                }
            };

            //Act
            var basketCalculation = _basketCalculatorService.Calculate(basket);
            //Assert
            basketCalculation.Net.Should().Be(3.70m);
        }


        [Test]
        //Given the basket has 4 milk when I total the basket then the total should be £3.45
        public void BasketCalculatorService_Calculate_When_Buy_N_Get_One_Free_Should_Apply_Correct_Discount()
        {
            //Arrange
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
        //Given the basket has 2 butter, 1 bread and 8 milk when I total the basket then the total should be £9.00
        public void BasketCalculatorService_Calculate_When_Multiple_Offers_Present_Correct_Discount_Applied()
        {
            //Arrange            
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
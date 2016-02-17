using System.Linq;
using DecisionTech.Repository.Interfaces;
using DecisionTech.Tests.Common;
using FluentAssertions;
using NUnit.Framework;

namespace DecisionTech.Repository.Tests
{
    [TestFixture]
    [Category("Unit")]
    public class OfferRepositoryTests
    {
        //SUT 
        private readonly IOfferRepository _offerRepository;

        public OfferRepositoryTests()
        {
            _offerRepository = new OfferRepository(FakeOffers.Data());
        }

        #region GetOffersByPurchasedProductIds

        [Test]
        public void OfferRepository_GetOffersByPurchasedProductIds_When_No_Matches_Return_Empty_Collection()
        {
            //Arrange
            var products = new[] {FakeProducts.Bread.Id};

            //Act
            var matches = _offerRepository.GetOffersByPurchasedProductIds(products);
            //Assert
            matches.Count().Should().Be(0);
        }

        [Test]
        public void OfferRepository_GetOffersByPurchasedProductIds_When_Single_Match_Return_Single_Element_In_Collection()
        {
            //Arrange
            var products = new[] { FakeProducts.Bread.Id, FakeProducts.Butter.Id };
            //Act
            
            var matches = _offerRepository.GetOffersByPurchasedProductIds(products);
            //Assert
            matches.Count().Should().Be(1);
        }

        [Test]
        public void OfferRepository_GetOffersByPurchasedProductIds_When_Many_Matches_Return_Many_Elements_In_Collection()
        {
            //Arrange
            var products = new[] { FakeProducts.Bread.Id, FakeProducts.Butter.Id, FakeProducts.Milk.Id };
            //Act

            var matches = _offerRepository.GetOffersByPurchasedProductIds(products);
            //Assert
            matches.Count().Should().Be(2);
        }

        #endregion
    }
}

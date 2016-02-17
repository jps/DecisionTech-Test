using DecisionTech.Repository.Interfaces;
using FluentAssertions;
using NUnit.Framework;

namespace DecisionTech.Repository.Tests
{
    [TestFixture]
    [Category("Unit")]
    public class ProductRepositoryTests
    {
        //SUT 
        private readonly IProductRepository _productRepository;

        public ProductRepositoryTests()
        {
            _productRepository = new ProductRepository();
        }

        #region GetByName

        [Test]
        public void ProductRepository_GetByName_Should_Return_Entity_When_It_Exists_In_Collection()
        {
            //Arrange
            const string name = "Butter";
            //Act
            var entity = _productRepository.GetByName(name);
            //Assert
            entity.Should().NotBeNull();
            entity.Name.Should().Be(name);
        }

        [Test]
        public void ProductRepository_GetByName_Should_Return_Null_When_Does_Not_Exists_In_Collection()
        {
            //Arrange
            const string name = "Compté";
            //Act
            var entity = _productRepository.GetByName(name);
            //Assert
            entity.Should().BeNull();
        }

        #endregion

    }
}

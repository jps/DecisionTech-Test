using System.Collections.Generic;
using System.Linq;
using DecisionTech.Model;
using DecisionTech.Repository.Interfaces;
using FluentAssertions;
using NUnit.Framework;

namespace DecisionTech.Repository.Tests
{
    [TestFixture]
    [Category("Unit")]
    public class InMemoryBaseRepositoryTest
    {
        //SUT
        private readonly IRepository<TestModel, int> _repository;

        public InMemoryBaseRepositoryTest()
        {
            _repository = new TestInMemoryRepository();
        }

        #region GetById
        [Test]
        public void InMemoryBaseRepositoryTest_GetById_When_Element_Present_For_Key_Should_Return_Element()
        {
            //Arrange
            const int key = 1;

            //Act
            var element = _repository.GetById(key);

            //Assert
            element.Should().NotBeNull();
            element.Id.Should().Be(key);
        }

        [Test]
        public void InMemoryBaseRepositoryTest_GetById_When_Element_Not_Present_For_Key_Should_Return_Null()
        {
            //Act
            var element = _repository.GetById(-1);

            //Assert
            element.Should().BeNull();
        }

        #endregion
        #region GetManyByIds


        [Test]
        public void InMemoryBaseRepositoryTest_GetManyByIds_When_Element_Present_For_Key_Should_Return_Element()
        {
            //Arrange
            const int key = 1;

            //Act
            var elements = _repository.GetManyByIds(key).ToArray();

            //Assert
            elements.Count().Should().Be(1);
            CollectionContainsKey(elements, key);
        }

        [Test]
        public void InMemoryBaseRepositoryTest_GetManyByIds_When_Elements_Present_For_Keys_Should_Return_Elements()
        {
            const int keyA = 1;
            const int keyB = 2; 

            //Act
            var elements = _repository.GetManyByIds(keyA,keyB).ToArray();

            //Assert
            elements.Count().Should().Be(2);
            CollectionContainsKey(elements, keyA);
            CollectionContainsKey(elements, keyB);
        }

        [Test]
        public void InMemoryBaseRepositoryTest_GetManyByIds_When_No_Elements_Present_For_Keys_Should_Return_Empty()
        {
            //Act
            var elements = _repository.GetManyByIds(-1, -2);

            //Assert
            elements.Count().Should().Be(0);
        }

        #endregion

        #region Add

        [Test]
        public void InMemoryBaseRepositoryTest_Add_When_Object_Added_To_Collection_Should_Get_Assigned_Id()
        {
            //Arrange
            var testEntity = new TestModel(); 
            //Act
            var addedEntity = _repository.Add(testEntity);

            //Assert
            addedEntity.Id.Should().NotBe(0);
        }

        [Test]
        public void InMemoryBaseRepositoryTest_Add_When_Object_Added_To_Collection_Count_Should_Increase_By_One()
        {
            //Arrange
            var initCount = _repository.Count();
            //Act
            _repository.Add(new TestModel());

            //Assert
            var countAfterAdd = _repository.Count();

            (initCount + 1).Should().Be(countAfterAdd);
        }


        #endregion


        #region TestClasses
        private class TestModel : IEntity<int>
        {
            public int Id { get; set; }

            public string Name { get; set; }
        }

        private class TestInMemoryRepository : InMemoryRepository<TestModel, int>
        {        
            public TestInMemoryRepository()
            {
                Collection = new List<TestModel>
                {
                    new TestModel()
                    {
                        Id = Nextval()
                    },
                    new TestModel()
                    {
                        Id = Nextval()
                    },
                };
            }
        }
        #endregion

        private static void CollectionContainsKey(IEnumerable<TestModel> elements, int keyA)
        {
            elements.Any(e => e.Id == keyA).Should().BeTrue();
        }

    }
}
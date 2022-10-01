using System;
using Faker;
using NUnit.Framework;

namespace FakerTests.Faker
{
    public class FakerTest
    {
        private IFaker _faker;
        
        [SetUp]
        public void Setup()
        {
            _faker = new global::Faker.Faker();
        }

        [Test]
        public void CreateInt()
        {
            //Arrange
            Type targetType = typeof(int);
            
            //Act
            var testValue = _faker.Create<int>();
            
            //Assert
            Assert.IsInstanceOf(targetType, testValue);
        }

        
        
        [Test]
        public void CreateEmptyClass()
        {
            //Arrange
            Type targetType = typeof(FakerModels.EmptyClass);
            
            //Act
            var testValue = _faker.Create<FakerModels.EmptyClass>();
            
            //Assert
            Assert.IsInstanceOf(targetType, testValue);
        }
        
        [Test]
        public void CreateSimpleFieldsClass()
        {
            //Arrange
            Type targetType = typeof(FakerModels.SimpleFieldsClass);
            
            //Act
            var testValue = _faker.Create<FakerModels.SimpleFieldsClass>();
            
            //Assert
            Assert.IsInstanceOf(targetType, testValue);
            Assert.NotNull(testValue.X);
            Assert.NotNull(testValue.Y);
            Assert.NotNull(testValue.Z);
        }
        
        [Test]
        public void CreateTwoConstructorsClass()
        {
            //Arrange
            Type targetType = typeof(FakerModels.TwoConstructorsClass);
            
            //Act
            var testValue = _faker.Create<FakerModels.TwoConstructorsClass>();
            
            //Assert
            Assert.IsInstanceOf(targetType, testValue);
            Assert.NotNull(testValue.X);
            Assert.NotNull(testValue.Y);
            Assert.NotNull(testValue.Z);
        }
        
        [Test]
        public void CreateClassWithPrivateConstructor()
        {
            //Arrange
            Type targetType = typeof(FakerModels.PrivateConstructorClass);
            
            //Act
            var testValue = _faker.Create<FakerModels.PrivateConstructorClass>();
            
            //Assert
            Assert.Null(testValue);
        }
        
        [Test]
        public void CreateClassWithoutConstructor()
        {
            //Arrange
            Type targetType = typeof(FakerModels.WithoutConstructorClass);
            
            //Act
            var testValue = _faker.Create<FakerModels.WithoutConstructorClass>();
            
            //Assert
            Assert.IsInstanceOf(targetType, testValue);
            Assert.NotNull(testValue.X);
            Assert.NotNull(testValue.Y);
            Assert.NotNull(testValue.Z);
        }
        
        [Test]
        public void CreatePropertiesClass()
        {
            //Arrange
            Type targetType = typeof(FakerModels.PropertiesClass);
            
            //Act
            var testValue = _faker.Create<FakerModels.PropertiesClass>();
            
            //Assert
            Assert.IsInstanceOf(targetType, testValue);
            Assert.NotNull(testValue.X);
            Assert.NotNull(testValue.Y);
            Assert.Null(testValue.Z);
        }
        
        [Test]
        public void CreateClassWithInnerClass()
        {
            //Arrange
            Type targetType = typeof(FakerModels.ClassWithInnerClass);
            
            //Act
            var testValue = _faker.Create<FakerModels.ClassWithInnerClass>();
            
            //Assert
            Assert.IsInstanceOf(targetType, testValue);
            Assert.NotNull(testValue.X);
            Assert.NotNull(testValue.Y);
            Assert.NotNull(testValue.Z);
        }
        
        [Test]
        public void CreateRecursiveFieldClass()
        {
            //Arrange
            Type targetType = typeof(FakerModels.RecursiveFieldClass);
            
            //Act
            var testValue = _faker.Create<FakerModels.RecursiveFieldClass>();
            
            //Assert
            Assert.IsInstanceOf(targetType, testValue);
        }
        
        [Test]
        public void CreateListClass()
        {
            //Arrange
            Type targetType = typeof(FakerModels.ListClass);
            
            //Act
            var testValue = _faker.Create<FakerModels.ListClass>();
            
            //Assert
            Assert.IsInstanceOf(targetType, testValue);
            Assert.NotNull(testValue.List);
            Assert.NotZero(testValue.List.Count);
        }
        
        [Test]
        public void DedicatedGeneratorsClass()
        {
            //Arrange
            Type targetType = typeof(FakerModels.DedicatedGeneratorsClass);
            
            //Act
            var testValue = _faker.Create<FakerModels.DedicatedGeneratorsClass>();
            
            //Assert
            Assert.IsInstanceOf(targetType, testValue);
            Assert.NotNull(testValue.X);
            Assert.NotNull(testValue.Y);
        }
        
        [Test]
        public void DateTimeClass()
        {
            //Arrange
            Type targetType = typeof(FakerModels.DateTimeClass);
            
            //Act
            var testValue = _faker.Create<FakerModels.DateTimeClass>();
            
            //Assert
            Assert.IsInstanceOf(targetType, testValue);
            Assert.NotNull(testValue.Time);
        }

        [Test]
        public void CreateSimpleStruct()
        {
            //Arrange
            Type targetType = typeof(FakerModels.SimpleFieldsStruct);

            //Act
            var testValue = _faker.Create<FakerModels.SimpleFieldsStruct>();
            
            //Assert
            Assert.IsInstanceOf(targetType, testValue);
            Assert.NotNull(testValue.X);
            Assert.NotNull(testValue.Y);
        }
    }
}
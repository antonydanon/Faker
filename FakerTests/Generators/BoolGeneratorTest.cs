using System;
using Faker.GeneratorContext;
using Faker.Generators;
using NUnit.Framework;

namespace FakerTests.Generators
{
    public class BoolGeneratorTest
    {
        private BoolGenerator _boolGenerator = new BoolGenerator();
        private Type _type = typeof(bool);
        private Context _context = new Context(new Random(), new global::Faker.Faker());

        [Test]
        public void GenerateBoolTest()
        {
            var actualResult = _boolGenerator.Generate(_type, _context);

            Assert.True(actualResult is bool);
            Assert.True((bool)actualResult || !(bool)actualResult);
        }
        
        [Test]
        public void CanGenerateBoolTest()
        {
            var boolResult = _boolGenerator.CanGenerate(_type);
            var byteResult = _boolGenerator.CanGenerate(typeof(byte));

            Assert.True(boolResult);
            Assert.False(byteResult);
        }
    }
}
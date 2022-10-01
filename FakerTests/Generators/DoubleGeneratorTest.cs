using System;
using Faker.GeneratorContext;
using Faker.Generators;
using NUnit.Framework;

namespace FakerTests.Generators
{
    public class DoubleGeneratorTest
    {
        private DoubleGenerator _doubleGenerator = new();
        private Type _type = typeof(double);
        private Context _context = new(new Random(), new global::Faker.Faker());

        [Test]
        public void GenerateDoubleTest()
        {
            var actualResult = _doubleGenerator.Generate(_type, _context);

            Assert.True(actualResult is double);
            Assert.True((double)actualResult >= double.MinValue && (double)actualResult <= double.MaxValue);
        }
        
        [Test]
        public void CanGenerateDoubleTest()
        {
            var byteResult = _doubleGenerator.CanGenerate(typeof(byte));
            var doubleResult = _doubleGenerator.CanGenerate(typeof(double));

            Assert.True(doubleResult);
            Assert.False(byteResult);
        }
    }
}
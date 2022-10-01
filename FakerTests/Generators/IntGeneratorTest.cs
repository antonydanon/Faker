using System;
using Faker.GeneratorContext;
using Faker.Generators;
using NUnit.Framework;

namespace FakerTests.Generators
{
    public class IntGeneratorTest
    {
        private IntGenerator _intGenerator = new();
        private Type _type = typeof(int);
        private Context _context = new(new Random(), new global::Faker.Faker());

        [Test]
        public void GenerateIntTest()
        {
            var actualResult = _intGenerator.Generate(_type, _context);

            Assert.True(actualResult is int);
            Assert.True((int)actualResult >= int.MinValue && (int)actualResult <= int.MaxValue);
        }
        
        [Test]
        public void CanGenerateIntTest()
        {
            var byteResult = _intGenerator.CanGenerate(typeof(byte));
            var intResult = _intGenerator.CanGenerate(typeof(int));

            Assert.True(intResult);
            Assert.False(byteResult);
        }
    }
}
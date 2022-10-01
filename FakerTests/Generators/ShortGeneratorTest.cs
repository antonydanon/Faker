using System;
using Faker.GeneratorContext;
using Faker.Generators;
using NUnit.Framework;

namespace FakerTests.Generators
{
    public class ShortGeneratorTest
    {
        private ShortGenerator _shortGenerator = new();
        private Type _type = typeof(short);
        private Context _context = new(new Random(), new global::Faker.Faker());

        [Test]
        public void GenerateShortTest()
        {
            var actualResult = _shortGenerator.Generate(_type, _context);

            Assert.True(actualResult is short);
            Assert.True((short)actualResult >= short.MinValue && (short)actualResult <= short.MaxValue);
        }
        
        [Test]
        public void CanGenerateShortTest()
        {
            var byteResult = _shortGenerator.CanGenerate(typeof(byte));
            var shortResult = _shortGenerator.CanGenerate(typeof(short));

            Assert.True(shortResult);
            Assert.False(byteResult);
        }
    }
}
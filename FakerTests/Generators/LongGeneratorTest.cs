using System;
using Faker.GeneratorContext;
using Faker.Generators;
using NUnit.Framework;

namespace FakerTests.Generators
{
    public class LongGeneratorTest
    {
        private LongGenerator _longGenerator = new();
        private Type _type = typeof(long);
        private Context _context = new(new Random(), new global::Faker.Faker());

        [Test]
        public void GenerateLongTest()
        {
            var actualResult = _longGenerator.Generate(_type, _context);

            Assert.True(actualResult is long);
            Assert.True((long)actualResult >= long.MinValue && (long)actualResult <= long.MaxValue);
        }
        
        [Test]
        public void CanGenerateLongTest()
        {
            var byteResult = _longGenerator.CanGenerate(typeof(byte));
            var longResult = _longGenerator.CanGenerate(typeof(long));

            Assert.True(longResult);
            Assert.False(byteResult);
        }
    }
}
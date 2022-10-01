using System;
using Faker.GeneratorContext;
using Faker.Generators;
using NUnit.Framework;

namespace FakerTests.Generators
{
    public class StringGeneratorTest
    {
        private StringGenerator _stringGenerator = new();
        private Type _type = typeof(string);
        private Context _context = new(new Random(), new global::Faker.Faker());

        [Test]
        public void GenerateStringTest()
        {
            var actualResult = _stringGenerator.Generate(_type, _context);

            Assert.True(actualResult is string);
            foreach (var ch in (string)actualResult)
            {
                Assert.True(ch >= char.MinValue && ch <= char.MaxValue);
            }
        }
        
        [Test]
        public void CanGenerateStringTest()
        {
            var byteResult = _stringGenerator.CanGenerate(typeof(byte));
            var stringResult = _stringGenerator.CanGenerate(typeof(string));

            Assert.True(stringResult);
            Assert.False(byteResult);
        }
    }
}
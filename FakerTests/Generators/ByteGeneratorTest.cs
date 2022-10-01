using System;
using Faker.GeneratorContext;
using Faker.Generators;
using NUnit.Framework;

namespace FakerTests.Generators
{
    public class ByteGeneratorTest
    {
        private ByteGenerator _byteGenerator = new ByteGenerator();
        private Type _type = typeof(byte);
        private Context _context = new Context(new Random(), new global::Faker.Faker());

        [Test]
        public void GenerateByteTest()
        {
            var actualResult = _byteGenerator.Generate(_type, _context);

            Assert.True(actualResult is byte);
            Assert.True((byte)actualResult >= byte.MinValue && (byte)actualResult <= byte.MaxValue);
        }
        
        [Test]
        public void CanGenerateByteTest()
        {
            var byteResult = _byteGenerator.CanGenerate(typeof(byte));
            var boolResult = _byteGenerator.CanGenerate(typeof(bool));

            Assert.False(boolResult);
            Assert.True(byteResult);
        }
    }
}
using System;
using Faker.GeneratorContext;
using Faker.Generators;
using NUnit.Framework;

namespace FakerTests.Generators
{
    public class CharGeneratorTest
    {
        private CharGenerator _charGenerator = new CharGenerator();
        private Type _type = typeof(char);
        private Context _context = new Context(new Random(), new global::Faker.Faker());

        [Test]
        public void GenerateCharTest()
        {
            var actualResult = _charGenerator.Generate(_type, _context);

            Assert.True(actualResult is char);
            Assert.True((char)actualResult >= char.MinValue && (char)actualResult <= char.MaxValue);
        }
        
        [Test]
        public void CanGenerateCharTest()
        {
            var byteResult = _charGenerator.CanGenerate(typeof(byte));
            var charResult = _charGenerator.CanGenerate(typeof(char));

            Assert.True(charResult);
            Assert.False(byteResult);
        }
    }
}
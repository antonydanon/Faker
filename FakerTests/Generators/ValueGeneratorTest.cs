using System;
using Faker.Exception;
using Faker.GeneratorContext;
using Faker.Generators;
using Microsoft.VisualBasic;
using NUnit.Framework;

namespace FakerTests.Generators
{
    public class ValueGeneratorTest
    {
        private ValueGenerator _valueGenerator = new();
        private Type _type = typeof(char);
        private Context _context = new(new Random(), new global::Faker.Faker());

        [Test]
        public void GenerateValueTest()
        {
            var actualResult = _valueGenerator.Generate(_type, _context);

            Assert.True(actualResult is char);
            Assert.True((char)actualResult >= char.MinValue && (char)actualResult <= char.MaxValue);
            Assert.Catch<PrimitiveGenerationException>(() => _valueGenerator.Generate(typeof(DateTimeGeneratorTest), _context));
        }
        
        [Test]
        public void CanGenerateValueTest()
        {
            var byteResult = _valueGenerator.CanGenerate(typeof(byte));
            var stringResult = _valueGenerator.CanGenerate(typeof(string));
            var dateFormatResult = _valueGenerator.CanGenerate(typeof(DateFormat));

            Assert.True(stringResult);
            Assert.True(byteResult);
            Assert.False(dateFormatResult);
        }
    }
}
using System;
using Faker.GeneratorContext;
using Faker.Generators;
using NUnit.Framework;

namespace FakerTests.Generators
{
    public class FloatGeneratorTest
    {
        private FloatGenerator _floatGenerator = new();
        private Type _type = typeof(float);
        private Context _context = new(new Random(), new global::Faker.Faker());

        [Test]
        public void GenerateFloatTest()
        {
            var actualResult = _floatGenerator.Generate(_type, _context);

            Assert.True(actualResult is float);
            Assert.True((float)actualResult >= float.MinValue && (float)actualResult <= float.MaxValue);
        }
        
        [Test]
        public void CanGenerateFloatTest()
        {
            var byteResult = _floatGenerator.CanGenerate(typeof(byte));
            var floatResult = _floatGenerator.CanGenerate(typeof(float));

            Assert.True(floatResult);
            Assert.False(byteResult);
        }
    }
}
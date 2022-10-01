using System;
using Faker.GeneratorContext;
using Faker.Generators;
using NUnit.Framework;

namespace FakerTests.Generators
{
    public class DateTimeGeneratorTest
    {
        private DateTimeGenerator _dateTimeGenerator = new();
        private Type _type = typeof(DateTime);
        private Context _context = new(new Random(), new global::Faker.Faker());

        [Test]
        public void GenerateDateTimeTest()
        {
            var actualResult = _dateTimeGenerator.Generate(_type, _context);

            Assert.True(actualResult is DateTime);
            Assert.True((DateTime)actualResult >= DateTime.MinValue && (DateTime)actualResult <= DateTime.MaxValue);
        }
        
        [Test]
        public void CanGenerateDateTimeTest()
        {
            var byteResult = _dateTimeGenerator.CanGenerate(typeof(byte));
            var dateTimeResult = _dateTimeGenerator.CanGenerate(typeof(DateTime));

            Assert.True(dateTimeResult);
            Assert.False(byteResult);
        }
    }
}
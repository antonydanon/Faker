using System;
using Faker.GeneratorContext;
using Faker.Generators;

namespace ByteGenerator
{
    public class ByteGenerator : IValueGenerator
    {
        public object Generate(Type typeToGenerate, Context context)
        {
            return (byte)context.Random.Next(0, 255);
        }

        public bool CanGenerate(Type type)
        {
            return type == typeof(byte);
        }
    }
}
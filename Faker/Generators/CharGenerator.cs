using System;
using Faker.GeneratorContext;

namespace Faker.Generators
{
    public class CharGenerator : IValueGenerator
    {
        public object Generate(Type typeToGenerate, Context context)
        {
            return (char)context.Random.Next(0, 255);
        }

        public bool CanGenerate(Type type)
        {
            return type == typeof(char);
        }
    }
}
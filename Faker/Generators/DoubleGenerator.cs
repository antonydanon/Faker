using System;
using Faker.GeneratorContext;

namespace Faker.Generators
{
    public class DoubleGenerator : IValueGenerator
    {
        public object Generate(Type typeToGenerate, Context context)
        {
            return context.Random.NextDouble();
        }

        public bool CanGenerate(Type type)
        {
            return type == typeof(double);
        }
    }
}
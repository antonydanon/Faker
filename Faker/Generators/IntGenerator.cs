using System;
using Faker.GeneratorContext;

namespace Faker.Generators
{
    public class IntGenerator : IValueGenerator
    {
        public object Generate(Type typeToGenerate, Context context)
        {
            return context.Random.Next();
        }

        public bool CanGenerate(Type type)
        {
            return type == typeof(int);
        }
    }
}
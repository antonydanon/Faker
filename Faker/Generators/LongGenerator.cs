using System;
using Faker.GeneratorContext;

namespace Faker.Generators
{
    public class LongGenerator : IValueGenerator
    {
        public object Generate(Type typeToGenerate, Context context)
        {
            return context.Random.Next() << 32 | (uint)context.Random.Next();
        }

        public bool CanGenerate(Type type)
        {
            return type == typeof(long);                        
        }
    }
}
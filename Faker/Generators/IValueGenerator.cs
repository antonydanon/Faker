using System;
using Faker.GeneratorContext;

namespace Faker.Generators
{
    public interface IValueGenerator
    {
        object Generate(Type typeToGenerate, Context context);

        bool CanGenerate(Type type);
    }
}
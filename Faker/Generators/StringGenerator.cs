using System;
using System.Text;
using Faker.GeneratorContext;

namespace Faker.Generators
{
    public class StringGenerator : IValueGenerator
    {
        public object Generate(Type typeToGenerate, Context context)
        {
            var str = new StringBuilder();
            var length = context.Random.Next(0, 10);
            for (int i = 0; i < length; i++)
                str.Append((char)context.Random.Next(0, 255));
            return str.ToString();
        }

        public bool CanGenerate(Type type)
        {
            return type == typeof(string);
        }
    }
}
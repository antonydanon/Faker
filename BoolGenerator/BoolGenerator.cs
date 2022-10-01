﻿using System;
using Faker.GeneratorContext;

namespace Faker.Generators
{
    public class BoolGenerator : IValueGenerator
    {
        public object Generate(Type typeToGenerate, Context context)
        {
            return context.Random.Next(2) == 1;
        }

        public bool CanGenerate(Type type)
        {
            return type == typeof(bool);
        }
    }
}
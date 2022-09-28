using System;

namespace Faker.GeneratorContext
{
    public class Context
    {
        public Random Random { get; } 
        public IFaker Faker { get; }
        
        public Context(Random random, Faker faker)
        {
            Random = random;
            Faker = faker;
        }
    }
}
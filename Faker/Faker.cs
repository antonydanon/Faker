using System;

namespace Faker
{
    public class Faker : IFaker
    {
        public T Create<T>()
        {
            return (T)Create(typeof(T));
        }

        private object Create(Type t)
        {
            throw new NotImplementedException();
        }
    }
}
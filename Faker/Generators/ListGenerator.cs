using System;
using System.Collections;
using System.Linq;
using Faker.GeneratorContext;

namespace Faker.Generators
{
    public class ListGenerator : IValueGenerator
    {
        public object Generate(Type type, Context context)
        {
            var genericTypeArgument = type.GenericTypeArguments[0];
            var listObject = Activator.CreateInstance(type);

            var length = context.Random.Next(10);
            
            var executeMethod = context.Faker
                .GetType()
                .GetMethod("Create")?
                .MakeGenericMethod(genericTypeArgument);

            for (int i = 0; i < length; i++)
            {
                var obj = new []{
                    executeMethod?.Invoke(context.Faker, new object[]{})
                };
                
                type.GetMethod("Add")?.Invoke(listObject, obj);
            }

            return listObject;
        }

        public bool CanGenerate(Type type)
        {
            var interfaces = type.GetInterfaces();
            return interfaces.Contains(typeof(IList)) && type.IsGenericType;
        }
    }
}
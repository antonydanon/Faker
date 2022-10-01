using System;
using System.Reflection;
using Faker.GeneratorContext;
using Faker.Generators;

namespace Faker
{
    public class Faker : IFaker
    {

        private Context _context;
        private ValueGenerator _valueGenerator;
        
        public Faker()
        {
            _context = new Context(new Random(), this);
            _valueGenerator = new ValueGenerator();
        }
        public T Create<T>()
        {
            return (T)Create(typeof(T));
        }
        
        private object Create(Type type)
        {
            object obj;
            if (_valueGenerator.CanGenerate(type))
            {
                obj = _valueGenerator.Generate(type, _context);
            }
            else
            {
                ConstructorInfo constructorInfo = getConstructorWithMaxCountOfParams(type);
                var paramValues = new object[constructorInfo.GetParameters().Length];
                for (int i = 0; i < paramValues.Length; i++)
                {
                    if(_valueGenerator.CanGenerate(constructorInfo.GetParameters()[i].ParameterType))
                        paramValues[i] = _valueGenerator.Generate(constructorInfo.GetParameters()[i].ParameterType, _context);
                    else
                        paramValues[i] = Create(constructorInfo.GetParameters()[i].ParameterType);
                    
                }
                obj = constructorInfo.Invoke(paramValues);

                /*FieldInfo[] fields = type.GetFields();
                foreach (var field in fields)
                {
                    if (_valueGenerator.CanGenerate(field.FieldType))
                    {
                        field.SetValue(obj, _valueGenerator.Generate(field.FieldType, _context));
                    }
                    else
                    {
                        field.SetValue(obj, Create(field.FieldType));
                    }
                }*/
            }

            return obj;
        }
        
        private ConstructorInfo getConstructorWithMaxCountOfParams(Type type)
        {
            ConstructorInfo[] constructors = type.GetConstructors();

            if (constructors.Length == 1)
                return constructors[0];

            int indexOfConstructorWithMaxCountOfparams = 0;

            for (int i = 1; i < constructors.Length; i++)
            {
                if (constructors[i - 1].GetParameters().Length < constructors[i].GetParameters().Length)
                    indexOfConstructorWithMaxCountOfparams = i;
            }

            return constructors[indexOfConstructorWithMaxCountOfparams];
        }
    }
}
using System;
using System.Collections.Generic;
using System.Reflection;
using Faker.Checker;
using Faker.Exception;
using Faker.GeneratorContext;
using Faker.Generators;

namespace Faker
{
    public class Faker : IFaker
    {

        private Context _context;
        private ValueGenerator _valueGenerator;
        private DependenciesChecker _dependenciesChecker;
        
        public Faker()
        {
            _context = new Context(new Random(), this);
            _valueGenerator = new ValueGenerator();
            _dependenciesChecker = new DependenciesChecker();
        }
        public T Create<T>()
        {
            return (T)Create(typeof(T));
        }
        
        private object Create(Type type)
        {
            object obj;
            _dependenciesChecker.Add(type);
            if (!_dependenciesChecker.IsMaxDepth())
            {
                if (_valueGenerator.CanGenerate(type))
                {
                    obj = _valueGenerator.Generate(type, _context);
                }
                else
                {
                    var setParams = new HashSet<string>();
                    obj = CreatWithConstructor(type, ref setParams);
                    SetFields(ref obj, type, setParams);
                    SetProperties(ref obj, type, setParams);
                }    
            }
            else
            {
                obj = null;
            }
            _dependenciesChecker.Delete(type);

            return obj;
        }

        private object CreatWithConstructor(Type type, ref HashSet<string> setParams)
        {
            ConstructorInfo constructorInfo = getConstructorWithMaxCountOfParams(type);
            var paramValues = new object[constructorInfo.GetParameters().Length];
            for (int i = 0; i < paramValues.Length; i++)
            {
                if(_valueGenerator.CanGenerate(constructorInfo.GetParameters()[i].ParameterType))
                    paramValues[i] = _valueGenerator.Generate(constructorInfo.GetParameters()[i].ParameterType, _context);
                else
                    paramValues[i] = Create(constructorInfo.GetParameters()[i].ParameterType);

                setParams.Add(constructorInfo.GetParameters()[i].Name);
            }
            return constructorInfo.Invoke(paramValues);    
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
        
        private void SetFields(ref object obj, Type t, HashSet<string> setParams)
        {
            var fields = t.GetFields();
            foreach (var field in fields)
            {
                if (!setParams.Contains(field.Name))
                {
                    field.SetValue(obj, _valueGenerator.CanGenerate(field.FieldType)
                            ? _valueGenerator.Generate(field.FieldType, _context)
                            : Create(field.FieldType));
                }
            }
        }

        private void SetProperties(ref object obj, Type t, HashSet<string> setParams)
        {
            var properties = t.GetProperties();
            foreach (var property in properties)
            {
                if (!setParams.Contains(property.Name))
                {
                    if (property.CanWrite)
                    {
                        property.SetValue(obj, _valueGenerator.CanGenerate(property.PropertyType)
                                ? _valueGenerator.Generate(property.PropertyType, _context)
                                : Create(property.PropertyType));
                    }
                }
            }
        }
    }
}
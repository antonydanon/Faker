using System;
using System.Linq;
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
        
        public object Create(Type type)
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
                    obj = CreatWithConstructor(type);
                    SetFields(ref obj, type);
                    SetProperties(ref obj, type);
                }    
            }
            else
            {
                obj = null;
            }
            _dependenciesChecker.Delete(type);

            return obj;
        }

        private IOrderedEnumerable<ConstructorInfo> GetConstructors(Type type)
        {
            return type.GetConstructors().OrderByDescending(i => i.GetParameters().Length);
        }

        private object CreatWithConstructor(Type type)
        {
            IOrderedEnumerable<ConstructorInfo> constructorInfos = GetConstructors(type);
            foreach (var constructorInfo in constructorInfos)
            {
                try
                {
                    var paramValues = new object[constructorInfo.GetParameters().Length];
                    for (int i = 0; i < paramValues.Length; i++)
                    {
                        if (_valueGenerator.CanGenerate(constructorInfo.GetParameters()[i].ParameterType))
                            paramValues[i] = _valueGenerator.Generate(constructorInfo.GetParameters()[i].ParameterType,
                                _context);
                        else
                            paramValues[i] = Create(constructorInfo.GetParameters()[i].ParameterType);
                    }

                    return constructorInfo.Invoke(paramValues);
                }
                catch (System.Exception e)
                {
                }
            }

            try
            {
                return Activator.CreateInstance(type)!;
            }
            catch (System.Exception e)
            {
            }

            throw new CanNotCreateTheObject();
        }

        private void SetFields(ref object obj, Type t)
        {
            var fields = t.GetFields();
            foreach (var field in fields)
            {
                if (field.GetValue(obj) != null && field.GetValue(obj).Equals(GetDefaultObjectValueType(t))) continue;
                field.SetValue(obj, _valueGenerator.CanGenerate(field.FieldType)
                            ? _valueGenerator.Generate(field.FieldType, _context)
                            : Create(field.FieldType));
                
            }
        }

        private void SetProperties(ref object obj, Type t)
        {
            var properties = t.GetProperties();
            foreach (var property in properties)
            {
                if (property.GetValue(obj) != null && property.GetValue(obj).Equals(GetDefaultObjectValueType(t))) continue;
                if (!property.CanWrite) continue;
                    property.SetValue(obj, _valueGenerator.CanGenerate(property.PropertyType)
                        ? _valueGenerator.Generate(property.PropertyType, _context)
                        : Create(property.PropertyType));
            }
        }

        private object GetDefaultObjectValueType(Type type)
        {
            return type.IsValueType ? Activator.CreateInstance(type) : null;
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Faker.Exception;
using Faker.GeneratorContext;

namespace Faker.Generators
{
    public class ValueGenerator : IValueGenerator
    {
        private IList<IValueGenerator> _generators;

        public ValueGenerator()
        {
            _generators = Assembly.GetExecutingAssembly().DefinedTypes
                .Where(t => t.GetInterface(nameof(IValueGenerator)) != null && t.IsClass && t != typeof(ValueGenerator))
                .Select(t => (IValueGenerator)Activator.CreateInstance(t)).ToList();
            GetPlugins();
        }
        
        private void GetPlugins()
        {
            var files = Directory.EnumerateFiles("Generators", "*.dll");
            foreach (var file in files)
            {
                var generatorAssembly = Assembly.LoadFrom(file);
                var types = generatorAssembly.GetTypes();
                foreach (var type in types)
                {
                    if (type.GetInterface(nameof(IValueGenerator)) == null) 
                        continue;
                    var generator = (IValueGenerator?)Activator.CreateInstance(type);
                    if (generator == null)
                    {
                        throw new System.Exception($"Generator {type.ToString()} has not been created");
                    }
                    _generators.Add(generator);
                }
            }
        }

        public object Generate(Type typeToGenerate, Context context)
        {
            foreach (var generator in _generators)
            {
                if (generator.CanGenerate(typeToGenerate))
                {
                    return generator.Generate(typeToGenerate, context);
                }
            }

            throw new PrimitiveGenerationException("No one generator matches!");
        }

        public bool CanGenerate(Type type)
        {
            for (int i = 0; i < _generators.Count; i++)
            {
                if (_generators[i].CanGenerate(type))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
using System;
using System.Collections.Generic;
using Faker.GeneratorContext;
using Faker.Generators;

namespace FakerTests.Faker
{
    public class FakerModels
    {
        public class EmptyClass
    {
        
    }

    public class SimpleFieldsClass
    {
        public int? X;
        public bool? Y;
        public double? Z;

        public SimpleFieldsClass(int x, bool y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }

    public class TwoConstructorsClass
    {
        public int? X;
        public bool? Y;
        public double? Z;

        public TwoConstructorsClass(int x, bool y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public TwoConstructorsClass(int x, bool y)
        {
            X = x;
            Y = y;
        }
    }

    public class PrivateConstructorClass
    {
        public int? X;

        private PrivateConstructorClass(int x)
        {
            X = x;
        }
    }

    public class WithoutConstructorClass
    {
        public int? X;
        public bool? Y;
        public double? Z;
    }
    
    public class PropertiesClass
    {
        public int? X { get; set; }
        public bool? Y { get; set; }
        public double? Z { get; }
    }

    public class ClassWithInnerClass
    {
        public int? X;
        public bool? Y;
        public SimpleFieldsClass Z;

        public ClassWithInnerClass(int x, bool y, SimpleFieldsClass z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }

    public class RecursiveFieldClass
    {
        public RecursiveFieldClass field;
    }

    public class ListClass
    {
        public List<RecursiveFieldClass> List;
    }

    public class DedicatedGeneratorsClass
    {
        public long? X;
        public float? Y;
    }

    public class DateTimeClass
    {
        public DateTime? Time;
    }

    public class CustomIntGenerator : IValueGenerator
    {
        public object Generate(Type typeToGenerate, Context generatorContext)
        {
            return 1;
        }

        public bool CanGenerate(Type type)
        {
            return true;
        }
    }
    
    public class CustomConfigureFieldClass
    {
        public int? testField;
    }

    public class CustomConfigurePropertyClass
    {
        public int? TestField { get; }

        public CustomConfigurePropertyClass(int testField)
        {
            TestField = testField;
        }
    }

    public struct SimpleFieldsStruct
    {
        public int? X;
        public bool? Y;

        public SimpleFieldsStruct(int? x, bool? y)
        {
            X = x;
            Y = y;
        }
    }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace Faker.Checker
{
    public class DependenciesChecker
    {
        const int MAX_NESTING = 2;
        private Dictionary<Type, int> _dependencyCounter = new(); 
    
        public void Add(Type type)
        {
            if (_dependencyCounter.ContainsKey(type))
                _dependencyCounter[type] += 1;
            else
                _dependencyCounter.Add(type, 1);
        }

        public void Delete(Type type)
        {
            if (_dependencyCounter.ContainsKey(type) && _dependencyCounter[type] > 1)
                _dependencyCounter[type] -= 1;
            else
                _dependencyCounter.Remove(type);
        }

        public bool IsMaxDepth()
        {
            foreach (var typeCount in _dependencyCounter.Values)
                if (typeCount > MAX_NESTING)
                    return true;
            
            return false;
        }
    }
}
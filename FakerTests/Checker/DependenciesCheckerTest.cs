using Faker.Checker;
using NUnit.Framework;

namespace FakerTests.Checker
{
    public class DependenciesCheckerTest
    {
        private DependenciesChecker _checker = new();
        
        [Test]
        public void AddTest()
        {
            _checker.Add(typeof(int));

            int count = _checker._dependencyCounter[typeof(int)];
            
            Assert.True(count == 1);
        }
        
        [Test]
        public void DeleteTest()
        {
            _checker.Add(typeof(int));
            _checker.Add(typeof(int));
            
            _checker.Delete(typeof(int));
            int count = _checker._dependencyCounter[typeof(int)];
            
            Assert.True(count == 1);
        }
        
        [Test]
        public void IsMaxDepthTest()
        {
            _checker.Add(typeof(int));
            
            Assert.False(_checker.IsMaxDepth());
            
            _checker.Add(typeof(int));
            _checker.Add(typeof(int));
            
            Assert.True(_checker.IsMaxDepth());
        }
    }
}
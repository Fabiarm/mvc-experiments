using Mvc.Experiments.Domain.Interfaces;
using System;

namespace Mvc.Experiments.Domain.Services
{
    public class TestService : ITestService
    {
        public TestService()
        {

        }
        public string GetTestMethod1(int param1)
        {
            if (param1 <= 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(param1)} should be positive.");
            }
            return $"Hello [Test method 1] with param value:{param1}!";
        }

        public string GetTestMethod1(int param1, int param2)
        {
            if (param1 <= 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(param1)} should be positive.");
            }
            if (param2 <= 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(param2)} should be positive.");
            }
            return $"Hello [(Advanced)Test method 1] with param1:{param1} and param2:{param2}!";
        }

        public string GetTestMethod2()
        {
            return $"Hello [Test method 2]!";
        }
    }
}

using Mvc.Experiments.Domain.Interfaces;

namespace Mvc.Experiments.Domain.Services
{
    public class TestService : ITestService
    {
        public TestService()
        {

        }
        public string GetTestMethod1()
        {
            return "Hello [Test method 1]!";
        }
    }
}

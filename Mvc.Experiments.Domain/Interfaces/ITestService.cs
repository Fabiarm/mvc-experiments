namespace Mvc.Experiments.Domain.Interfaces
{
    public interface ITestService
    {
        string GetTestMethod1(int param1);
        string GetTestMethod1(int param1, int param2);
        string GetTestMethod2();
    }
}

using DesignPattern.AbstractFactory.Abstracts;

namespace DesignPattern.AbstractFactory.ConcreteTypes
{
    public class AppleTestRunSuite : ITestRunSuite
    {
        public void Run()
        {
            Console.WriteLine($"Running Test Suite for {nameof(AppleTestRunSuite)}");
        }
    }
}

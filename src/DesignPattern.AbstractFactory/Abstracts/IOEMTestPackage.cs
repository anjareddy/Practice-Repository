using DesignPattern.FactoryPattern;

namespace DesignPattern.AbstractFactory.Abstracts
{
    public interface IOEMTestPackage
    {
        ITestRunSuite GetTestRunSuite();

        IReportGenerator GetReportGenerator(ICalculator calculator);
    }
}

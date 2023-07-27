using DesignPattern.Common.Enums;
using DesignPattern.Common.Models;

namespace DesignPattern.AdapterPattern
{
    public interface ITestToolAdapter
    {
        TestResultEnum Run(Test test);
    }
}
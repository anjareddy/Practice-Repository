using DesignPattern.Common.Enums;
using DesignPattern.Common.Models;

namespace DesignPattern.AdapterPattern
{
    public class IOMeterAdapter : ITestToolAdapter
    {
        private readonly IOMeterAdaptee adaptee;

        public IOMeterAdapter(IOMeterAdaptee prerequiteExecuter)
        {
            adaptee = prerequiteExecuter;
        }

        public TestResultEnum Run(Test test)
        {
            adaptee.LoadDataRandomlyOnDUT(test);
            Console.WriteLine("Running IOMeter Application");
            return adaptee.Execute(test);
        }
    }

    public class IOMeterAdaptee
    {
        public void LoadDataRandomlyOnDUT(Test test)
        {
            Console.WriteLine(test.Name);
            Console.WriteLine(test.Description);
            Console.WriteLine("Loading data randomly before starting the test as per prerequisite.");
        }

        internal TestResultEnum Execute(Test test)
        {
            Console.WriteLine(Argument.IsNull(test.Configuration) ? "NoConfiguration" : test.Configuration);
            Console.WriteLine(Argument.IsNull(test.PrerequisiteInfo) ? "NoPrerequisite" : test.PrerequisiteInfo);
            Console.WriteLine("Executing Test");
            Console.WriteLine("Saving test data to Excel");
            return TestResultEnum.Success;
        }
    }
}
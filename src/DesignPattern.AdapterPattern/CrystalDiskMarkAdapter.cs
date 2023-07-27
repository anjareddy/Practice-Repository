using DesignPattern.Common.Enums;
using DesignPattern.Common.Models;
using System.Reflection;

namespace DesignPattern.AdapterPattern
{
    public class CrystalDiskMarkAdapter : ITestToolAdapter
    {
        private readonly CrystalDiskMarkAdaptee _adaptee;

        public CrystalDiskMarkAdapter(CrystalDiskMarkAdaptee adaptee)
        {
            _adaptee = adaptee;
        }

        public TestResultEnum Run(Test test)
        {
            Console.WriteLine("Running CrystalDiskMark Application");

            _adaptee.Execute(test);
            return TestResultEnum.Success;
        }
    }

    public class CrystalDiskMarkAdaptee
    {
        internal TestResultEnum Execute(Test test)
        {
            Console.WriteLine("Writing data onto SSD");
            Console.WriteLine("Reading data from SSD");
            Console.WriteLine("Evaluating read/write speed");
            Console.WriteLine(test.Name.IsDefaultValue() ? "NoName": test.Name);
            Console.WriteLine(Argument.IsNull(test.Configuration) ? "NoConfiguration": test.Configuration);
            Console.WriteLine(Argument.IsNull(test.PrerequisiteInfo) ? "NoPrerequisite": test.PrerequisiteInfo);
            Console.WriteLine("Saving test data to DB");
            return TestResultEnum.Success;
        }
    }

    public static class NullCheckExtension
    {
        public static bool IsDefaultValue(this object objectInstance)
        {
            if (objectInstance.GetType().IsPrimitive)
            {
                return objectInstance == default;
            }
            return false;
        }
    }

    public static class Argument
    {
        public static bool IsNull(object objectInstance)
        {
            return objectInstance == default || objectInstance == null;
        }
    }
}
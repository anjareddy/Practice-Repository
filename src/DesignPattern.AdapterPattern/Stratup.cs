using DesignPattern.Common.Models;
using Microsoft.Extensions.DependencyInjection;

namespace DesignPattern.AdapterPattern
{
    public class Startup
    {
        public static void Execute()
        {

            Console.WriteLine("Testing Adapter Pattern");
            TestSuite testSuite = PrepareTestSuite();
            Console.WriteLine(testSuite.Id);
            Console.WriteLine(testSuite.Name);
            Console.WriteLine(testSuite.Description);

            var services = new ServiceCollection();
            services.AddTransient<CrystalDiskMarkAdaptee>();
            services.AddTransient<IOMeterAdaptee>();

            //BASIC Dependency Injection where there are multiple types to resolve during runtime
            services.AddTransient<ITestToolAdapter, CrystalDiskMarkAdapter>();
            services.AddTransient<ITestToolAdapter, IOMeterAdapter>();
            var serviceProvider = services.BuildServiceProvider();
            foreach (Test test in testSuite.Tests)
            {
                var testAdapter = TestToolAdapterFactory.GetTestToolAdapterType(test.TestApp.ToString());
                //var testAdapters = serviceProvider.GetServices<ITestToolAdapter>();
                //var testAdapter = testAdapters.FirstOrDefault(x => x.GetType() == adapterType);
                if (testAdapter != null)
                {
                    testAdapter.Run(test);
                }
            }


        }

        private static TestSuite PrepareTestSuite()
        {
            List<Test> tests = new List<Test>
            {
                new Test
                {
                    Id = Guid.NewGuid(),
                    TestApp = TestApplicationEnum.CrystalDiskMark,
                    Name = "CrystalDiskMark",
                    TestSteps =  new List<string> { "Read INI file", "Execute", "Write results to DB" }
                },
                new Test
                {
                    Id = Guid.NewGuid(),
                    TestApp = TestApplicationEnum.IOMeter,
                    Name = "IOMeter",
                    TestSteps =  new List<string> { "Execute", "Write results to File" }
                }
            };
            
            return new TestSuite()
            {
                Id = Guid.NewGuid(),
                Name = "TestSuite_Name",
                Description = "TestSuite_Desc",
                Tests = tests
            };
        }
    }
}
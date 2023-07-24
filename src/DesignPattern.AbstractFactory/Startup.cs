using DesignPattern.AbstractFactory.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.AbstractFactory
{
    public class Startup
    {
        public static List<string> OEMs = new List<string>()
        {
            "Dell", "Lenovo", "Asus", "HP", "Apple", "UNKNOWN"
        };

        public static void Execute()
        {
            OEMTestPackageFactory oemTestPackageFactory = new OEMTestPackageFactory();
            foreach (var oem in OEMs)
            {
                try
                {
                    Console.WriteLine("==================================================================");
                    Console.WriteLine(oem.ToUpper());
                    Console.WriteLine("==================================================================");
                    IOEMTestPackage oemTestPackage = oemTestPackageFactory.GetOEMTestPackage(oem);
                    oemTestPackage.GetTestRunSuite().Run();
                    oemTestPackage.GetReportGenerator().GenerateReport();
                    Console.WriteLine("==================================================================");
                }
                catch (Exception e)
                {
                    Console.WriteLine("==================================================================");
                    Console.WriteLine("EXCEPTION:");
                    Console.WriteLine(e.Message);
                    Console.WriteLine("==================================================================");
                }
            }
        }
    }
}

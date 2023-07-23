using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryAndAbstractFactory.Factory
{
    public class FactoryStartup
    {
        public static List<string> OEMs = new List<string>()
        {
                "Dell", "Lenovo", "Asus", "HP", "Apple", "UNKNOWN"
        };
        public static void Execute()
        {
            List<int> testValues = new List<int>()
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10
            };

            foreach(var oem in OEMs)
            {
                try
                {
                    Console.WriteLine("==================================================================");
                    Console.WriteLine(oem.ToUpper());
                    Console.WriteLine("==================================================================");
                    var calculator = OEMCalculatorFactory.Create(oem);
                    Console.WriteLine(calculator.CalculateDisplayValue(testValues));
                    Console.WriteLine("==================================================================");
                }
                catch(Exception e)
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

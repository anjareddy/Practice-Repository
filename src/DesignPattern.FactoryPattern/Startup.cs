namespace DesignPattern.FactoryPattern
{
    public class Startup
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
                    OEMTestPackageFactory calculatorFactory = new OEMTestPackageFactory();
                    Console.WriteLine("==================================================================");
                    Console.WriteLine(oem.ToUpper());
                    Console.WriteLine("==================================================================");
                    var calculator = calculatorFactory.GetCalculator(oem);
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

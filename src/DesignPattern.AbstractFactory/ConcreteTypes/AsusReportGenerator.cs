using DesignPattern.AbstractFactory.Abstracts;
using DesignPattern.FactoryPattern;

namespace DesignPattern.AbstractFactory.ConcreteTypes
{
    public class AsusReportGenerator : IReportGenerator
    {
        private ICalculator _calculator;
        public AsusReportGenerator(ICalculator calculator) 
        { 
            _calculator = calculator;
        }

        public void GenerateReport()
        {
            List<int> values = new List<int>()
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12
            };
            _calculator.CalculateDisplayValue(values);
            Console.WriteLine($"Generating Report for {nameof(AsusReportGenerator)}");
        }
    }
}

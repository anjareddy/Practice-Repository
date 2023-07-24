using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPattern.AbstractFactory.Abstracts;
using DesignPattern.FactoryPattern;

namespace DesignPattern.AbstractFactory.ConcreteTypes
{
    public class LenovoReportGenerator : IReportGenerator
    {
        private ICalculator _calculator;
        public LenovoReportGenerator(ICalculator calculator)
        {
            _calculator = calculator;
        }
        public void GenerateReport()
        {
            List<int> values = new List<int>()
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25
            };
            _calculator.CalculateDisplayValue(values);
            Console.WriteLine($"Generating Report for {nameof(LenovoReportGenerator)}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPattern.AbstractFactory.Abstracts;
using DesignPattern.FactoryPattern;

namespace DesignPattern.AbstractFactory.ConcreteTypes
{
    public class DellReportGenerator : IReportGenerator
    {
        private ICalculator _calculator;
        public DellReportGenerator(ICalculator calculator)
        {
            _calculator = calculator;
        }

        public void GenerateReport()
        {
            List<int> values = new List<int>()
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10
            };
            _calculator.CalculateDisplayValue(values);
            Console.WriteLine($"Generating Report for {nameof(DellReportGenerator)}");
        }
    }
}

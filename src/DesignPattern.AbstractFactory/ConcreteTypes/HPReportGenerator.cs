using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPattern.AbstractFactory.Abstracts;
using DesignPattern.FactoryPattern;

namespace DesignPattern.AbstractFactory.ConcreteTypes
{
    public class HPReportGenerator : IReportGenerator
    {
        private ICalculator _calculator;
        public HPReportGenerator(ICalculator calculator)
        {
            _calculator = calculator;
        }

        public void GenerateReport()
        {
            List<int> values = new List<int>()
            {
                1, 2, 3, 4, 5
            };
            _calculator.CalculateDisplayValue(values);
            Console.WriteLine($"Generating Report for {nameof(HPReportGenerator)}");
        }
    }
}

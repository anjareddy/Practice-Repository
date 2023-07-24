using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.FactoryPattern.ConcreteTypes
{
    public class AppleCalculator : ICalculator
    {
        public int CalculateDisplayValue(List<int> values)
        {
            Console.WriteLine("MAX");
            return values.Max();
        }
    }
}

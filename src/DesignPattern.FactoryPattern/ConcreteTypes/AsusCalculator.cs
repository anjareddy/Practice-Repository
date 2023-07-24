using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.FactoryPattern.ConcreteTypes
{
    public class AsusCalculator : ICalculator
    {
        public int CalculateDisplayValue(List<int> values)
        {
            Console.WriteLine("AVG");
            return values.Sum() / values.Count;
        }
    }
}

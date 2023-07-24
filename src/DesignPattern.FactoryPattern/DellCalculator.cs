using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.FactoryPattern
{
    public class DellCalculator:ICalculator
    {
        public int CalculateDisplayValue(List<int> values)
        {
            Console.WriteLine("FIRST");
            return values.First();
        }
    }
}

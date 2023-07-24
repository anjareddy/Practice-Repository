using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.FactoryPattern
{
    public class HPCalculator: ICalculator
    {
        public int CalculateDisplayValue(List<int> values) 
        {
            Console.WriteLine("MIN");
            return values.Min();
        }
    }
}

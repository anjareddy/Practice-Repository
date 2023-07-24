using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.FactoryPattern
{
    internal interface ICalculator
    {
        int CalculateDisplayValue(List<int> values);
    }
}

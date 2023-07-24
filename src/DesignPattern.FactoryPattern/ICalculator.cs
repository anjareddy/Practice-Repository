using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.FactoryPattern
{
    public interface ICalculator
    {
        int CalculateDisplayValue(List<int> values);
    }
}

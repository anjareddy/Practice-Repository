using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryAndAbstractFactory.Factory
{
    internal class AsusCalculator: ICalculator
    {
        public int CalculateDisplayValue(List<int> values) 
        {
            return values.Sum() / values.Count;
        }
    }
}

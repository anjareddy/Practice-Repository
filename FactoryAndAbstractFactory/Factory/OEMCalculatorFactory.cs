using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryAndAbstractFactory.Factory
{
    internal class OEMCalculatorFactory
    {
        public static ICalculator Create(string oem) 
        {
            try
            {
                string className = $"{oem}Calculator";
                Type classType = Type.GetType(className);
                if (classType != null && classType.IsClass && !classType.IsAbstract)
                {
                    ICalculator calculator = (ICalculator)Activator.CreateInstance(classType);
                    return calculator;
                } 
                else
                {
                    throw new Exception("UNSUPPORTED_OEM_TYPE");
                }
            }
            catch
            {
                throw;
            }
        }
    }
}

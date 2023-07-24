using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.FactoryPattern
{
    public class OEMCalculatorFactory
    {
        public ICalculator GetCalculator(string oem)
        {
            return Create(oem);
        }

        private static ICalculator Create(string oem) 
        {
            try
            {
                string className = $"DesignPattern.FactoryPattern.ConcreteTypes.{oem}Calculator";
                Type classType = Type.GetType(className);
                if (classType != null && classType.IsClass && !classType.IsAbstract)
                {
                    return Activator.CreateInstance(classType) as ICalculator;
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

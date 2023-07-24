using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPattern.AbstractFactory.Abstracts;
using DesignPattern.AbstractFactory.ConcreteTypes;
using DesignPattern.FactoryPattern;

namespace DesignPattern.AbstractFactory.ConcreteFactories
{
    public class LenovoTestPackageConcreteFactory : IOEMTestPackage
    {
        public ITestRunSuite GetTestRunSuite()
        {
            return new LenovoTestRunSuite();
        }

        public IReportGenerator GetReportGenerator(ICalculator calculator)
        {
            return new LenovoReportGenerator(calculator);
        }
    }
}

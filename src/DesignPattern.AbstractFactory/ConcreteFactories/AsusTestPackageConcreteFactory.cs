using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPattern.AbstractFactory.Abstracts;
using DesignPattern.AbstractFactory.ConcreteTypes;

namespace DesignPattern.AbstractFactory.ConcreteFactories
{
    public class AsusTestPackageConcreteFactory : IOEMTestPackage
    {
        public ITestRunSuite GetTestRunSuite()
        {
            return new AsusTestRunSuite();
        }

        public IReportGenerator GetReportGenerator()
        {
            return new AsusReportGenerator();
        }
    }
}

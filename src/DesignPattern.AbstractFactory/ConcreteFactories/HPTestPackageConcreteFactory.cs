using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPattern.AbstractFactory.Abstracts;
using DesignPattern.AbstractFactory.ConcreteTypes;

namespace DesignPattern.AbstractFactory.ConcreteFactories
{
    public class HPTestPackageConcreteFactory : IOEMTestPackage
    {
        public ITestRunSuite GetTestRunSuite()
        {
            return new HPTestRunSuite();
        }

        public IReportGenerator GetReportGenerator()
        {
            return new HPReportGenerator();
        }
    }
}
